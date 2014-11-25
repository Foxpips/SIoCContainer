using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using SIoCContainer.Attributes;
using SIoCContainer.Resolver.Services;

namespace SIoCContainer.Resolver
{
    public static class DependencyResolver
    {
        private static readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        public static void Register<TFrom, TTo>()
        {
            try
            {
                _dependencyMap.Add(typeof (TFrom), typeof (TTo));
            }
            catch (Exception e)
            {
                var message = String.Format("Already registered type : {0} \nError : {1}", typeof (TFrom).Name,
                    e.Message);
                throw new Exception(message);
            }
        }

        private static void Register(Type type)
        {
            if (!_dependencyMap.ContainsKey(type))
            {
                _dependencyMap.Add(type, type);
            }
        }

        public static void Register(Type typeFrom, Type typeTo)
        {
            if (!_dependencyMap.ContainsKey(typeFrom))
            {
                _dependencyMap.Add(typeFrom, typeTo);
            }
        }

        public static TType Resolve<TType>()
        {
            var type = typeof (TType);

            object obj = CheckConstructors(type);

            SetFields(obj, ObjectCrawler.GetFieldInfos(type));
            SetProperties(obj, ObjectCrawler.GetPropertyInfos(type));

            return (TType) obj;
        }

        private static void SetFields(object obj, IEnumerable<FieldInfo> fieldInfos)
        {
            foreach (var fieldInfo in fieldInfos)
            {
                var fieldType = fieldInfo.FieldType;
                try
                {
                    if (_dependencyMap.ContainsKey(fieldType))
                    {
                        var dependentModule = _dependencyMap[fieldType];

                        var constructorInfo = dependentModule.GetConstructors().First();
                        ParameterInfo[] parameterInfos = constructorInfo.GetParameters();
                        if (parameterInfos.Any())
                        {
                            constructorInfo.Invoke(parameterInfos
                                .Select(p => CheckConstructors(p.ParameterType))
                                .ToArray());
                        }
                        else
                        {
                            var instance = Activator.CreateInstance(dependentModule);
                            fieldInfo.SetValue(obj, instance);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception(String.Format("An error occurred trying to resolve dependency of :  {0}",
                        fieldType.Name));
                }
            }
        }

        private static void SetProperties(object obj, IEnumerable<PropertyInfo> propertyInfos)
        {
            foreach (var propertyInfo in propertyInfos)
            {
                var propertyType = propertyInfo.PropertyType;

                RegisterBaseTypes(propertyType);

                try
                {
                    if (_dependencyMap.ContainsKey(propertyType))
                    {
                        var checkConstructors = CheckConstructors(propertyType);
                        if (checkConstructors != null)
                        {
                            SetProperties(checkConstructors, checkConstructors.GetType().GetProperties());
                            propertyInfo.SetValue(obj, checkConstructors);
                        }
                    }
                    else
                    {
                        var attribute = propertyInfo.GetCustomAttribute(typeof (InjectableAttribute));
                        if (attribute != null)
                        {
                            var value = ((InjectableAttribute) attribute).Value;
                            propertyInfo.SetValue(obj, value);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception(String.Format("An error occurred trying to resolve dependency of : {0}",
                        propertyType.Name));
                }
            }
        }

        private static void RegisterBaseTypes(Type propertyType)
        {
            if (!TypeCheckerService.IsNativeType(propertyType))
            {
                Register(propertyType);
            }
        }

        private static object CheckConstructors(Type typeToResolve)
        {
            Type resolvedType;
            RegisterBaseTypes(typeToResolve);
            try
            {
                resolvedType = _dependencyMap[typeToResolve];
            }
            catch (Exception)
            {
                throw new Exception(String.Format("Could not resolve type {0}", typeToResolve.FullName));
            }
            var firstConstructor = resolvedType.GetConstructors().First();
            var parameterInfos = firstConstructor.GetParameters();

            if (!parameterInfos.Any())
            {
                var checkConstructors = Activator.CreateInstance(resolvedType);
                SetFields(checkConstructors, ObjectCrawler.GetFieldInfos(checkConstructors.GetType()));
                return checkConstructors;
            }

            IList<object> parameterObjectList =
                parameterInfos.Select(parameterInfo => CheckConstructors(parameterInfo.ParameterType)).ToList();

            return firstConstructor.Invoke(parameterObjectList.ToArray());
        }
    }
}