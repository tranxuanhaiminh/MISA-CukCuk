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
    public class CustomerRepository : DbContext<Customer>, ICustomerContext
    {
        #region Methods
        /// <summary>
        /// Sửa dữ liệu trên database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //public int Put(Customer customer)
        //{
        //    // Sinh mới Id cho Employee:
        //    customer.CustomerId = Guid.NewGuid();

        //    // Khai báo câu lệnh thực hiện thêm mới dữ liệu:
        //    var sqlCommand = $"UPDATE Customer " +
        //            $"Customer(CustomerId, CustomerCode, FullName)" +
        //            $"VALUE('{customer.CustomerId.ToString()}', '{customer.CustomerCode}', '{customer.FullName}')";
        //    //var sqlCommand = $"UPDATE Employee SET "

        //    // Thực hiện câu lệnh thêm dữ liệu
        //    var rowAffected = DbConnection.Execute(sqlCommand);
        //    return rowAffected;
        //}


        /// <summary>
        /// Kiểm tra mã nhân viên trùng lặp với dữ liệu có sẵn
        /// </summary>
        /// <param name="customerCode"> Mã nhân viên cần kiểm tra</param>
        /// <returns> Boolean - Có bị trùng hay không </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //public bool CheckDuplicateCustomerCode(string customerCode)
        //{
        //    // Truy cập Database check xem mã nhân viên đã có hay chưa;

        //    // Khai báo câu lệnh truy vấn dữ liệu
        //    var sqlCommand = "SELECT CustomerCode FROM Customer WHERE CustomerCode = @CustomerCode";

        //    // Tạo parameters cho câu lệnh truy vấn
        //    DynamicParameters parameters = new();
        //    parameters.Add("@CustomerCode", customerCode);

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
            var totalRecord = 0;
            var totalPage = 0;
            DynamicParameters parameters = new();
            parameters.Add("@TotalRecord", direction: System.Data.ParameterDirection.Output);
            parameters.Add("@TotalPage", direction: System.Data.ParameterDirection.Output);
            parameters.Add("@CustomerFilter", "");
            parameters.Add("@DepartmentId", null);
            parameters.Add("@PositionId", null);
            parameters.Add("@PageIndex", 1);
            parameters.Add("@@PageSize", 10);
            var storeName = "Proc_GetCustomersFilterPaging";
            var customers = DbConnection.Query<object>(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            totalRecord = parameters.Get<int>("@TotalRecord");
            totalPage = parameters.Get<int>("@TotalPage");
            var obj = new
            {
                Data = customers,
                TotalPage = totalPage,
                TotalRecord = totalRecord
            };
            return obj;
        }

        #endregion
    }
}
