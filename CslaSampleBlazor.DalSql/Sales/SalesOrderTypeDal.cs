
using Csla.Configuration;
using Csla.Data.SqlClient;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Csla.Data;

namespace CslaSampleBlazor.DalSql.Sales
{
    public class SalesOrderTypeDal : ISalesOrderTypeDal
    {

        private ConnectionManager<SqlConnection> conn;

        public SalesOrderTypeDal(ConnectionManager<SqlConnection> connection)
        {
            conn = connection;
        }

        public List<SalesOrderTypeDto> FetchList()
        {
            List<SalesOrderTypeDto> list = new List<SalesOrderTypeDto>();
            using (conn)
            {
                using (var cm = (SqlCommand)conn.Connection.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spsoSalesOrderTypeListSelect";
                    Trace.WriteLine("Connection in SalesOrderTypeDal: " + cm.Connection.ClientConnectionId);
                    using (SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader()))
                    {
                        while (data.Read())
                        {
                            var dto = LoadDto(data);
                            list.Add(dto);
                        }
                    }
                }

            }

            return list;
        }

        public SalesOrderTypeDto Fetch(int salesOrderTypeKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spsoSalesOrderTypeSelect";
                    cm.Parameters.AddWithValue("@SalesOrderTypeKey", salesOrderTypeKey);
                    var data = new SafeSqlDataReader(cm.ExecuteReader());
                    if (!data.SqlDataReader.HasRows)
                        throw new DataNotFoundException("SalesOrderType");
                    data.Read();
                    return LoadDto(data);
                }

            }
        }

        public DalReturn Insert(int createdByUserKey,
                                string name,
                                string salesOrderTypeId,
                                Int16 salesOrderTypeValue)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spsoSalesOrderTypeInsert";
                    cm.Parameters.AddWithValue("@CreatedByUserKey", createdByUserKey);
                    cm.Parameters.AddWithValue("@Name", name);
                    cm.Parameters.AddWithValue("@SalesOrderTypeId", salesOrderTypeId);
                    cm.Parameters.AddWithValue("@SalesOrderTypeValue", salesOrderTypeValue);
                    cm.Parameters.Add("@NewSalesOrderTypeKey", SqlDbType.Int);
                    cm.Parameters["@NewSalesOrderTypeKey"].Direction = ParameterDirection.Output;
                    cm.Parameters.Add("@NewLastChanged", SqlDbType.Timestamp);
                    cm.Parameters["@NewLastChanged"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();

                    return new DalReturn() { Key = (int)cm.Parameters["@NewSalesOrderTypeKey"].Value, LastChanged = (byte[])cm.Parameters["@NewLastChanged"].Value };
                }                   
            }
        }
        public DalReturn Update(int salesOrderTypeKey,
                                byte[] lastChanged,
                                int modifiedByUserKey,
                                string name,
                                string salesOrderTypeId,
                                Int16 salesOrderTypeValue)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spsoSalesOrderTypeUpdate";
                    cm.Parameters.AddWithValue("@SalesOrderTypeKey", salesOrderTypeKey);
                    cm.Parameters.AddWithValue("@ModifiedByUserKey", modifiedByUserKey);
                    cm.Parameters.AddWithValue("@Name", name);
                    cm.Parameters.AddWithValue("@SalesOrderTypeId", salesOrderTypeId);
                    cm.Parameters.AddWithValue("@SalesOrderTypeValue", salesOrderTypeValue);
                    cm.Parameters.AddWithValue("@LastChanged", lastChanged);
                    cm.Parameters.Add("@NewLastChanged", SqlDbType.Timestamp);
                    cm.Parameters["@NewLastChanged"].Direction = ParameterDirection.Output;

                    try
                    {
                        cm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new ConcurrencyException(ex.Message);
                    }

                    return new DalReturn() { LastChanged = (byte[])cm.Parameters["@NewLastChanged"].Value };
                }
                    
            }
        }

        public void Delete(int salesOrderTypeKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spsoSalesOrderTypeDelete";
                    cm.Parameters.AddWithValue("@SalesOrderTypeKey", salesOrderTypeKey);
                    cm.ExecuteNonQuery();
                }
                    
            }
        }

        public bool Exists(string salesOrderTypeId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = "SELECT SalesOrderTypeKey FROM dbo.tsoSalesOrderType WHERE SalesOrderTypeId=@SalesOrderTypeId";
                    cm.Parameters.AddWithValue("@SalesOrderTypeId", salesOrderTypeId);
                    var result = cm.ExecuteReader();
                    return result.Read();
                }

            }
        }

        public int GetKey(string salesOrderTypeId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = "SELECT SalesOrderTypeKey FROM dbo.tsoSalesOrderType WHERE SalesOrderTypeId=@SalesOrderTypeId";
                    cm.Parameters.AddWithValue("@SalesOrderTypeId", salesOrderTypeId);
                    var result = cm.ExecuteReader();
                    if (result.HasRows == false)
                        throw new DataNotFoundException("SalesOrderType");
                    result.Read();
                    return result.GetInt32(0);
                }                  
            }
        }

        private SalesOrderTypeDto LoadDto(SafeSqlDataReader data)
        {
            SalesOrderTypeDto dto = new SalesOrderTypeDto()
            {
                SalesOrderTypeKey = data.GetInt32("SalesOrderTypeKey"),
                CreatedByUserId = data.GetString("CreatedByUserId"),
                CreatedByUserKey = data.GetInt32("CreatedByUserKey"),
                CreatedOnDate = data.GetDateTime("CreatedOnDate"),
                LastChanged = (byte[])data.GetValue("LastChanged"),
                ModifiedByUserId = data.GetString("ModifiedByUserId"),
                ModifiedByUserKey = data.GetInt32("ModifiedByUserKey"),
                ModifiedOnDate = data.GetDateTime("ModifiedOnDate"),
                Name = data.GetString("Name"),
                SalesOrderTypeId = data.GetString("SalesOrderTypeId"),
                SalesOrderTypeValue = data.GetInt16("SalesOrderTypeValue")
            };
            return dto;
        }
    }
}