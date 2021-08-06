using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Common.Entity;
using MISA.DataAccess;

namespace MISA.DataAccess
{
    public class EmployeeContext2 : DbContext<Employee>, IEmployeeContext
    {
        #region Methods
        /// <summary>
        /// Thêm mới dữ liệu vào database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public int Post(Employee employee)
        {
            // Sinh mới Id cho Employee:
            //employee.EmployeeId = Guid.NewGuid();

            //// Khai báo câu lệnh thực hiện thêm mới dữ liệu:
            //var sqlCommand = $"INSERT INTO " +
            //        $"Employee(EmployeeId," +
            //        $"EmployeeCode," +
            //        //$"FirstName," +
            //        //$"LastName," +
            //        $"FullName)" +
            //        //$"Gender," +
            //        //$"DateOfBirth," +
            //        //$"PhoneNumber," +
            //        //$"Email," +
            //        //$"Address," +
            //        //$"IdentityNumber," +
            //        //$"IdentityDate," +
            //        //$"IdentityPlace," +
            //        //$"MartialStatus," +
            //        //$"EducationalBackground," +
            //        //$"QualificationId," +
            //        //$"DepartmentId" +
            //        //$"PositionId," +
            //        //$"WorkStatus," +
            //        //$"PersonalTaxCode," +
            //        //$"Salary," +
            //        //$"CreatedBy," +
            //        //$"ModifiedDate," +
            //        //$"ModifiedBy)" +
            //        $"VALUE('{employee.EmployeeId.ToString()}'," +
            //        $"'{employee.EmployeeCode}'," +
            //        $"'{employee.FullName}')";

            //// Thực hiện câu lệnh thêm dữ liệu
            //var rowAffected = DbConnection.Execute(sqlCommand);
            //return rowAffected;
            return 2;
        }


        /// <summary>
        /// Sửa dữ liệu trên database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //public int Put(Employee employee)
        //{
        //    // Sinh mới Id cho Employee:
        //    employee.EmployeeId = Guid.NewGuid();

        //    // Khai báo câu lệnh thực hiện thêm mới dữ liệu:
        //    var sqlCommand = $"UPDATE Employee " +
        //            $"Employee(EmployeeId, EmployeeCode, FullName)" +
        //            $"VALUE('{employee.EmployeeId.ToString()}', '{employee.EmployeeCode}', '{employee.FullName}')";
        //    //var sqlCommand = $"UPDATE Employee SET "

        //    // Thực hiện câu lệnh thêm dữ liệu
        //    var rowAffected = DbConnection.Execute(sqlCommand);
        //    return rowAffected;
        //}


        /// <summary>
        /// Kiểm tra mã nhân viên trùng lặp với dữ liệu có sẵn
        /// </summary>
        /// <param name="employeeCode"> Mã nhân viên cần kiểm tra</param>
        /// <returns> Boolean - Có bị trùng hay không </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public bool CheckDuplicateEmployeeCode(string employeeCode)
        {
            // Truy cập Database check xem mã nhân viên đã có hay chưa;

            // Khai báo câu lệnh truy vấn dữ liệu
            var sqlCommand = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";

            // Tạo parameters cho câu lệnh truy vấn
            DynamicParameters parameters = new();
            parameters.Add("@EmployeeCode", employeeCode);

            // Thực hiện truy vấn dữ liệu kiểm tra
            var isDuplicate = DbConnection.QueryFirstOrDefault<string>(sql: sqlCommand, param: parameters);

            //Trả về: true - nếu mã nhân viên bị trùng, false - nếu không
            return (isDuplicate != null);
        }

        // Sửa:

        // Xóa:

        #endregion
    }
}
