using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace BookListRazor.Model
{
    public interface IDataService
    {
        Task<(bool, DataTable, string)> ExecuteCommandReader(string commands);
        Task<(bool, Int32, string)> ExecuteCommandNoneQuery(string commands);
        Task<(bool, Object, string)> ExecuteCommandScalar(string commands);
    }
}
