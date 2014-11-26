using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SIoCContainer.Services
{
    public class ClassCrawlerService
    {
        public class ReflectedObject
        {
            public string Name { get; set; }
            public object TypeAtRunTime { get; set; }
            public Type UnderlyingType { get; set; }
        }

        public static IEnumerable<ReflectedObject> GetAllMemberInfos(object obj, BindingFlags bindingFlags)
        {
            var type = obj.GetType();

            var reflectedFieldObjects = new List<ReflectedObject>();

            reflectedFieldObjects.AddRange(type.GetFields(bindingFlags).Select(fieldInfo => new ReflectedObject
            {
                Name = fieldInfo.Name,
                UnderlyingType = fieldInfo.FieldType,
                TypeAtRunTime = fieldInfo.GetValue(obj)
            }));

            reflectedFieldObjects.AddRange(type.GetProperties(bindingFlags).Select(fieldInfo => new ReflectedObject
            {
                Name = fieldInfo.Name,
                UnderlyingType = fieldInfo.PropertyType,
                TypeAtRunTime = fieldInfo.GetValue(obj)
            }));

            return reflectedFieldObjects;
        }

        public static bool DoesClassContainType<TClass>(IEnumerable<ReflectedObject> objects)
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

        private static void DisplayTypeDetails(ReflectedObject reflectedObject, object fieldTypeAtRunTime)
        {
            Console.WriteLine(reflectedObject.Name);
            Console.WriteLine(reflectedObject.UnderlyingType);
            Console.WriteLine(fieldTypeAtRunTime);
            Console.WriteLine();
        }
    }
}