using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySqlConnector;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;

namespace MISA.Infrastructure
{
    /// <summary>
    /// Tương tác với database
    /// </summary>
    /// CreatedBy: TXHMinh (28/07/2021)
    public class DbContext<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        #region Fields
        //Các biến cần để tạo kết nối với database
        protected IDbConnection DbConnection;
        string _connectionString;
        #endregion

        #region Constructor
        /// <summary>
        /// Khởi tạo các thông tin cần để kết nối với database
        /// </summary>
        /// CreatedBy: TXHMinh (28/07/2021)
        public DbContext()
        {
            _connectionString = "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id = dev;" +
                "Password = 12345678;";
            DbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Thực hiện lấy tất cả dữ liệu từ 1 bảng
        /// </summary>
        /// <returns> Danh sách các dữ liệu dưới dạng được truyền vào (MISAEntity) </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public List<MISAEntity> GetAll()
        {
            // Xác định dạng dữ liệu được truyền vào
            var className = typeof(MISAEntity).Name;

            // Build chuỗi câu lệnh SQL: 
            var sqlCommand = $"SELECT * FROM {className}";

            // Kết nối và lấy dữ liệu từ Database:
            var entities = DbConnection.Query<MISAEntity>(sqlCommand).ToList();

            // Trả về dữ liệu:
            return entities;
        }

        /// <summary>
        /// Thực hiện lấy dữ liệu theo Id (entityId)
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns> Dữ liệu dưới dạng được tryền vào (MISAEntity) </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public MISAEntity GetById(Guid entityId)
        {
            // Xác định dạng dữ liệu được truyền vào
            var className = typeof(MISAEntity).Name;

            // Build chuỗi câu lệnh SQL: 
            var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";

            // Tạo các tham số cần thiết cho câu lệnh truy vấn
            DynamicParameters parameters = new();
            parameters.Add($"@{className}Id", entityId);

            // Kết nối và lấy dữ liệu từ Database:
            var entity = DbConnection.QueryFirstOrDefault<MISAEntity>(sql: sqlCommand, param: parameters);

            // Trả về dữ liệu:
            return entity;
        }

        /// <summary>
        /// Thêm mới dữ liệu vào database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        public int DeleteById(Guid entityId)
        {
            // Xác định dạng dữ liệu được truyền vào
            var className = typeof(MISAEntity).Name;

            // Build chuỗi câu lệnh SQL: 
            var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";

            // Tạo các tham số cần thiết cho câu lệnh truy vấn
            DynamicParameters parameters = new();
            parameters.Add($"@{className}Id", entityId);

            // Kết nối và lấy dữ liệu từ Database:
            var rowAffected = DbConnection.Execute(sql: sqlCommand, param: parameters);

            // Trả về dữ liệu:
            return rowAffected;
        }

        /// <summary>
        /// Thêm mới dữ liệu vào database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (05/08/2021)
        public int Post(MISAEntity entity)
        {
            // Xác định class của tham số entity
            var className = entity.GetType().Name;

            // Sinh mới Id cho entity:
            entity.GetType().GetProperty($"{className}Id").SetValue(entity, Guid.NewGuid());

            // Lấy các thông tin của entity:
            var columnsCmdTxt = string.Empty;
            var paramsCmdTxt = string.Empty;
            DynamicParameters parameters = new();
            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                // Lấy tên của prop:
                var propName = prop.Name;
                columnsCmdTxt += propName + ",";

                // Lấy value của prop:   
                var propValue = prop.GetValue(entity);
                paramsCmdTxt += $"@{propName}" + ",";
                parameters.Add($"@{propName}", propValue);
            }

            // Khai báo câu lệnh thực hiện thêm mới dữ liệu:
            columnsCmdTxt = columnsCmdTxt.Remove(columnsCmdTxt.Count() - 1);
            paramsCmdTxt = paramsCmdTxt.Remove(paramsCmdTxt.Count() - 1);
            var sqlCommand = $"INSERT INTO {className} ({columnsCmdTxt}) VALUE ({paramsCmdTxt})";

            // Thực hiện câu lệnh thêm dữ liệu
            var rowAffected = DbConnection.Execute(sqlCommand, param: parameters, commandType: CommandType.Text);
            return rowAffected;
        }

        /// <summary>
        /// Kiểm tra mã trùng lặp với dữ liệu có sẵn
        /// </summary>
        /// <param name="entityCode"> Mã nhân viên cần kiểm tra</param>
        /// <returns> Boolean - Có bị trùng hay không </returns>
        /// CreatedBy: TXHMinh (05/08/2021)
        public bool CheckDuplicate(string value, string propName)
        {
            // Truy cập Database check xem mã nhân viên đã có hay chưa;
            // Khai báo câu lệnh truy vấn dữ liệu
            var className = typeof(MISAEntity).Name;
            var sqlCommand = $"SELECT {className}Code FROM {className} WHERE {propName} = @{propName}";

            // Tạo parameters cho câu lệnh truy vấn
            DynamicParameters parameters = new();
            parameters.Add($"@{propName}", value);

            // Thực hiện truy vấn dữ liệu kiểm tra
            var obj = DbConnection.QueryFirstOrDefault<object>(sql: sqlCommand, param: parameters);

            //Trả về: true - nếu mã nhân viên bị trùng, false - nếu không
            return (obj != null);
        }

        /// <summary>
        /// Phương thức trả về phân trang
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //public object GetPaging()
        //{
        //    var totalRecord = 0;
        //    var totalPage = 0;
        //    DynamicParameters parameters = new();
        //    parameters.Add("@TotalRecord", direction: System.Data.ParameterDirection.Output);
        //    parameters.Add("@TotalPage", direction: System.Data.ParameterDirection.Output);
        //    parameters.Add("@EmployeeFilter", "");
        //    parameters.Add("@DepartmentId", null);
        //    parameters.Add("@PositionId", null);
        //    parameters.Add("@PageIndex", 1);
        //    parameters.Add("@@PageSize", 10);
        //    var storeName = "Proc_GetEmployeesFilterPaging";
        //    var employees = DbConnection.Query<object>(storeName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //    totalRecord = parameters.Get<int>("@TotalRecord");
        //    totalPage = parameters.Get<int>("@TotalPage");
        //    var obj = new
        //    {
        //        Data = employees,
        //        TotalPage = totalPage,
        //        TotalRecord = totalRecord
        //    };
        //    return obj;
        //}
        #endregion
    }
}
