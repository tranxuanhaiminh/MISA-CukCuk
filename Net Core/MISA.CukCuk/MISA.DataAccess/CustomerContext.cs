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
    public class CustomerContext : DbContext<Customer>
    {
        #region Methods
        /// <summary>
        /// Thêm mới dữ liệu vào database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public int Post(Customer customer)
        {
            // Sinh mới Id cho Customer:
            customer.CustomerId = Guid.NewGuid();

            // Khai báo câu lệnh thực hiện thêm mới dữ liệu:
            var sqlCommand = $"INSERT INTO " +
                    $"Customer(CustomerId," +
                    $"CustomerCode," +
                    //$"FirstName," +
                    //$"LastName," +
                    $"FullName," +
                    //$"Gender," +
                    //$"DateOfBirth," +
                    //$"PhoneNumber," +
                    //$"Email," +
                    //$"Address," +
                    //$"IdentityNumber," +
                    //$"IdentityDate," +
                    //$"IdentityPlace," +
                    //$"MartialStatus," +
                    //$"EducationalBackground," +
                    //$"QualificationId," +
                    //$"DepartmentId" +
                    //$"PositionId," +
                    //$"WorkStatus," +
                    //$"PersonalTaxCode," +
                    //$"Salary," +
                    //$"CreatedBy," +
                    //$"ModifiedDate," +
                    //$"ModifiedBy)" +
                    $"VALUE('{customer.CustomerId.ToString()}'," +
                    $"'{customer.CustomerCode}'," +
                    $"'{customer.FullName}')";

            // Thực hiện câu lệnh thêm dữ liệu
            var rowAffected = DbConnection.Execute(sqlCommand);
            return rowAffected;
        }


        /// <summary>
        /// Sửa dữ liệu trên database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //public int Put(Customer customer)
        //{
        //    // Sinh mới Id cho customer:
        //    customer.CustomerId = Guid.NewGuid();

        //    // Khai báo câu lệnh thực hiện thêm mới dữ liệu:
        //    var sqlCommand = $"UPDATE Customer " +
        //            $"Customer(CustomerId, CustomerCode, FullName)" +
        //            $"VALUE('{customer.CustomerId.ToString()}', '{customer.CustomerCode}', '{customer.FullName}')";
        //    //var sqlCommand = $"UPDATE Customer SET "

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
        public bool CheckDuplicateCustomerCode(string customerCode)
        {
            // Truy cập Database check xem mã nhân viên đã có hay chưa;

            // Khai báo câu lệnh truy vấn dữ liệu
            var sqlCommand = "SELECT CustomerCode FROM Customer WHERE CustomerCode = @CustomerCode";

            // Tạo parameters cho câu lệnh truy vấn
            DynamicParameters parameters = new();
            parameters.Add("@CustomerCode", customerCode);

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