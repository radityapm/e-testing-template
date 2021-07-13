using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Base;
using api.Models.Status;
using api.Models.Status.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatus Interfaces;
        public StatusController(ILogger<StatusController> logger, IStatus interfaces)
        {
            _logger = logger;
            Interfaces = interfaces;
        }
        [HttpPost("get-data")]
        public DatabaseActionResultModel GetData(StatusModel paramModel)
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
        public DatabaseActionResultModel SaveData(StatusModel paramModel)
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
        public DatabaseActionResultModel EditData(StatusModel paramModel)
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
        public DatabaseActionResultModel DeleteData(StatusModel paramModel)
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
