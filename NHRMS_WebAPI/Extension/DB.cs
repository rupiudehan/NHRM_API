using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;

namespace NHRMS_WebAPI.Extension
{
    public static class DB
    {
        #region errormessages
        public const string ErrMsgReadData = "Error Method:Read, Error: Error in reading data while calling the stored procedure: ";
        public const string ErrMsgReadList = "Error: Error in reading list of data while calling the stored procedure: ";
        public const string ErrMsgReadTableList = "Error Method:ReadTableList, Error: Error in reading table list of data while calling the stored procedure: ";
        public const string ErrMsgGetCount = "Error Method:GetCount, Error: Error in reading record count of data while calling the stored procedure: ";
        public const string ErrMsgGetScalar = "Error Method:GetScalar, Error: Error in reading record count of data while calling the stored procedure: ";
        public const string ErrMsgReadTable = "Error Method:Read, Error: Error in Reading table while calling the stored procedure: ";
        public const string ErrMsgReadDs = "Error Method:ReadDS, Error: Error in Reading table while calling the stored procedure: ";
        public const string ErrMsgUpdate = "Error Method:Update, Error: Error while updating the table using Stored Procedure:";
        public const string ErrMsgUpdateWithOutput = "Error Method:UpdateWithOutput, Error: Error while updating the table using Stored Procedure using with Output parameters:";
        public const string ErrMsgKillConn = "Error Method:Kill, Error: Error in killing the Connection.";
        public const string ErrMsgUpdateKeepAlive = "Error Method:UpdateKeepAlive, Error: Error in while calling stored procedure:";
        public const string ErrMsgDeleteData = "Error Method:Delete, Error: Error in deleting items from database table using stored procedure:";
        public const string ErrMsgSetParameters = "Error Method:SetParameters, Error: Error while adding query parameters to command objects.";
        public const string ErrMsgSetOutputParameter = "Error Method:SetOutputParameter, Error: Error while setting Output parameter.";
        #endregion

        #region connectionstring
        private static readonly string DataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory Factory = DbProviderFactories.GetFactory(DataProvider);
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString;
        #endregion

        public static DbProviderFactory GetFactory()
        {
            return Factory;
        }

        public static DbConnection GetConnection()
        {
            using (var connection = Factory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                return connection;
            }
        }

