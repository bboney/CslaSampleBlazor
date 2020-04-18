
using Csla.Configuration;
using Csla.Data.SqlClient;
using CslaSampleBlazor.Dal;
using CslaSampleBlazor.Dal.Security;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Csla.Data;

namespace CslaSampleBlazor.DalSql.Security
{
    public class NavigationDal : INavigationDal
    {
        private ConnectionManager<SqlConnection> conn;

        public NavigationDal(ConnectionManager<SqlConnection> connection)
        {
            conn = connection;
        }

        public List<NavigationDto> FetchUserList(int navigationType, int userKey)
        {
            List<NavigationDto> list = new List<NavigationDto>();
            using (conn)
            {
                using (var cm = (SqlCommand)conn.Connection.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spseUserNavigationListSelect";
                    cm.Parameters.AddWithValue("@NavigationType", navigationType);
                    cm.Parameters.AddWithValue("@UserKey", userKey);
                    Trace.WriteLine("Connection in NavigationDal: " + cm.Connection.ClientConnectionId);
                    using (SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader()))
                    {
                        while (data.Read())
                        {
                            list.Add(LoadDto(data));
                        }
                    }
                }

            }
            return list;
        }

        public List<NavigationDto> FetchList()
        {
            List<NavigationDto> list = new List<NavigationDto>();
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spseNavigationListSelect";
                    Trace.WriteLine("Connection in NavigationDal: " + cm.Connection.ClientConnectionId);
                    using (SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader()))
                    {
                        while (data.Read())
                        {
                            list.Add(LoadDto(data));
                        }
                    }
                }

            }
            return list;

        }

        public NavigationDto Fetch(int navigationKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                using (var cm = (SqlCommand)cn.CreateCommand()) 
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spseNavigationSelect";
                    cm.Parameters.AddWithValue("@NavigationKey", navigationKey);
                    SafeSqlDataReader data = new SafeSqlDataReader(cm.ExecuteReader());
                    if (!data.SqlDataReader.HasRows)
                        throw new DataNotFoundException("Navigation");
                    data.Read();
                    return LoadDto(data);
                }
                    
            }
        }

        public DalReturn Insert(int createdByUserKey,
                                bool hasChildren,
                                bool isPrivilegeRequired,
                                string name,
                                string navigationId,
                                int navigationType,
                                int parentNavigationKey,
                                int sequence,
                                string spriteCssClass,
                                string url)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = (SqlCommand)cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spseNavigationInsert";
                cm.Parameters.AddWithValue("@CreatedByUserKey", createdByUserKey);
                cm.Parameters.AddWithValue("@HasChildren", hasChildren);
                cm.Parameters.AddWithValue("@IsPrivilegeRequired", isPrivilegeRequired);
                cm.Parameters.AddWithValue("@Name", name);
                cm.Parameters.AddWithValue("@NavigationId", navigationId);
                cm.Parameters.AddWithValue("@NavigationType", navigationType);
                cm.Parameters.AddWithValue("@ParentNavigationKey", parentNavigationKey);
                cm.Parameters.AddWithValue("@Sequence", sequence);
                cm.Parameters.AddWithValue("@SpriteCssClass", spriteCssClass);
                cm.Parameters.AddWithValue("@Url", url);
                cm.Parameters.Add("@NewNavigationKey", SqlDbType.Int);
                cm.Parameters["@NewNavigationKey"].Direction = ParameterDirection.Output;
                cm.Parameters.Add("@NewLastChanged", SqlDbType.Timestamp);
                cm.Parameters["@NewLastChanged"].Direction = ParameterDirection.Output;

                cm.ExecuteNonQuery();

                return new DalReturn() { Key = (int)cm.Parameters["@NewNavigationKey"].Value, LastChanged = (byte[])cm.Parameters["@NewLastChanged"].Value };
            }
        }
        public DalReturn Update(int navigationKey,
                                bool hasChildren,
                                bool isPrivilegeRequired,
                                byte[] lastChanged,
                                int modifiedByUserKey,
                                string name,
                                string navigationId,
                                int navigationType,
                                int parentNavigationKey,
                                int sequence,
                                string spriteCssClass,
                                string url)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = (SqlCommand)cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spseNavigationUpdate";
                cm.Parameters.AddWithValue("@NavigationKey", navigationKey);
                cm.Parameters.AddWithValue("@HasChildren", hasChildren);
                cm.Parameters.AddWithValue("@IsPrivilegeRequired", isPrivilegeRequired);
                cm.Parameters.AddWithValue("@ModifiedByUserKey", modifiedByUserKey);
                cm.Parameters.AddWithValue("@Name", name);
                cm.Parameters.AddWithValue("@NavigationId", navigationId);
                cm.Parameters.AddWithValue("@NavigationType", navigationType);
                cm.Parameters.AddWithValue("@ParentNavigationKey", parentNavigationKey);
                cm.Parameters.AddWithValue("@Sequence", sequence);
                cm.Parameters.AddWithValue("@SpriteCssClass", spriteCssClass);
                cm.Parameters.AddWithValue("@Url", url);
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

        public void Delete(int navigationKey)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = (SqlCommand)cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spseNavigationDelete";
                cm.Parameters.AddWithValue("@NavigationKey", navigationKey);
                cm.ExecuteNonQuery();
            }
        }

        public bool Exists(string navigationId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = (SqlCommand)cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT NavigationKey FROM dbo.tseNavigation WHERE NavigationId=@NavigationId";
                cm.Parameters.AddWithValue("@NavigationId", navigationId);
                var result = cm.ExecuteReader();
                return result.Read();
            }
        }

        public int GetKey(string navigationId)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CslaSampleBlazorDb"].ConnectionString))
            {
                cn.Open();
                var cm = (SqlCommand)cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "SELECT NavigationKey FROM dbo.tseNavigation WHERE NavigationId=@NavigationId";
                cm.Parameters.AddWithValue("@NavigationId", navigationId);
                var result = cm.ExecuteReader();
                if (result.HasRows == false)
                    throw new DataNotFoundException("Navigation");
                result.Read();
                return result.GetInt32(0);
            }
        }

        private NavigationDto LoadDto(SafeSqlDataReader data)
        {
            NavigationDto dto = new NavigationDto()
            {
                NavigationKey = data.GetInt32("NavigationKey"),

                CreatedByUserId = data.GetString("CreatedByUserId"),
                CreatedByUserKey = data.GetInt32("CreatedByUserKey"),
                CreatedOnDate = data.GetDateTime("CreatedOnDate"),
                HasChildren = data.GetBoolean("HasChildren"),
                IsPrivilegeRequired = data.GetBoolean("IsPrivilegeRequired"),
                LastChanged = (byte[])data.GetValue("LastChanged"),
                ModifiedByUserId = data.GetString("ModifiedByUserId"),
                ModifiedByUserKey = data.GetInt32("ModifiedByUserKey"),
                ModifiedOnDate = data.GetDateTime("ModifiedOnDate"),
                Name = data.GetString("Name"),
                NavigationId = data.GetString("NavigationId"),
                NavigationType = data.GetInt32("NavigationType"),
                ParentNavigationKey = (int?)data.GetValue("ParentNavigationKey"),
                Sequence = data.GetInt32("Sequence"),
                SpriteCssClass = data.GetString("SpriteCssClass"),
                Url = data.GetString("Url")
            };
            if (dto.ParentNavigationKey.HasValue && dto.ParentNavigationKey.Value == 0)
                dto.ParentNavigationKey = null;
            if (string.IsNullOrEmpty(dto.Url))
                dto.Url = null;
            return dto;
        }

    }
}