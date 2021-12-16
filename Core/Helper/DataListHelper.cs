using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;
using Core.Concrete;

namespace Core.Helper
{
    public class DataListHelper<T> : IDataHelper<T> where T : class, IDto, new()
    {
        public List<T> GetAllDto(string query)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand();

            dataAdapter.SelectCommand = new SqlCommand();
            Tools.DbConnection();
            dataAdapter.SelectCommand.CommandText = query;
            dataAdapter.SelectCommand.Connection = Tools._connection;

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            Tools.DbDisconnection();

            return dataTable.ToList<T>();
        }
    }
}
