using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Base;
using api.Models.Team;
using api.Models.Team.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;
        private readonly ITeam Interfaces;
        public TeamController(ILogger<TeamController> logger, ITeam interfaces)
        {
            _logger = logger;
            Interfaces = interfaces;
        }
        [HttpPost("get-data")]
        public DatabaseActionResultModel GetData(TeamParamModel paramModel)
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
        public DatabaseActionResultModel SaveData(TeamModel paramModel)
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
        public DatabaseActionResultModel EditData(TeamModel paramModel)
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
        public DatabaseActionResultModel DeleteData(TeamModel paramModel)
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
