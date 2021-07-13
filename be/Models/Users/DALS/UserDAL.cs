using api.Models.Base;
using CargoV3API.Models.Users.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CargoV3API.Models.Users.DALS
{
    public class UserDAL: IUser
    {
        private readonly string ConnectionString;
        private readonly int ConnectionTimeOut;
        public UserDAL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UserConnection");
            ConnectionTimeOut = Convert.ToInt32(configuration.GetConnectionString("TimeOutConnection"));
        }
        public DatabaseActionResultModel GetData(UserParamModel paramModel)
        {
            List<UserModel> Result = new List<UserModel>();
            int RecordsTotal = GetDataCount(paramModel);
            if(RecordsTotal == 0)
            {
                return new DatabaseActionResultModel()
                {
                    Kode = RecordsTotal.ToString(),
                    RecordsTotal = RecordsTotal,
                    Success = true,
                    Message ="Data tidak tersedia"                    
                };
            }

            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("User_GetData", sqlConnection)) {                    
                    if (!string.IsNullOrEmpty(paramModel.UserName))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserName", paramModel.UserName.ToString());
                    }else
                    {
                        sqlCommand.Parameters.AddWithValue("@UserName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Password))
                    {
                        sqlCommand.Parameters.AddWithValue("@Password", paramModel.Password.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Password", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Profile))
                    {
                        sqlCommand.Parameters.AddWithValue("@Profile", paramModel.Profile.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Profile", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Branch))
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", paramModel.Branch.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Arg.keyword))
                    {
                        sqlCommand.Parameters.AddWithValue("@Keyword", paramModel.Arg.keyword.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Keyword", DBNull.Value);
                    }
                    if (paramModel.Arg.firstLimit != null )
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
                            Result.Add(new UserModel()
                            {
                                UserCode = dataReader["UserCode"].ToString(),
                                UserName = dataReader["UserName"].ToString(),
                                Password = dataReader["Password"].ToString(),
                                Name = dataReader["Name"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                ProfileID = dataReader["ProfileID"].ToString(),
                                ProfileName = dataReader["ProfileName"].ToString(),
                                BranchID = dataReader["BranchID"].ToString(),
                                BranchName = dataReader["BranchName"].ToString(),
                                BranchTypeID = dataReader["BranchTypeID"].ToString(),
                                BranchTypeName = dataReader["BranchTypeName"].ToString(),
                                Divisi = dataReader["Divisi"].ToString(),
                                Phone = dataReader["Phone"].ToString(),
                                DateEntry = Convert.ToDateTime(dataReader["DateEntry"]),
                                UserEntry = dataReader["UserEntry"].ToString(),
                                IsCustomer = Convert.ToBoolean(dataReader["IsCustomer"]),
                                IsLogin = Convert.ToBoolean(dataReader["IsLogin"]),
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
        public int GetDataCount(UserParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("User_GetCount", sqlConnection))
                {                    
                    if (!string.IsNullOrEmpty(paramModel.UserName))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserName", paramModel.UserName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@UserName", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Password))
                    {
                        sqlCommand.Parameters.AddWithValue("@Password", paramModel.Password.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Password", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Profile))
                    {
                        sqlCommand.Parameters.AddWithValue("@Profile", paramModel.Profile.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Profile", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Branch))
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", paramModel.Branch.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", DBNull.Value);
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
        public DatabaseActionResultModel SaveData(UserModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("User_SaveData", sqlConnection))
                {                    
                    sqlCommand.Parameters.AddWithValue("@UserName", paramModel.UserName.ToString());
                    sqlCommand.Parameters.AddWithValue("@Password", paramModel.Password.ToString());
                    sqlCommand.Parameters.AddWithValue("@Profile", paramModel.ProfileID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Branch", paramModel.BranchID.ToString());                    
                    sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", paramModel.Email.ToString());
                    sqlCommand.Parameters.AddWithValue("@Phone", paramModel.Phone.ToString());
                    sqlCommand.Parameters.AddWithValue("@Divisi", paramModel.Divisi.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry.ToString());
                    sqlCommand.Parameters.AddWithValue("@IsCustomer", paramModel.IsCustomer);
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
        public DatabaseActionResultModel EditData(UserModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("User_EditData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", paramModel.UserName.ToString());
                    sqlCommand.Parameters.AddWithValue("@Password", paramModel.Password.ToString());
                    sqlCommand.Parameters.AddWithValue("@Profile", paramModel.ProfileID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Branch", paramModel.BranchID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", paramModel.Email.ToString());
                    sqlCommand.Parameters.AddWithValue("@Phone", paramModel.Phone.ToString());
                    sqlCommand.Parameters.AddWithValue("@Divisi", paramModel.Divisi.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry.ToString());
                    sqlCommand.Parameters.AddWithValue("@IsCustomer", paramModel.IsCustomer);
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
        public DatabaseActionResultModel DeleteData(UserParamModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("User_DeleteData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@UserName", paramModel.UserName.ToString());
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
