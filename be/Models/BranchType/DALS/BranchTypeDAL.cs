using api.Models.Base;
using api.Models.BranchType.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.BranchType.DALS
{
    public class BranchTypeDAL :IBranchType
    {
        private readonly string ConnectionString;
        private readonly int ConnectionTimeOut;
        public BranchTypeDAL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UserConnection");
            ConnectionTimeOut = Convert.ToInt32(configuration.GetConnectionString("TimeOutConnection"));
        }
        public DatabaseActionResultModel GetData(BranchTypeModel paramModel)
        {
            List<BranchTypeModel> Result = new List<BranchTypeModel>();
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
                using (SqlCommand sqlCommand = new SqlCommand("BranchType_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.Id))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(paramModel.Id));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Name))
                    {
                        sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Name", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Description))
                    {
                        sqlCommand.Parameters.AddWithValue("@Description", paramModel.Description.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Description", DBNull.Value);
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
                            Result.Add(new BranchTypeModel()
                            {
                                Id = dataReader["Id"].ToString(),
                                Name = dataReader["Name"].ToString(),
                                Description = dataReader["Description"].ToString(),                                
                                UserEntry = dataReader["UserEntry"].ToString(),
                                DateEntry = Convert.ToDateTime(dataReader["DateEntry"]),
                                UserUpdate = string.IsNullOrEmpty(dataReader["UserUpdate"].ToString()) == true ? "": dataReader["UserUpdate"].ToString(),
                                DateUpdate = string.IsNullOrEmpty(dataReader["DateUpdate"].ToString()) ==  true ? DateTime.Now.AddYears(-100) :Convert.ToDateTime(dataReader["DateUpdate"]),
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
        public int GetDataCount(BranchTypeModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("BranchType_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.Id))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", Convert.ToInt32(paramModel.Id));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Name))
                    {
                        sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Name", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Description))
                    {
                        sqlCommand.Parameters.AddWithValue("@Description", paramModel.Description.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Description", DBNull.Value);
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
        public DatabaseActionResultModel SaveData(BranchTypeModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("BranchType_SaveData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@Description", paramModel.Description.ToString());
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
        public DatabaseActionResultModel EditData(BranchTypeModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("BranchType_EditData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ID", paramModel.Id.ToString());
                    sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@Description", paramModel.Description.ToString());
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
        public DatabaseActionResultModel DeleteData(BranchTypeModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("BranchType_DeleteData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ID", paramModel.Id.ToString());
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
