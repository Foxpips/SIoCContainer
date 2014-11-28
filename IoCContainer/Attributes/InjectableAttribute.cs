using System;

namespace IoCContainer.Attributes
{
    public class InjectableAttribute : Attribute
    {
        public object Value { get; set; }

        public InjectableAttribute(object value)
        {
            Value = value;
        }

        public InjectableAttribute()
        {
            
        }
    }
}