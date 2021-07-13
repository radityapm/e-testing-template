using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Base;
using api.Models.Divisi;
using api.Models.Divisi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisiController : ControllerBase
    {
        private readonly ILogger<DivisiController> _logger;
        private readonly IDivisi Interfaces;
        public DivisiController(ILogger<DivisiController> logger, IDivisi interfaces)
        {
            _logger = logger;
            Interfaces = interfaces;
        }
        [HttpPost("get-data")]
        public DatabaseActionResultModel GetData(DivisiModel paramModel)
        {
            try
            {
                return Interfaces.GetData(paramModel);
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
        [HttpPost("save-data")]
        public DatabaseActionResultModel SaveData(DivisiModel paramModel)
        {
            try
            {
                return Interfaces.SaveData(paramModel);
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
        [HttpPost("edit-data")]
        public DatabaseActionResultModel EditData(DivisiModel paramModel)
        {
            try
            {
                return Interfaces.EditData(paramModel);
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
        [HttpPost("delete-data")]
        public DatabaseActionResultModel DeleteData(DivisiModel paramModel)
        {
            try
            {
                return Interfaces.DeleteData(paramModel);
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
