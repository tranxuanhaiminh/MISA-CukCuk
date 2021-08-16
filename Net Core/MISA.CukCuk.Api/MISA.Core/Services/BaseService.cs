using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MISA.Core.Const;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Services;
using MISA.Core.Properties;

namespace MISA.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Fields
        IBaseRepository<MISAEntity> _baseRepository;
        public ServiceResult ServiceResult;
        #endregion

        #region Contructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            ServiceResult = new ServiceResult();
        }
        #endregion

        #region Methods
        public virtual ServiceResult Post(MISAEntity entity)
        {
            // Thực hiện validate dữ liệu:
            ServiceResult = ValidateData(entity);
            if (ServiceResult.Success)
            {
                int rowAffected = _baseRepository.Post(entity);
                ServiceResult.Data = rowAffected;
                return ServiceResult;
            }
            else
            {
                return ServiceResult;
            }
        }

        private ServiceResult ValidateData(MISAEntity entity)
        {
            // Validate chung
            // 1. check đã có mã hay chưa:

            var properties = entity.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var propRequired = prop.GetCustomAttributes(typeof(MISARequired), true);
                var propDisplayName = prop.GetCustomAttributes(typeof(MISADisplayName), true);
                var propCheckDuplicate = prop.GetCustomAttributes(typeof(MISADuplicate), true);

                var displayName = string.Empty;
                if (propDisplayName.Length > 0)
                {
                    displayName = (propDisplayName[0] as MISADisplayName).PropertyName;
                }

                if (propRequired.Length > 0)
                {
                    var propValue = prop.GetValue(entity);
                    var propName = prop.Name;
                    displayName = (displayName == string.Empty ? propName : displayName);
                    if (string.IsNullOrEmpty(propValue.ToString()))
                    {
                        ServiceResult.Success = false;
                        ServiceResult.UserMsg = $"Thông tin {displayName} không được phép để trống";
                        ServiceResult.Data = displayName;
                        return ServiceResult;

                    }
                }

                if (propCheckDuplicate.Length > 0)
                {
                    var propValue = prop.GetValue(entity);
                    var propName = prop.Name;
                    var isDuplicate = _baseRepository.CheckDuplicate(propValue.ToString(), propName);
                    if (isDuplicate == true)
                    {
                        ServiceResult.Success = false;
                        ServiceResult.UserMsg = $"Thông tin {propName} đã tồn tại trên hệ thống";
                        ServiceResult.Data = propName;
                        return ServiceResult;
                    }
                }
            }

            //
            var className = entity.GetType().Name;
            string entityCode = (string)entity.GetType().GetProperty($"{className}Code").GetValue(entity);
            if (string.IsNullOrEmpty(entityCode))
            {
                ServiceResult.Success = false;
                ServiceResult.MISACode = MISAConst.MISAErrorEmptyCode;
                ServiceResult.UserMsg = Resources.ValidateError_FieldEmpty;
                return ServiceResult;
            }

            // 2. Check trùng mã:
            //if (_baseRepository.CheckDuplicateEntityCode(entityCode))
            //{
            //    ServiceResult.Success = false;
            //    ServiceResult.MISACode = MISAConst.MISAErrorDuplicateCode;
            //    ServiceResult.UserMsg = Resources.ValidateError_CodeExists;
            //    return ServiceResult;
            //}

            // Validate riêng
            if (ServiceResult.Success)
                ServiceResult = ValidateCustom(entity);
            return ServiceResult;
        }

        protected virtual ServiceResult ValidateCustom(MISAEntity entity)
        {
            ServiceResult.Success = true;
            // Check các thông tin bắt buộc nhập:

            return ServiceResult;
        }
        #endregion
    }
}
