using Csla.Configuration;
using Csla.Data.SqlClient;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace CslaSampleBlazor.DalSql.Common
{
    public class DivisionDal : IDivisionDal
    {

        public List<DivisionDto> FetchList()
        {
            List<DivisionDto> list = new List<DivisionDto>();
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spciDivisionListSelect";
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

        public DivisionDto Fetch(int divisionKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spciDivisionSelect";
                cm.Parameters.AddWithValue("@DivisionKey", divisionKey);
                using (SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader()))
                {
                    if (!data.SqlDataReader.HasRows)
                        throw new DataNotFoundException("Division");
                    data.Read();
                    return LoadDto(data);
                }
            }
        }

        public DalReturn Insert(int createdByUserKey,
            string divisionId,
            int divisionValue,
            string name)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spciDivisionInsert";
                cm.Parameters.AddWithValue("@CreatedByUserKey", createdByUserKey);
                cm.Parameters.AddWithValue("@DivisionId", divisionId);
                cm.Parameters.AddWithValue("@DivisionValue", divisionValue);
                cm.Parameters.AddWithValue("@Name", name);
                cm.Parameters.Add("@NewDivisionKey", SqlDbType.Int);
                cm.Parameters["@NewDivisionKey"].Direction = ParameterDirection.Output;
                cm.Parameters.Add("@NewLastChanged", SqlDbType.Timestamp);
                cm.Parameters["@NewLastChanged"].Direction = ParameterDirection.Output;

                cm.ExecuteNonQuery();

                return new DalReturn() { Key = (int)cm.Parameters["@NewDivisionKey"].Value, LastChanged = (byte[])cm.Parameters["@NewLastChanged"].Value };
            }
        }
        public DalReturn Update(int divisionKey,
            string divisionId,
            int divisionValue,
            byte[] lastChanged,
            int modifiedByUserKey,
            string name)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spciDivisionUpdate";
                cm.Parameters.AddWithValue("@DivisionKey", divisionKey);
                cm.Parameters.AddWithValue("@DivisionId", divisionId);
                cm.Parameters.AddWithValue("@DivisionValue", divisionValue);
                cm.Parameters.AddWithValue("@ModifiedByUserKey", modifiedByUserKey);
                cm.Parameters.AddWithValue("@Name", name);
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

        public void Delete(int divisionKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spciDivisionDelete";
                cm.Parameters.AddWithValue("@DivisionKey", divisionKey);
                cm.ExecuteNonQuery();
            }
        }

        public bool Exists(string divisionId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT DivisionKey FROM dbo.tciDivision WHERE DivisionId=@DivisionId";
                cm.Parameters.AddWithValue("@DivisionId", divisionId);
                var result = cm.ExecuteReader();
                return result.Read();
            }
        }

        public int GetKey(string divisionId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT DivisionKey FROM dbo.tciDivision WHERE DivisionId=@DivisionId";
                cm.Parameters.AddWithValue("@DivisionId", divisionId);
                var result = cm.ExecuteReader();
                if (result.HasRows == false)
                    throw new DataNotFoundException("Division");
                result.Read();
                return result.GetInt32(0);
            }
        }

        private DivisionDto LoadDto(SafeSqlDataReader data)
        {
            TimeZoneInfo currentUserTimeZoneInfo = DalHelpers.GetCurrentUserTimeZoneInfo();
            DivisionDto dto = new DivisionDto()
            {
                DivisionKey = data.GetInt32("DivisionKey"),
                CreatedByUserKey = data.GetInt32("CreatedByUserKey"),
                CreatedByUserId = data.GetString("CreatedByUserId"),
                CreatedOnDate = TimeZoneInfo.ConvertTimeFromUtc(data.GetSmartDate("CreatedOnDate"), currentUserTimeZoneInfo),
                DivisionId = data.GetString("DivisionId"),
                DivisionValue = data.GetInt32("DivisionValue"),
                ModifiedByUserKey = data.GetInt32("ModifiedByUserKey"),
                ModifiedByUserId = data.GetString("ModifiedByUserId"),
                ModifiedOnDate = TimeZoneInfo.ConvertTimeFromUtc(data.GetSmartDate("ModifiedOnDate"), currentUserTimeZoneInfo),
                Name = data.GetString("Name"),
            };
            return dto;
        }
    }
}