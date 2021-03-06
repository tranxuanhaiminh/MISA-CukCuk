using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySqlConnector;
using MISA.Common.Entity;

namespace MISA.DataAccess
{
    /// <summary>
    /// Tương tác với database
    /// </summary>
    /// CreatedBy: TXHMinh (28/07/2021)
    public class DbContext<MISAEntity> where MISAEntity : class
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
                "Password = 12345678";
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
        /// <param name="employee"></param>
        /// <returns> rowAffected - số dòng đã thêm vào database </returns>
        /// CreatedBy: TXHMinh (28/07/2021)
        //public int Post(MISAEntity entity)
        //{
            //// Xác định dạng dữ liệu được truyền vào
            //var className = typeof(MISAEntity).Name;

            //// Sinh mới Id cho Employee:
            //var entityId = Guid.NewGuid();


            //// Khai báo câu lệnh thực hiện thêm mới dữ liệu:
            //var sqlCommand = $"INSERT INTO " +
            //        $"Employee({className}Id, {className}Code, FullName)" +
            //        $"VALUE('{entityId.ToString()}', '{entity.EmployeeCode}', '{entity.FullName}')";

            //// Thực hiện câu lệnh thêm dữ liệu
            //var rowAffected = DbConnection.Execute(sqlCommand);
            //return rowAffected;



            //DynamicParameters parameters = new();
            //parameters.Add($"@{className}Id", entityId);
            //var rowAffects = DbConnection.QueryFirstOrDefault<MISAEntity>(sql: sqlCommand, param: parameters);

        //}
        #endregion
    }
}
