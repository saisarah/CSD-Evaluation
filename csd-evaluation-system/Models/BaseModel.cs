using csd_evaluation_system.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csd_evaluation_system.Models
{
    public abstract class BaseModel : Database
    {
        abstract protected string[] columns { get; }

        public  DbObject First(string query, DbObject parameters)
        {
            var result = new DbObject();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    //Attach Parameters
                    if (parameters != null)
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                    //Fetch data
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            foreach (var column in columns)
                                result.Add(column, reader.GetValue(reader.GetOrdinal(column)));
                        else
                            throw new NotFoundException(query);
                    }
                }
            }
            return result;
        }

        public List<DbObject> Get(string query, DbObject parameters)
        {
            var result = new List<DbObject>();

            using (var conn = GetConnection())
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    //Attach Parameters
                    if (parameters != null)
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                    //Fetch data
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DbObject row = new DbObject();
                            foreach (var column in columns)
                                row.Add(column, reader.GetValue(reader.GetOrdinal(column)));
                            result.Add(row);
                        }
                    }
                }
            }
            return result;
        }
    }
}
