using System;
using System.Collections.Generic;
using System.Linq;

namespace SIoCContainer.Resolver
{
    public class Resolver
    {
        private readonly Dictionary<Type, Type> _dependencyMap = new Dictionary<Type, Type>();

        public void Register<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof (TFrom), typeof (TTo));
        }

        public T Resolve<T>()
        {
            return (T) ResolveType(typeof (T));
        }

        private object ResolveType(Type typeToResolve)
        {
            Type resolvedType;

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
                return Activator.CreateInstance(resolvedType);
            }

            IList<object> parameters2 =
                parameterInfos.Select(parameterInfo => ResolveType(parameterInfo.ParameterType)).ToList();

            return firstConstructor.Invoke(parameters2.ToArray());
        }
    }
}