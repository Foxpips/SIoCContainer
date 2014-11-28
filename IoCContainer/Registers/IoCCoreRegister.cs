using System;
using System.Collections.Generic;

namespace SIoCContainer.Registers
{
    public class IoCCoreRegister
    {
        private static readonly List<KeyValuePair<Type, Type>> _coreTypeRegistry = new List<KeyValuePair<Type, Type>>();

        public static void Register(Type key, Type value)
        {
            _coreTypeRegistry.Add(new KeyValuePair<Type, Type>(key, value));
        }

        public static List<KeyValuePair<Type, Type>> CoreTypeRegistry
        {
            get { return _coreTypeRegistry; }
        }
    }
}