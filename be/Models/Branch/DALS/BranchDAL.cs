using api.Models.Base;
using api.Models.Branch.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Branch.DALS
{
    public class BranchDAL: IBranch
    {
        private readonly string ConnectionString;
        private readonly int ConnectionTimeOut;
        public BranchDAL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UserConnection");
            ConnectionTimeOut = Convert.ToInt32(configuration.GetConnectionString("TimeOutConnection"));
        }
        public DatabaseActionResultModel GetData(BranchParamModel paramModel)
        {
            List<BranchModel> Result = new List<BranchModel>();
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
                using (SqlCommand sqlCommand = new SqlCommand("Branch_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.BranchId))
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchID", paramModel.BranchId.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.BranchName))
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchName", paramModel.BranchName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchName", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.BranchType))
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchType", paramModel.BranchType.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchType", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.City))
                    {
                        sqlCommand.Parameters.AddWithValue("@City", paramModel.City.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@City", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Province))
                    {
                        sqlCommand.Parameters.AddWithValue("@Province", paramModel.Province.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Province", DBNull.Value);
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
                            Result.Add(new BranchModel()
                            {
                                BranchId = dataReader["BranchId"].ToString(),
                                BranchName = dataReader["BranchName"].ToString(),
                                BranchType = dataReader["BranchType"].ToString(),
                                Address = dataReader["Address"].ToString(),
                                PostCode = dataReader["PostCode"].ToString(),
                                City = dataReader["City"].ToString(),
                                Province = dataReader["Province"].ToString(),
                                AreaCode = dataReader["AreaCode"].ToString(),
                                Phone = dataReader["Phone"].ToString(),
                                Fax = dataReader["Fax"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                PIC1 = dataReader["PIC1"].ToString(),
                                PIC2 = dataReader["PIC2"].ToString(),
                                PIC3 = dataReader["PIC3"].ToString(),
                                Lat = Convert.ToDecimal(dataReader["Lat"]),
                                Long = Convert.ToDecimal(dataReader["Long"]),
                                Accuracy = Convert.ToDecimal(dataReader["Accuracy"]),
                                AddressPoint = dataReader["AddressPoint"].ToString(),
                                Location = dataReader["Location"].ToString(),
                                UserEntry = dataReader["UserEntry"].ToString(),
                                 DateEntry = Convert.ToDateTime(dataReader["DateEntry"]),
                                //UserUpdate = string.IsNullOrEmpty(dataReader["UserUpdate"].ToString()) == true ? "": dataReader["UserUpdate"].ToString(),
                                //DateUpdate = string.IsNullOrEmpty(dataReader["DateUpdate"].ToString()) ==  true ? DateTime.Now.AddYears(-100) :Convert.ToDateTime(dataReader["DateUpdate"]),
                                IsActive =  Convert.ToBoolean(dataReader["IsActive"]),
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
        public int GetDataCount(BranchParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Branch_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.BranchId))
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchID", paramModel.BranchId.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.BranchName))
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchName", paramModel.BranchName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchName", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.BranchType))
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchType", paramModel.BranchType.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@BranchType", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.City))
                    {
                        sqlCommand.Parameters.AddWithValue("@City", paramModel.City.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@City", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.Province))
                    {
                        sqlCommand.Parameters.AddWithValue("@Province", paramModel.Province.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Province", DBNull.Value);
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
        public DatabaseActionResultModel SaveData(BranchModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Branch_SaveData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@BranchName", paramModel.BranchName.ToString());
                    sqlCommand.Parameters.AddWithValue("@BranchType", paramModel.BranchType.ToString());
                    sqlCommand.Parameters.AddWithValue("@Address", paramModel.Address.ToString());
                    sqlCommand.Parameters.AddWithValue("@PostCode", paramModel.PostCode.ToString());
                    sqlCommand.Parameters.AddWithValue("@City", paramModel.City.ToString());
                    sqlCommand.Parameters.AddWithValue("@Province", paramModel.Province.ToString());
                    sqlCommand.Parameters.AddWithValue("@AreaCode", paramModel.AreaCode.ToString());
                    sqlCommand.Parameters.AddWithValue("@Phone", paramModel.Phone.ToString());
                    sqlCommand.Parameters.AddWithValue("@Fax", paramModel.Fax.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", paramModel.Email);
                    sqlCommand.Parameters.AddWithValue("@PIC1", paramModel.PIC1);
                    sqlCommand.Parameters.AddWithValue("@PIC2", paramModel.PIC2);
                    sqlCommand.Parameters.AddWithValue("@PIC3", paramModel.PIC3);
                    sqlCommand.Parameters.AddWithValue("@Lat", paramModel.Lat);
                    sqlCommand.Parameters.AddWithValue("@Long", paramModel.Long);
                    sqlCommand.Parameters.AddWithValue("@Accuracy", paramModel.Accuracy);
                    sqlCommand.Parameters.AddWithValue("@AddressPoint", paramModel.AddressPoint);
                    sqlCommand.Parameters.AddWithValue("@Location", paramModel.Location);
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
        public DatabaseActionResultModel EditData(BranchModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Branch_EditData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@BranchID", paramModel.BranchId.ToString());
                    sqlCommand.Parameters.AddWithValue("@BranchName", paramModel.BranchName.ToString());
                    sqlCommand.Parameters.AddWithValue("@BranchType", paramModel.BranchType.ToString());
                    sqlCommand.Parameters.AddWithValue("@Address", paramModel.Address.ToString());
                    sqlCommand.Parameters.AddWithValue("@PostCode", paramModel.PostCode.ToString());
                    sqlCommand.Parameters.AddWithValue("@City", paramModel.City.ToString());
                    sqlCommand.Parameters.AddWithValue("@Province", paramModel.Province.ToString());
                    sqlCommand.Parameters.AddWithValue("@AreaCode", paramModel.AreaCode.ToString());
                    sqlCommand.Parameters.AddWithValue("@Phone", paramModel.Phone.ToString());
                    sqlCommand.Parameters.AddWithValue("@Fax", paramModel.Fax.ToString());
                    sqlCommand.Parameters.AddWithValue("@Email", paramModel.Email);
                    sqlCommand.Parameters.AddWithValue("@PIC1", paramModel.PIC1);
                    sqlCommand.Parameters.AddWithValue("@PIC2", paramModel.PIC2);
                    sqlCommand.Parameters.AddWithValue("@PIC3", paramModel.PIC3);
                    sqlCommand.Parameters.AddWithValue("@Lat", paramModel.Lat);
                    sqlCommand.Parameters.AddWithValue("@Long", paramModel.Long);
                    sqlCommand.Parameters.AddWithValue("@Accuracy", paramModel.Accuracy);
                    sqlCommand.Parameters.AddWithValue("@AddressPoint", paramModel.AddressPoint);
                    sqlCommand.Parameters.AddWithValue("@Location", paramModel.Location);
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
        public DatabaseActionResultModel DeleteData(BranchParamModel paramModel)
        {

            DatabaseActionResultModel Result = new DatabaseActionResultModel();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Branch_DeleteData", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@BranchID", paramModel.BranchId.ToString());
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
