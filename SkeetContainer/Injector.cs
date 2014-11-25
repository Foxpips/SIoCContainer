using System;
using System.Collections.Generic;
using System.Linq;

namespace SkeetContainer
{
    internal class Injector
    {
        private readonly Dictionary<Type, Type> _providers = new Dictionary<Type, Type>();

        public void Bind<TFrom, TTo>()
        {
            _providers.Add(typeof (TFrom), typeof (TTo));
        }

        internal TKey Resolve<TKey>()
        {
            return (TKey) ResolveByType(typeof (TKey));
        }

        private object ResolveByType(Type type)
        {
            return GetTypeResolution(_providers.ContainsKey(type) ? _providers[type] : type);
        }

        private object GetTypeResolution(Type resolvedType)
        {
            var constructor = resolvedType.GetConstructors().First();
            var paraminfos = constructor.GetParameters();

            return !paraminfos.Any()
                ? Activator.CreateInstance(resolvedType)
                : constructor.Invoke(paraminfos.Select(parameterInfo => ResolveByType(parameterInfo.ParameterType)).ToArray());
        }
    }
}