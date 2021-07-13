using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Area;
using api.Models.Area.Interfaces;
using api.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly ILogger<AreaController> _logger;
        private readonly IArea Interfaces;
        public AreaController(ILogger<AreaController> logger, IArea interfaces)
        {
            _logger = logger;
            Interfaces = interfaces;
        }
        [HttpPost("get-data")]
        public DatabaseActionResultModel GetData(AreaParamModel paramModel)
        {
            try
            {
                return Interfaces.AreaGetData(paramModel);
            }
            catch (Exception ex)
            {
                return new DatabaseActionResultModel()
                {
                    Success = false,
                    Kode = "99",
                    Message = ex.Message.ToString()
                };
            }
        }
        [HttpPost("provinsi/get-data")]
        public DatabaseActionResultModel ProvinsiGetData(AreaParamModel paramModel)
        {
            try
            {
                return Interfaces.ProvinsiGetData(paramModel);
            }
            catch (Exception ex)
            {
                return new DatabaseActionResultModel()
                {
                    Success = false,
                    Kode = "99",
                    Message = ex.Message.ToString()
                };
            }
        }
        [HttpPost("kota/get-data")]
        public DatabaseActionResultModel KotaGetData(AreaParamModel paramModel)
        {
            try
            {
                return Interfaces.KotaGetData(paramModel);
            }
            catch (Exception ex)
            {
                return new DatabaseActionResultModel()
                {
                    Success = false,
                    Kode = "99",
                    Message = ex.Message.ToString()
                };
            }
        }
        [HttpPost("kecamatan/get-data")]
        public DatabaseActionResultModel KecamatanGetData(AreaParamModel paramModel)
        {
            try
            {
                return Interfaces.KecamatanGetData(paramModel);
            }
            catch (Exception ex)
            {
                return new DatabaseActionResultModel()
                {
                    Success = false,
                    Kode = "99",
                    Message = ex.Message.ToString()
                };
            }
        }
        [HttpPost("kelurahan/get-data")]
        public DatabaseActionResultModel KelurahanGetData(AreaParamModel paramModel)
        {
            try
            {
                return Interfaces.KelurahanGetData(paramModel);
            }
            catch (Exception ex)
            {
                return new DatabaseActionResultModel()
                {
                    Success = false,
                    Kode = "99",
                    Message = ex.Message.ToString()
                };
            }
        }
    }
}
