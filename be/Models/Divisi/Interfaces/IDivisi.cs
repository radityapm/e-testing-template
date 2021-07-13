using api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Divisi.Interfaces
{
    public interface IDivisi
    {
        DatabaseActionResultModel GetData(DivisiModel paramModel);
        DatabaseActionResultModel SaveData(DivisiModel paramModel);
        DatabaseActionResultModel EditData(DivisiModel paramModel);
        DatabaseActionResultModel DeleteData(DivisiModel paramModel);
    }

}
