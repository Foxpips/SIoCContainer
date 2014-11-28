using System;
using System.Collections.Generic;
using System.Linq;

namespace IoCContainer.Registers
{
    public class BaseRegistry : IRegistry
    {
        private Dictionary<Type, Type> _registryDictionary = new Dictionary<Type, Type>();

        private Type _fromObject;
        private Type _toObject;

        public Dictionary<Type, Type> GetRegisteredTypes()
        {
            return _registryDictionary;
        }

        public void AssemblyContainingType<T>()
        {
            var type = typeof (T);
            var interfaces = type.GetInterfaces();
            _registryDictionary.Add(interfaces.First(), type);
        }

        public void Scan(Action<IRegistry> action)
        {
            var scanner = new BaseRegistry();
            action(scanner);
            _registryDictionary = scanner._registryDictionary;
        }

        public BaseRegistry From<T>()
        {
            _fromObject = typeof (T);
            return this;
        }

        public void To<T>()
        {
            _toObject = typeof (T);
            _registryDictionary.Add(_fromObject, _toObject);
        }
    }
}