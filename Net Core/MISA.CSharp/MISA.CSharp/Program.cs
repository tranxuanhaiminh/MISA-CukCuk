using System;
using MISA.CSharp;

namespace MISA.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee("Nguyễn Văn A", "NV001");
            var customer= new Customer();
            Base<Employee>.SetName(employee, "Nguyễn Văn B");
            Base<Customer>.SetName(customer, "Nguyễn Văn C");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(employee.FullName);
            Console.WriteLine(customer.FullName);
        }

        /// <summary>
        /// Trả về tuổi của khách hàng
        /// </summary>
        /// <returns>string - email của khách hàng</returns>
        /// CreatedBy: TXHMinh (23/07/2021)
        public string GetEmail()
        {
            var emp = new Employee("Nguyễn Văn A", "NV002");
            return emp.Email;
        }
    } 
}
