using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Base;
using api.Models.BranchType;
using api.Models.BranchType.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchTypeController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IBranchType iBranchType;
        public BranchTypeController(ILogger<BranchController> logger, IBranchType ibranchType)
        {
            _logger = logger;
            iBranchType = ibranchType;
        }
        [HttpPost("get-data")]
        public DatabaseActionResultModel GetData(BranchTypeModel paramModel)
        {
            try
            {
                return iBranchType.GetData(paramModel);
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
        public DatabaseActionResultModel SaveData(BranchTypeModel paramModel)
        {
            try
            {
                return iBranchType.SaveData(paramModel);
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
        public DatabaseActionResultModel EditData(BranchTypeModel paramModel)
        {
            try
            {
                return iBranchType.EditData(paramModel);
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
        public DatabaseActionResultModel DeleteData(BranchTypeModel paramModel)
        {
            try
            {
                return iBranchType.DeleteData(paramModel);
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
