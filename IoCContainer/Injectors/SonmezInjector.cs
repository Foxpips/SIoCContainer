using System;
using System.Collections.Generic;
using System.Linq;

namespace SIoCContainer.Injectors
{
    //Injector inspired by John Sonmez
    public class SonmezInjector
    {
        private readonly Dictionary<Type, Type> _providers = new Dictionary<Type, Type>();

        public void Bind<TFrom, TTo>()
        {
            _providers.Add(typeof (TFrom), typeof (TTo));
        }

        public TKey Resolve<TKey>()
        {
            return (TKey) Resolve(typeof (TKey));
        }

        private object Resolve(Type type)
        {
            return ResolveDependencies(_providers.ContainsKey(type) ? _providers[type] : type);
        }

        private object ResolveDependencies(Type resolvedType)
        {
            var constructor = resolvedType.GetConstructors().First();
            var paraminfos = constructor.GetParameters();

            return !paraminfos.Any()
                ? Activator.CreateInstance(resolvedType)
                : constructor.Invoke(paraminfos.Select(parameterInfo => Resolve(parameterInfo.ParameterType)).ToArray());
        }
    }
}