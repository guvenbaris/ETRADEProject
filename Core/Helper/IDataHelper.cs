using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;

namespace Core.Helper
{
    public interface IDataHelper<T> where T : class ,IDto, new()
    {
        List<T> GetAllDto(string query);
    }
}
