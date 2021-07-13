using api.Models.Base;
using api.Models.Team.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Team.DALS
{
    public class TeamDAL: ITeam
    {
        private readonly string ConnectionString;
        private readonly int ConnectionTimeOut;
        public TeamDAL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UserConnection");
            ConnectionTimeOut = Convert.ToInt32(configuration.GetConnectionString("TimeOutConnection"));
        }
        public DatabaseActionResultModel GetData(TeamParamModel paramModel)
        {
            List<TeamModel> Result = new List<TeamModel>();
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
                using (SqlCommand sqlCommand = new SqlCommand("Team_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.ID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", paramModel.ID);
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
                    if (!string.IsNullOrEmpty(paramModel.Branch))
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", paramModel.Branch);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Divisi))
                    {
                        sqlCommand.Parameters.AddWithValue("@Divisi", paramModel.Divisi);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Divisi", DBNull.Value);
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
                            Result.Add(new TeamModel()
                            {
                                No = Convert.ToInt32(dataReader["No"]),
                                ID = dataReader["Id"].ToString(),
                                Nik = dataReader["Nik"].ToString(),
                                Name = dataReader["Name"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Phone = dataReader["Phone"].ToString(),
                                BranchID = dataReader["BranchID"].ToString(),
                                BranchName = dataReader["BranchName"].ToString(),
                                DivisiID = dataReader["DivisiID"].ToString(),
                                DivisiName = dataReader["DivisiName"].ToString(),
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
        public int GetDataCount(TeamParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Team_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.ID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ID", paramModel.ID);
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
                    if (!string.IsNullOrEmpty(paramModel.Branch))
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", paramModel.Branch);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Branch", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.Divisi))
                    {
                        sqlCommand.Parameters.AddWithValue("@Divisi", paramModel.Divisi);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Divisi", DBNull.Value);
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
        public DatabaseActionResultModel SaveData(TeamModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Team_SaveData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@NIK", paramModel.Nik.ToString());
                    sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@Branch", paramModel.BranchID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Divisi", paramModel.DivisiID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", paramModel.Email.ToString());
                    sqlCommand.Parameters.AddWithValue("@Phone", paramModel.Phone.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry.ToString());
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
        public DatabaseActionResultModel EditData(TeamModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Team_EditData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ID", paramModel.ID.ToString());
                    sqlCommand.Parameters.AddWithValue("@NIK", paramModel.Nik.ToString());
                    sqlCommand.Parameters.AddWithValue("@Name", paramModel.Name.ToString());
                    sqlCommand.Parameters.AddWithValue("@Branch", paramModel.BranchID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Divisi", paramModel.DivisiID.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", paramModel.Email.ToString());
                    sqlCommand.Parameters.AddWithValue("@Phone", paramModel.Phone.ToString());
                    sqlCommand.Parameters.AddWithValue("@UserEntry", paramModel.UserEntry.ToString());
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
        public DatabaseActionResultModel DeleteData(TeamModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Team_DeleteData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ID", paramModel.ID.ToString());
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
