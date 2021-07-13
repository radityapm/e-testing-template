using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Base;
using CargoV3API.Models.Users;
using CargoV3API.Models.Users.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft;

namespace CargoV3API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
       {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<UserController> _logger;
        private readonly IUser _iUser;
        public UserController(ILogger<UserController> logger, IUser iUser)
        {
            _logger = logger;
            _iUser = iUser;
        }
        [HttpGet("get-data")]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpPost("get-data")]
        public DatabaseActionResultModel GetData(UserParamModel paramModel)
        {
            try
            {
                return _iUser.GetData(paramModel);
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
        public DatabaseActionResultModel SaveData(UserModel paramModel)
        {
            try
            {
                return _iUser.SaveData(paramModel);
            }
            catch (Exception ex)
            {
                return new DatabaseActionResultModel()
                {
                    Success = false,
                    Kode =  "99",
                    Message = ex.Message.ToString()
                    
                };
            }
        }
        [HttpPost("edit-data")]
        public DatabaseActionResultModel EditData(UserModel paramModel)
        {
            try
            {
                return _iUser.EditData(paramModel);
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
        public DatabaseActionResultModel DeleteData(UserParamModel paramModel)
        {
            try
            {
                return _iUser.DeleteData(paramModel);
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
