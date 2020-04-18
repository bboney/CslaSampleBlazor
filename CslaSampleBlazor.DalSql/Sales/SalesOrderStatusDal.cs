
using Csla.Configuration;
using Csla.Data.SqlClient;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Sales;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CslaSampleBlazor.DalSql.Sales
{
    public class SalesOrderStatusDal : ISalesOrderStatusDal
    {
        public List<SalesOrderStatusDto> FetchList()
        {
            List<SalesOrderStatusDto> list = new List<SalesOrderStatusDto>();
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spsoSalesOrderStatusListSelect";
                using (SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader()))
                {
                    while (data.Read())
                    {
                        list.Add(LoadDto(data));
                    }
                }
            }
            return list;
        }

        public SalesOrderStatusDto Fetch(int salesOrderStatusKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spsoSalesOrderStatusSelect";
                cm.Parameters.AddWithValue("@SalesOrderStatusKey", salesOrderStatusKey);
                using (SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader()))
                {
                    if (!data.SqlDataReader.HasRows)
                        throw new DataNotFoundException("SalesOrderStatus");
                    data.Read();
                    return LoadDto(data);
                }
            }
        }

        public DalReturn Insert(int createdByUserKey,
            string name,
            string salesOrderStatusId,
            Int16 salesOrderStatusValue)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spsoSalesOrderStatusInsert";
                cm.Parameters.AddWithValue("@CreatedByUserKey", createdByUserKey);
                cm.Parameters.AddWithValue("@Name", name);
                cm.Parameters.AddWithValue("@SalesOrderStatusId", salesOrderStatusId);
                cm.Parameters.AddWithValue("@SalesOrderStatusValue", salesOrderStatusValue);
                cm.Parameters.Add("@NewSalesOrderStatusKey", SqlDbType.Int);
                cm.Parameters["@NewSalesOrderStatusKey"].Direction = ParameterDirection.Output;
                cm.Parameters.Add("@NewLastChanged", SqlDbType.Timestamp);
                cm.Parameters["@NewLastChanged"].Direction = ParameterDirection.Output;

                cm.ExecuteNonQuery();

                return new DalReturn() { Key = (int)cm.Parameters["@NewSalesOrderStatusKey"].Value, LastChanged = (byte[])cm.Parameters["@NewLastChanged"].Value };
            }
        }
        public DalReturn Update(int salesOrderStatusKey,
            byte[] lastChanged,
            int modifiedByUserKey,
            string name,
            string salesOrderStatusId,
            Int16 salesOrderStatusValue)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spsoSalesOrderStatusUpdate";
                cm.Parameters.AddWithValue("@SalesOrderStatusKey", salesOrderStatusKey);
                cm.Parameters.AddWithValue("@ModifiedByUserKey", modifiedByUserKey);
                cm.Parameters.AddWithValue("@Name", name);
                cm.Parameters.AddWithValue("@SalesOrderStatusId", salesOrderStatusId);
                cm.Parameters.AddWithValue("@SalesOrderStatusValue", salesOrderStatusValue);
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

        public void Delete(int salesOrderStatusKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spsoSalesOrderStatusDelete";
                cm.Parameters.AddWithValue("@SalesOrderStatusKey", salesOrderStatusKey);
                cm.ExecuteNonQuery();
            }
        }

        public bool Exists(string salesOrderStatusId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT SalesOrderStatusKey FROM dbo.tsoSalesOrderStatus WHERE SalesOrderStatusId=@SalesOrderStatusId";
                cm.Parameters.AddWithValue("@SalesOrderStatusId", salesOrderStatusId);
                var result = cm.ExecuteReader();
                return result.Read();
            }
        }

        public int GetKey(string salesOrderStatusId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT SalesOrderStatusKey FROM dbo.tsoSalesOrderStatus WHERE SalesOrderStatusId=@SalesOrderStatusId";
                cm.Parameters.AddWithValue("@SalesOrderStatusId", salesOrderStatusId);
                var result = cm.ExecuteReader();
                if (result.HasRows == false)
                    throw new DataNotFoundException("SalesOrderStatus");
                result.Read();
                return result.GetInt32(0);
            }
        }

        private SalesOrderStatusDto LoadDto(SafeSqlDataReader data)
        {
            TimeZoneInfo currentUserTimeZoneInfo = DalHelpers.GetCurrentUserTimeZoneInfo();
            SalesOrderStatusDto dto = new SalesOrderStatusDto()
            {
                SalesOrderStatusKey = data.GetInt32("SalesOrderStatusKey"),
                CreatedByUserKey = data.GetInt32("CreatedByUserKey"),
                CreatedByUserId = data.GetString("CreatedByUserId"),
                CreatedOnDate = TimeZoneInfo.ConvertTimeFromUtc(data.GetSmartDate("CreatedOnDate"), currentUserTimeZoneInfo),
                ModifiedByUserKey = data.GetInt32("ModifiedByUserKey"),
                ModifiedByUserId = data.GetString("ModifiedByUserId"),
                ModifiedOnDate = TimeZoneInfo.ConvertTimeFromUtc(data.GetSmartDate("ModifiedOnDate"), currentUserTimeZoneInfo),
                Name = data.GetString("Name"),
                SalesOrderStatusId = data.GetString("SalesOrderStatusId"),
                SalesOrderStatusValue = data.GetInt16("SalesOrderStatusValue"),
            };
            return dto;
        }

    }
}