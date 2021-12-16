using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Abstract;


namespace Core.Concrete
{
   public class OrmRepositoryBase<ET> : IOrmRepository<ET>
   where ET : class, new()
    {
        public Type ETType
        {
            get
            {
                return typeof(ET);
            }
        }
        public Table TableAttribute
        {
            get
            {
                var attributes = ETType.GetCustomAttributes(typeof(Table), false);
                if (attributes != null && attributes.Any())
                {
                    Table tbl = (Table)attributes[0];
                    return tbl;
                }

                return null;
            }
        }

        public List<ET> GetAll()
        {
            string query = $"Select * from ";
            var attributes = ETType.GetCustomAttributes(typeof(Table), false);
            //Any() => Herhangi bir data var is True döner 
            //null değil ise ve kayıt var ise

            if (attributes != null && attributes.Any())
            {
                Table tbl = (Table)attributes[0];
                query += tbl.TableName + ";"; // Table attribute tablosundaki ilk eleman TableName 
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = new SqlCommand();

            Tools.DbConnection();

            dataAdapter.SelectCommand.CommandText = query;
            dataAdapter.SelectCommand.Connection = Tools._connection; // connection static Tools  sınıfından geldi

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable); // gelen veriyi dt ye doldurduk

            Tools.DbDisconnection();

            return dataTable.ToList<ET>(); // burada tools sınıfında tanımlayıp DataTable'a bind ettiğimiz 
            // yani bağladığımız metodu. DataTable nesnesi aracılığıyla kullandık.
        }
        public bool Add(ET entity)
        {
            PropertyInfo[] properties = ETType.GetProperties();

            string props = "";
            string values = "";

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name != TableAttribute.IdentityColum)
                {
                    if (properties[i].PropertyType.Name.Contains("String") || properties[i].PropertyType.Name.Contains("Char") || properties[i].PropertyType.Name.Contains("Byte[]"))
                    {
                        props += properties[i].Name + ",";
                        values += string.Format($"'{properties[i].GetValue(entity)}',");
                    }
                    else
                    {
                        props += properties[i].Name + ",";
                        values += string.Format($"'{properties[i].GetValue(entity)}',");
                    }

                }
            }

            values = values.Remove(values.Length - 1);
            props = props.Remove(props.Length - 1);

            string query = $"Insert Into {TableAttribute.TableName} ({props}) VALUES ({values});";

            Tools.DbConnection();

            SqlCommand command = new SqlCommand(query, Tools._connection);

            int effectedRows = command.ExecuteNonQuery();

            Tools.DbDisconnection();

            if (effectedRows > 0)
            {
                Console.WriteLine("Eklendi");
                return true;
            }
            return false;

        }
        public bool Update(ET entity)
        {
            PropertyInfo[] properties = ETType.GetProperties();

            string updateValues = "";
            int whereId = 0;

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name != TableAttribute.IdentityColum)
                {
                    if (properties[i].PropertyType.Name.Contains("String") || properties[i].PropertyType.Name.Contains("Char") || properties[i].PropertyType.Name.Contains("Byte[]"))
                    {
                        updateValues += string.Format($"{properties[i].Name} = '{properties[i].GetValue(entity)}',");
                    }
                    else
                    {
                        updateValues += string.Format($"{properties[i].Name} = {properties[i].GetValue(entity)},");
                    }
                }
                else
                {
                    whereId = (int)properties[i].GetValue(entity)!;
                }
            }

            updateValues = updateValues.Remove(updateValues.Length - 1);

            string query =
                $"Update {TableAttribute.TableName} SET {updateValues} Where {TableAttribute.IdentityColum} = {whereId};";

            Tools.DbConnection();

            SqlCommand command = new SqlCommand(query, Tools._connection);

            int effectedRows = command.ExecuteNonQuery();

            Tools.DbDisconnection();

            if (effectedRows <= 0) return false;
            Console.WriteLine("Güncellendi");
            return true;

        }

        public bool Delete(ET entity)
        {
            PropertyInfo[] properties = ETType.GetProperties();

            int deletedID = 0;

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name == TableAttribute.IdentityColum)
                {
                    deletedID = (int)properties[i].GetValue(entity)!;
                }
            }

            string query =
                $"DELETE FROM {TableAttribute.TableName} WHERE {TableAttribute.IdentityColum} = {deletedID};";

            Tools.DbConnection();

            SqlCommand command = new SqlCommand(query, Tools._connection);

            int effectedRows = command.ExecuteNonQuery();

            Tools.DbDisconnection();

            if (effectedRows > 0)
            {
                Console.WriteLine("Silindi");
                return true;
            }
            return false;
        }

        public ET Get(int id)
        {
            PropertyInfo[] properties = ETType.GetProperties();

            string query = $"Select * FROM {TableAttribute.TableName} WHERE {TableAttribute.IdentityColum} = {id};";

            Tools.DbConnection();

            SqlCommand command = new SqlCommand(query, Tools._connection);

            SqlDataReader reader = command.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            Tools.DbDisconnection();

            return dataTable.ToEt<ET>();
        }
    }
}
