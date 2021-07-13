using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Profile.Interfaces
{
    public interface IProfile
    {
        DatabaseActionResultModel GetData(ProfileModel paramModel);
        DatabaseActionResultModel SaveData(ProfileModel paramModel);
        DatabaseActionResultModel EditData(ProfileModel paramModel);
        DatabaseActionResultModel DeleteData(ProfileModel paramModel);
    }
}
