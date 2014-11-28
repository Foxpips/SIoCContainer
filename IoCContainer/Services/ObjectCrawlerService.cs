using System;
using System.Collections.Generic;
using System.Reflection;

namespace IoCContainer.Services
{
    public class ObjectCrawlerService
    {
        public static IEnumerable<PropertyInfo> GetPropertyInfos(Type type)
        {
            return type.GetProperties(
                BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
        }

        public static IEnumerable<FieldInfo> GetFieldInfos(Type type)
        {
            return type.GetFields(
                BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
        }

        public static void IterateTypeMemberValues(object testType)
        {
            IReflect getType = testType.GetType();
            var propertyInfos = getType.GetProperties(
                BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            foreach (
                var propertyInfo in propertyInfos)
            {
                Console.WriteLine(propertyInfo.Name + " : " + propertyInfo.GetValue(testType));
            }

            var fieldInfos = getType.GetFields(
                BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            foreach (
                var fieldInfo in fieldInfos)
            {
                var value = fieldInfo.GetValue(testType);
                if (value != null && !fieldInfo.Name.Contains("BackingField"))
                {
                    Console.WriteLine(fieldInfo.Name + " : " + value);
                }
            }
        }
    }
}