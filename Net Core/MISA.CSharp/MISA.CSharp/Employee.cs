using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.CSharp
{
    public class Employee : Base<Employee>
    {
        #region Fields
        public string _phoneNumber;
        public string Email;
        #endregion

        #region Properties
        string Address { get; set; }

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="dateOfBirth"></param>
        public Employee(string fullName, string EmployeeCode)
        {
            this.FullName = fullName;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Phương thức lây tên của nhân viên
        /// </summary>
        /// <returns>string - Tên của nhân viên</returns>
        /// CreatedBy: TXHMinh (23/07/2021)
        public string GetName()
        {
            return this.FullName;
        }

        /// <summary>
        /// Tính điểm nhân viên
        /// </summary>
        /// CreatedBy: TXHMinh (23/07/2021)
        public void CalculatorMark()
        {

        }

        /// <summary>
        /// Đặt thông tin địa chỉ của nhân viên
        /// </summary>
        /// <param name="address"></param>
        /// CreatedBy: TXHMinh (23/07/2021)
        public void SetAddress(string address)
        {
            this.Address = address;
        }
        #endregion
    }
}
