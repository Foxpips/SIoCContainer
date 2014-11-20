using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SIoCContainer.Resolver.Services
{
    public static class ClassCrawlerService
    {
        public class ReflectedFieldObject
        {
            public string Name { get; set; }
            public object TypeAtRunTime { get; set; }
            public Type UnderlyingType { get; set; }
        }

        public static IEnumerable<ReflectedFieldObject> GetAllMemberInfos(object obj, BindingFlags bindingFlags)
        {
            var type = obj.GetType();

            var reflectedFieldObjects = new List<ReflectedFieldObject>();

            reflectedFieldObjects.AddRange(type.GetFields(bindingFlags).Select(fieldInfo => new ReflectedFieldObject
            {
                Name = fieldInfo.Name,
                UnderlyingType = fieldInfo.FieldType,
                TypeAtRunTime = fieldInfo.GetValue(obj)
            }));

            reflectedFieldObjects.AddRange(type.GetProperties(bindingFlags).Select(fieldInfo => new ReflectedFieldObject
            {
                Name = fieldInfo.Name,
                UnderlyingType = fieldInfo.PropertyType,
                TypeAtRunTime = fieldInfo.GetValue(obj)
            }));

            return reflectedFieldObjects;
        }

        public static bool DoesClassContainType<TClass>(IEnumerable<ReflectedFieldObject> objects)
        {
            var containsType = false;

            foreach (var reflectedObject in objects)
            {
                var fieldTypeAtRunTime = reflectedObject.TypeAtRunTime;

                if (fieldTypeAtRunTime != null && fieldTypeAtRunTime.ToString().Equals(typeof (TClass).FullName))
                {
                    DisplayTypeDetails(reflectedObject, fieldTypeAtRunTime);
                    containsType = true;
                }
            }
            return containsType;
        }

        private static void DisplayTypeDetails(ReflectedFieldObject reflectedObject, object fieldTypeAtRunTime)
        {
            Console.WriteLine(reflectedObject.Name);
            Console.WriteLine(reflectedObject.UnderlyingType);
            Console.WriteLine(fieldTypeAtRunTime);
            Console.WriteLine();
        }

        public static T MapOut<T>(T mappable)
        {
            var mapOut = mappable;

            return mapOut;
        }
    }
}