using api.Models.Base;
using api.Models.Profile.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Profile.DALS
{
    public class ProfileDAL :IProfile
    {
        private readonly string ConnectionString;
        private readonly int ConnectionTimeOut;
        public ProfileDAL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UserConnection");
            ConnectionTimeOut = Convert.ToInt32(configuration.GetConnectionString("TimeOutConnection"));
        }
        public DatabaseActionResultModel GetData(ProfileModel paramModel)
        {
            List<ProfileModel> Result = new List<ProfileModel>();
            int RecordsTotal = GetDataCount(paramModel);
            if (RecordsTotal == 0)
            {
                return new DatabaseActionResultModel()
                {
                    Kode = RecordsTotal.ToString(),
                    RecordsTotal = RecordsTotal,
                    Success = true,
                    Message = "Data tidak tersedia"
                };
            }

            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Profile_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.Id))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileID", Convert.ToInt32(paramModel.Id));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Name))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileName", paramModel.Name.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileName", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Arg.keyword))
                    {
                        sqlCommand.Parameters.AddWithValue("@Keyword", paramModel.Arg.keyword.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Keyword", DBNull.Value);
                    }
                    if (paramModel.Arg.firstLimit != null)
                    {
                        sqlCommand.Parameters.AddWithValue("@FirstLimit", paramModel.Arg.firstLimit);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@FirstLimit", 0);
                    }
                    if (paramModel.Arg.lastLimit != null)
                    {
                        sqlCommand.Parameters.AddWithValue("@LastLimit", paramModel.Arg.lastLimit);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@LastLimit", 0);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Arg.sortType))
                    {
                        sqlCommand.Parameters.AddWithValue("@SortType", paramModel.Arg.sortType);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@SortType", "asc");
                    }
                    if (paramModel.Arg.sortIndex != null)
                    {
                        sqlCommand.Parameters.AddWithValue("@SortIndex", paramModel.Arg.sortIndex);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@SortIndex", 0);
                    }
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Add(new ProfileModel()
                            {
                                Id = dataReader["ProfileId"].ToString(),
                                Name = dataReader["ProfileName"].ToString(),
                                UserEntry = dataReader["UserEntry"].ToString(),
                                DateEntry = Convert.ToDateTime(dataReader["DateEntry"]),
                                UserUpdate = string.IsNullOrEmpty(dataReader["UserUpdate"].ToString()) == true ? "" : dataReader["UserUpdate"].ToString(),
                                DateUpdate = string.IsNullOrEmpty(dataReader["DateUpdate"].ToString()) == true ? DateTime.Now.AddYears(-100) : Convert.ToDateTime(dataReader["DateUpdate"]),
                                IsActive = Convert.ToBoolean(dataReader["IsActive"]),
                                IsDelete = Convert.ToBoolean(dataReader["IsDelete"])
                            });
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new DatabaseActionResultModel()
            {
                Data = Result,
                RecordsTotal = RecordsTotal,
                Success = true
            };
        }
        public int GetDataCount(ProfileModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Profile_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.Id))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileID", Convert.ToInt32(paramModel.Id));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Name))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileName", paramModel.Name.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProfileName", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Arg.keyword))
                    {
                        sqlCommand.Parameters.AddWithValue("@Keyword", paramModel.Arg.keyword.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Keyword", DBNull.Value);
                    }


                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result = (int)dataReader[0];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        public DatabaseActionResultModel SaveData(ProfileModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Profile_SaveData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProfileName", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry);
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Kode = dataReader["Kode"].ToString();
                            Result.Message = dataReader["Pesan"].ToString();
                            Result.Success = Result.Kode == "01" ? true : false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        public DatabaseActionResultModel EditData(ProfileModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Profile_EditData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProfileID", paramModel.Id.ToString());
                    sqlCommand.Parameters.AddWithValue("@ProfileName", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry);
                    sqlCommand.Parameters.AddWithValue("@IsActive", paramModel.IsActive);
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Kode = dataReader["Kode"].ToString();
                            Result.Message = dataReader["Pesan"].ToString();
                            Result.Success = Result.Kode == "01" ? true : false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        public DatabaseActionResultModel DeleteData(ProfileModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Profile_DeleteData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProfileID", paramModel.Id.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry);
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Kode = dataReader["Kode"].ToString();
                            Result.Message = dataReader["Pesan"].ToString();
                            Result.Success = Result.Kode == "01" ? true : false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
    }
}
