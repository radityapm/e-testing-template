using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Status.Interfaces
{
    public interface IStatus
    {
        DatabaseActionResultModel GetData(StatusModel paramModel);
        DatabaseActionResultModel SaveData(StatusModel paramModel);
        DatabaseActionResultModel EditData(StatusModel paramModel);
        DatabaseActionResultModel DeleteData(StatusModel paramModel);
    }
}
