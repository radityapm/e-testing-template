using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoV3API.Models.Users.Interfaces
{
    public interface IUser
    {
        DatabaseActionResultModel GetData(UserParamModel paramModel);
        DatabaseActionResultModel SaveData(UserModel paramModel);
        DatabaseActionResultModel EditData(UserModel paramModel);
        DatabaseActionResultModel DeleteData(UserParamModel paramModel);
    }
}
