using System;
using System.Collections.Generic;

namespace IoCContainer.Registers
{
    public interface IRegistry
    {
        BaseRegistry From<T>();
        void To<T>();

        Dictionary<Type, Type> GetRegisteredTypes();
        void AssemblyContainingType<T>();
    }
}