        #region publicmethods
        public static DataSet ReadDS(string sql, object[] parms = null)
        {
            try
            {
                using (var connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;
                    using (var command = Factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = sql;
                        command.CommandTimeout = 3000000;
                        SetParameters(command, parms);
                        using (var adapter = Factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            connection.Open();
                            var dataTable = new DataSet();
                            adapter.Fill(dataTable);
                            connection.Close();
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ErrMsgReadDs + sql + "|" + ex.Message);
            }
        }

        public static DataSet ReadDSwithOutput(string sql, out object[] outputs, object[] parms = null, object[] outparam = null)
        {
            try
            {
                outputs = null;
                using (var connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;
                    using (var command = Factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = sql;
                        command.CommandTimeout = 3000000;
                        SetParameters(command, parms);
                        SetOutputParameter(command, outparam);
                        using (var adapter = Factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            connection.Open();
                            var dataTable = new DataSet();
                            adapter.Fill(dataTable);
                            outputs[0] = command.Parameters[outparam[0].ToString()].Value.ToString();
                            outputs[1] = command.Parameters[outparam[1].ToString()].Value.ToString();
                            connection.Close();
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ErrMsgReadDs + sql + "|" + ex.Message);
            }
        }

        public static string UpdateWithOutput(string sql, object[] parms = null, object[] outparam = null)
        {
            try
            {
                using (var connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (var command = Factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = sql;
                        SetParameters(command, parms);
                        SetOutputParameter(command, outparam);
                        connection.Open();
                        command.ExecuteScalar();
                        var strVal = command.Parameters[outparam[0].ToString()].Value.ToString();
                        connection.Close();
                        return strVal;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ErrMsgUpdateWithOutput + sql + "|" + ex.Message);
            }
        }

        public static string InsertorUpdate(string sql, object[] parms = null)
        {
            try
            {
                using (var connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (var command = Factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = sql;
                        SetParameters(command, parms);
                        //SetOutputParameter(command, outparam);
                        connection.Open();
                        command.ExecuteScalar();
                        //var strVal = command.Parameters[outparam[0].ToString()].Value.ToString();
                        connection.Close();
                        //return strVal;
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ErrMsgUpdateWithOutput + sql + "|" + ex.Message);
            }
        }

        public static string[] InsertorUpdateWithOutput(string sql, object[] parms = null, object[] outparam = null)
        {
            try
            {
                using (var connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (var command = Factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = sql;
                        SetParameters(command, parms);
                        SetOutputParameter(command, outparam);
                        connection.Open();
                        command.ExecuteScalar();
                        string[] strVal= new string[2];
                        strVal[0] = command.Parameters[outparam[0].ToString()].Value.ToString();
                        strVal[1] = command.Parameters[outparam[3].ToString()].Value.ToString();
                        connection.Close();
                        return strVal;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ErrMsgUpdateWithOutput + sql + "|" + ex.Message);
            }
        }

        public static object GetScalar(string sql, object[] parms = null)
        {
            try
            {
                using (var connection = Factory.CreateConnection())
                {
                    connection.ConnectionString = ConnectionString;

                    using (var command = Factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = sql;
                        command.SetParameters(parms);
                        connection.Open();
                        var obj = command.ExecuteScalar();
                        connection.Close();
                        return obj;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ErrMsgGetScalar + sql + "|" + ex.Message);
            }
        }
        #endregion

        #region privatemethods

        public static List<DbParameter> SetFacotryParameters(object[] dbParams)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            
            //foreach (var item in dbParams)
            for (var i = 0; i < dbParams.Length; i += 2)
            {
                DbParameter param = Factory.CreateParameter();
                param.ParameterName = dbParams[i].ToString();
                param.Value = dbParams[i+1];
                parameters.Add(param);
            }
            
            return parameters;
        }
        public static List<DbParameter> SetFacotryOutputParameters(object[] dbParams)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            //foreach (var item in dbParams)
            for (var i = 0; i < dbParams.Length; i += 2)
            {
                DbParameter param = Factory.CreateParameter();
                param.Direction = ParameterDirection.Output;
                param.ParameterName = dbParams[i].ToString();
                param.Value = dbParams[i + 1];
                parameters.Add(param);
            }

            return parameters;
        }
        private static void SetParameters(this DbCommand command, object[] parms, bool bOutput = false)
        {
            try
            {
                if (parms != null && parms.Length > 0)
                {
                    // NOTE: Processes a name/value pair at each iteration
                    for (var i = 0; i < parms.Length; i += 2)
                    {
                        var name = parms[i].ToString();
                        // No empty strings to the database
                        if (parms[i + 1] is string && (string)parms[i + 1] == "")
                            parms[i + 1] = null;

                        if (parms[i + 1] is DateTime && (DateTime)parms[i + 1] == DateTime.MinValue)
                            parms[i + 1] = null;

                        // If null, set to DbNull
                        var value = parms[i + 1] ?? DBNull.Value;
                        var dbParameter = command.CreateParameter();
                        if (bOutput) { dbParameter.Direction = ParameterDirection.Output; }

                        dbParameter.ParameterName = name;
                        dbParameter.Value = value;
                        command.Parameters.Add(dbParameter);
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException(ErrMsgSetParameters);
            }

        }

        private static void SetOutputParameter(this DbCommand command, object[] param)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < param.Length;)
                {
                    count = i;


                    if (param[i] != null)
                    {
                        // NOTE: Processes a name/value pair at each iteration
                        var name = param[i].ToString();
                        // No empty strings to the database
                        if (!(param[i] is string && (string)param[i] == ""))
                        {
                            count++;
                            var dbParameter = command.CreateParameter();
                            dbParameter.Direction = ParameterDirection.Output;

                            switch ((param[count].ToString().ToLower()))
                            {
                                case "string":
                                    dbParameter.DbType = DbType.String;
                                    count++;
                                    dbParameter.Size = Convert.ToInt32(param[count]);
                                    i=i+3;
                                    break;
                                case "int":
                                    dbParameter.DbType = DbType.Int32;
                                    i = i + 3;
                                    break;
                                case "long":
                                    dbParameter.DbType = DbType.Int64;
                                    i = i + 3;
                                    break;
                            }
                            dbParameter.ParameterName = name;
                            command.Parameters.Add(dbParameter);
                        }
                    }
                }
                
            }
            catch (Exception)
            {
                throw new ApplicationException(ErrMsgSetOutputParameter);
            }

        }

        #endregion
    }
}