using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Branch.Interfaces
{
    public interface IBranch
    {
        DatabaseActionResultModel GetData(BranchParamModel paramModel);
        DatabaseActionResultModel SaveData(BranchModel paramModel);
        DatabaseActionResultModel EditData(BranchModel paramModel);
        DatabaseActionResultModel DeleteData(BranchParamModel paramModel);
    }
}
