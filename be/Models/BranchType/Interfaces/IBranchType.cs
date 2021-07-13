using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.BranchType.Interfaces
{
    public interface IBranchType
    {
        DatabaseActionResultModel GetData(BranchTypeModel paramModel);
        DatabaseActionResultModel SaveData(BranchTypeModel paramModel);
        DatabaseActionResultModel EditData(BranchTypeModel paramModel);
        DatabaseActionResultModel DeleteData(BranchTypeModel paramModel);
    }
}
