using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISADisplayName : Attribute
    {
        public string PropertyName = string.Empty;
        public MISADisplayName(string propName)
        {
            this.PropertyName = propName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISADuplicate : Attribute
    {

    }
}
