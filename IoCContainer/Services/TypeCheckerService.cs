using System;
using System.Collections.Generic;
using System.Linq;

namespace SIoCContainer.Services
{
    public class TypeCheckerService
    {
        private static List<Type> _systemTypes;

        private static List<Type> SystemTypes
        {
            get
            {
                var type = typeof (object).Assembly.GetType();
                var assembly = type.Module.Assembly;
                return _systemTypes ?? (_systemTypes = assembly.GetExportedTypes().ToList());
            }
        }

        public static bool IsNativeType(object obj)
        {
            var type = obj.GetType();
            return SystemTypes.Contains(type);
        }

        public static bool IsNativeType(Type type)
        {
            return SystemTypes.Contains(type);
        }
    }
}