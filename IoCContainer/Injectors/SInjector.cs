using System;
using System.Collections.Generic;
using System.Linq;

using IoCContainer.Extensions;
using IoCContainer.Registers;

namespace IoCContainer.Injectors
{
    public class SInjector
    {
        private readonly Dictionary<Type, Type> _providers = new Dictionary<Type, Type>();

        public SInjector()
        {
            _providers.AddRange(IoCCoreRegister.CoreTypeRegistry);
        }

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
            var constructorInfos = resolvedType.GetConstructors();
            if (constructorInfos.Any())
            {
                var constructor = constructorInfos.First();
                return
                    constructor.Invoke(constructor.GetParameters()
                        .Select(p => Resolve(p.ParameterType))
                        .ToArray());
            }
            return null;
        }
    }
}