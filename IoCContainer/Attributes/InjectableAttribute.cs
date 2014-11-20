using System;

namespace SIoCContainer.Attributes
{
    public class InjectableAttribute : Attribute
    {
        public object Value { get; set; }

        public InjectableAttribute(object value)
        {
            Value = value;
        }
    }
}