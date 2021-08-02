using System;
using Count4U.Service.Model;
using Monitor.Service.Model;

namespace Count4U.Model.Extensions
{
    [AttributeUsageAttribute(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public class StepAttribute : Attribute
    {
         public AdapterCommandStepEnum Name { get; set;}
    }

    [AttributeUsageAttribute(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public class StepProfileAttribute : Attribute
    {
        public ProfiFileStepEnum Name { get; set; }
    }
}