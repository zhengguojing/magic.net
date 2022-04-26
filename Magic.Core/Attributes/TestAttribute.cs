using System;

namespace Magic.Core
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class TestAttribute: Attribute
    {
        public string Name { get; set; }
    }
}
