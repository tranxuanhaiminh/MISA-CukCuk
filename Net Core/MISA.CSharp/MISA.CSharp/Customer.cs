using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CSharp
{
    public class Customer : Base<Customer>
    {
        public string FullName { get; set; }
    }
}
