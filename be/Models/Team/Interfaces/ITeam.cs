using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Team.Interfaces
{
    public interface ITeam
    {
        DatabaseActionResultModel GetData(TeamParamModel paramModel);
        DatabaseActionResultModel SaveData(TeamModel paramModel);
        DatabaseActionResultModel EditData(TeamModel paramModel);
        DatabaseActionResultModel DeleteData(TeamModel paramModel);
    }
}
