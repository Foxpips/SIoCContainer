using System;
using System.Collections.Generic;
using System.Linq;

namespace SIoCContainer.Injectors
{
    //Injector inspired by Jon Skeet
    public class SkeetInjector
    {
        private readonly Dictionary<Type, Func<object>> _dependencyMap = new Dictionary<Type, Func<object>>();

        public void Bind<TFrom, TTo>()
        {
            _dependencyMap.Add(typeof (TFrom), () => ResolveDependencies(typeof (TTo)));
        }

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        private object Resolve(Type type)
        {
            Func<object> provider;
            return _dependencyMap.TryGetValue(type, out provider) ? provider() : ResolveDependencies(type);
        }

        private object ResolveDependencies(Type type)
        {
            var constructorInfo = type.GetConstructors().First();
            return
                constructorInfo.Invoke(constructorInfo.GetParameters()
                    .Select(p => Resolve(p.ParameterType))
                    .ToArray());
        }
    }
}