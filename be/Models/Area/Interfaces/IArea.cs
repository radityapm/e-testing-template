using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Area.Interfaces
{
    public interface IArea
    {
        DatabaseActionResultModel AreaGetData(AreaParamModel paramModel);
        DatabaseActionResultModel ProvinsiGetData(AreaParamModel paramModel);
        DatabaseActionResultModel KotaGetData(AreaParamModel paramModel);
        DatabaseActionResultModel KecamatanGetData(AreaParamModel paramModel);
        DatabaseActionResultModel KelurahanGetData(AreaParamModel paramModel);
    }
}
