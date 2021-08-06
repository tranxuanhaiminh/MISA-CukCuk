using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySqlConnector;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;

namespace MISA.Infrastructure.Repository
{
    public class EmployeeRepository : DbContext<Employee>, IEmployeeContext
    {
        #region Methods
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
        //public bool CheckDuplicateEmployeeCode(string employeeCode)
        //{
        //    // Truy cập Database check xem mã nhân viên đã có hay chưa;

        //    // Khai báo câu lệnh truy vấn dữ liệu
        //    var sqlCommand = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";

        //    // Tạo parameters cho câu lệnh truy vấn
        //    DynamicParameters parameters = new();
        //    parameters.Add("@EmployeeCode", employeeCode);

        //    // Thực hiện truy vấn dữ liệu kiểm tra
        //    var isDuplicate = DbConnection.QueryFirstOrDefault<string>(sql: sqlCommand, param: parameters);

        //    //Trả về: true - nếu mã nhân viên bị trùng, false - nếu không
        //    return (isDuplicate != null);
        //}

        /// <summary>
        /// Phương thức trả về phân trang
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public object GetPaging()
        {
            int totalRecord = 0;
            int totalPage = 0;
            DynamicParameters parameters = new();
            parameters.Add("@TotalRecord", direction: System.Data.ParameterDirection.Output);
            parameters.Add("@TotalPage", direction: System.Data.ParameterDirection.Output);
            parameters.Add("@CustomerFilter", "");
            parameters.Add("@DepartmentId", null);
            parameters.Add("@PositionId", null);
            parameters.Add("@PageIndex", 1);
            parameters.Add("@@PageSize", 10);
            var storeName = "Proc_GetEmployeesFilterPaging";
            var employees = DbConnection.Query<object>(sql: storeName, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
            totalRecord = parameters.Get<int>("@TotalRecord");
            totalPage = parameters.Get<int>("@TotalPage");
            var obj = new
            {
                Data = employees,
                TotalPage = totalPage,
                TotalRecord = totalRecord
            };
            return obj;
        }
        #endregion
    }
}
