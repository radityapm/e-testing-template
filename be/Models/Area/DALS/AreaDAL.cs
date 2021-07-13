using api.Models.Area.Interfaces;
using api.Models.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Area.DALS
{
    public class AreaDAL: IArea
    {
        private readonly string ConnectionString;
        private readonly int ConnectionTimeOut;
        public AreaDAL(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("UserConnection");
            ConnectionTimeOut = Convert.ToInt32(configuration.GetConnectionString("TimeOutConnection"));
        }

        public DatabaseActionResultModel AreaGetData(AreaParamModel paramModel)
        {
            List<AreaModel> Result = new List<AreaModel>();
            int RecordsTotal = AreaGetDataCount(paramModel);
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
                using (SqlCommand sqlCommand = new SqlCommand("Area_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", Convert.ToInt32(paramModel.ProvinsiID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiName))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", paramModel.ProvinsiName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KotaID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", paramModel.KotaID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KotaName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", paramModel.KotaName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KecamatanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", paramModel.KecamatanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KecamatanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", paramModel.KecamatanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KelurahanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", paramModel.KelurahanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KelurahanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", paramModel.KelurahanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", DBNull.Value);
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
                        sqlCommand.Parameters.AddWithValue("@SortIndex", 1);
                    }
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Add(new AreaModel()
                            {
                                No = Convert.ToInt32(dataReader["No"]),
                                ProvinsiID = dataReader["ProvinsiID"].ToString(),
                                ProvinsiName = dataReader["ProvinsiName"].ToString(),
                                KotaID = dataReader["KotaID"].ToString(),
                                KotaName = dataReader["KotaName"].ToString(),
                                KecamatanID = dataReader["KecamatanID"].ToString(),
                                KecamatanName = dataReader["KecamatanName"].ToString(),
                                KelurahanID = dataReader["KelurahanID"].ToString(),
                                KelurahanName = dataReader["KelurahanName"].ToString(),
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
        public int AreaGetDataCount(AreaParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Area_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", Convert.ToInt32(paramModel.ProvinsiID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiName))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", paramModel.ProvinsiName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KotaID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", paramModel.KotaID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KotaName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", paramModel.KotaName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KecamatanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", paramModel.KecamatanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KecamatanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", paramModel.KecamatanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KelurahanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", paramModel.KelurahanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KelurahanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", paramModel.KelurahanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", DBNull.Value);
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
        public DatabaseActionResultModel ProvinsiGetData(AreaParamModel paramModel)
        {
            List<ProvinsiModel> Result = new List<ProvinsiModel>();
            int RecordsTotal = ProvinsiGetDataCount(paramModel);
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
                using (SqlCommand sqlCommand = new SqlCommand("Provinsi_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", Convert.ToInt32(paramModel.ProvinsiID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiName))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", paramModel.ProvinsiName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", DBNull.Value);
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
                        sqlCommand.Parameters.AddWithValue("@SortIndex", 1);
                    }
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Add(new ProvinsiModel()
                            {
                                No = Convert.ToInt32(dataReader["No"]),
                                ID = dataReader["ID"].ToString(),
                                Name = dataReader["Name"].ToString(),                                
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
        public int ProvinsiGetDataCount(AreaParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Provinsi_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", Convert.ToInt32(paramModel.ProvinsiID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiName))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", paramModel.ProvinsiName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiName", DBNull.Value);
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
        public DatabaseActionResultModel KotaGetData(AreaParamModel paramModel)
        {
            List<KotaModel> Result = new List<KotaModel>();
            int RecordsTotal = KotaGetDataCount(paramModel);
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
                using (SqlCommand sqlCommand = new SqlCommand("Kota_GetData", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.KotaID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", Convert.ToInt32(paramModel.KotaID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.KotaName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", paramModel.KotaName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", paramModel.ProvinsiID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", DBNull.Value);
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
                        sqlCommand.Parameters.AddWithValue("@SortIndex", 1);
                    }
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Add(new KotaModel()
                            {
                                No = Convert.ToInt32(dataReader["No"]),
                                ID = dataReader["ID"].ToString(),
                                Name = dataReader["Name"].ToString(),
                                Provinsi = dataReader["Provinsi"].ToString(),
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
        public int KotaGetDataCount(AreaParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Kota_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.KotaID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", Convert.ToInt32(paramModel.KotaID));
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", DBNull.Value);
                    }
                    
                    if (!string.IsNullOrEmpty(paramModel.KotaName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", paramModel.KotaName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaName", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.ProvinsiID))
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", paramModel.ProvinsiID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@ProvinsiID", DBNull.Value);
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
        public DatabaseActionResultModel KecamatanGetData(AreaParamModel paramModel)
        {
            List<KecamatanModel> Result = new List<KecamatanModel>();
            int RecordsTotal = KecamatanDataCount(paramModel);
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
                using (SqlCommand sqlCommand = new SqlCommand("Kecamatan_GetData", sqlConnection))
                {
                   
                    if (!string.IsNullOrEmpty(paramModel.KotaID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", paramModel.KotaID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", DBNull.Value);
                    }
                    
                    if (!string.IsNullOrEmpty(paramModel.KecamatanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", paramModel.KecamatanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KecamatanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", paramModel.KecamatanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", DBNull.Value);
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
                        sqlCommand.Parameters.AddWithValue("@SortIndex", 1);
                    }
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Add(new KecamatanModel()
                            {
                                No = Convert.ToInt32(dataReader["No"]),
                                ID = dataReader["ID"].ToString(),
                                Name = dataReader["Name"].ToString(),
                                Kota = dataReader["Kota"].ToString(),
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
        public int KecamatanDataCount(AreaParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Kecamatan_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.KotaID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", paramModel.KotaID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KotaID", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.KecamatanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", paramModel.KecamatanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.KecamatanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", paramModel.KecamatanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanName", DBNull.Value);
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
        public DatabaseActionResultModel KelurahanGetData(AreaParamModel paramModel)
        {
            List<KelurahanModel> Result = new List<KelurahanModel>();
            int RecordsTotal = KelurahanGetDataCount(paramModel);
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
                using (SqlCommand sqlCommand = new SqlCommand("Kelurahan_GetData", sqlConnection))
                {
                    
                    if (!string.IsNullOrEmpty(paramModel.KecamatanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", paramModel.KecamatanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", DBNull.Value);
                    }
                   
                    if (!string.IsNullOrEmpty(paramModel.KelurahanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", paramModel.KelurahanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KelurahanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", paramModel.KelurahanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", DBNull.Value);
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
                        sqlCommand.Parameters.AddWithValue("@SortType", "ASC");
                    }
                    if (paramModel.Arg.sortIndex != null)
                    {
                        sqlCommand.Parameters.AddWithValue("@SortIndex", paramModel.Arg.sortIndex);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@SortIndex", 1);
                    }
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = ConnectionTimeOut;
                    sqlConnection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Result.Add(new KelurahanModel()
                            {
                                No = Convert.ToInt32(dataReader["No"]),
                                ID = dataReader["ID"].ToString(),
                                Name = dataReader["Name"].ToString(),                                
                                Kecamatan = dataReader["Kecamatan"].ToString(),                                
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
        public int KelurahanGetDataCount(AreaParamModel paramModel)
        {
            int Result = 0;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                using (SqlCommand sqlCommand = new SqlCommand("Kelurahan_GetCount", sqlConnection))
                {
                    if (!string.IsNullOrEmpty(paramModel.KecamatanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", paramModel.KecamatanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KecamatanID", DBNull.Value);
                    }

                    if (!string.IsNullOrEmpty(paramModel.KelurahanID))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", paramModel.KelurahanID.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanID", DBNull.Value);
                    }
                    if (!string.IsNullOrEmpty(paramModel.KelurahanName))
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", paramModel.KelurahanName.ToString());
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@KelurahanName", DBNull.Value);
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
    }
}
