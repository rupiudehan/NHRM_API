//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NHRMS_WebAPI.Extension
{
    public class DataService
    {
        static SqlCommand SqlComm = null;
        static SqlDataAdapter SqlDA = null;

        private static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["AttendanceDB"].ConnectionString);
            }
        }

        public static SqlConnection GetConnection()
        {
            return Connection;
        }

        // Creats a collection of parameters. 
        public static SqlParameterCollection Parameters
        {
            get
            {
                return SqlComm.Parameters;
            }
        }



        // Execute an insert, update, or delete. 
        public static string GetScalar(string CommandText)
        {

            return GetScalar(CommandText, null, CommandType.Text);
        }

        /// <summary> 
        /// 
        /// </summary> 
        /// <param name="CommandText"></param> 
        /// <param name="ParameterValues"></param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static string GetScalar(string CommandText,
               List<SqlParameter> ParameterValues)
        {

            return GetScalar(CommandText, ParameterValues, CommandType.Text);
        }

        public static string GetScalar(string CommandText,
               List<SqlParameter> ParameterValues, CommandType CommandType)
        {

            string res = null;
            SqlConnection SqlConn = Connection;
            SqlConn.Open();

            try
            {
                SqlComm = new SqlCommand(CommandText, SqlConn);
                SqlComm.CommandTimeout = 600;
                SqlComm.CommandType = CommandType;
                if ((ParameterValues != null))
                {
                    foreach (var Parameter in ParameterValues)
                    {
                        SqlComm.Parameters.Add(Parameter);
                    }
                }
                res = SqlComm.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
            return res;
        }

        // Execute an insert, update, or delete. 
        public static int NonQuery(string CommandText)
        {

            return NonQuery(CommandText, null, CommandType.Text);
        }

        /// <summary> 
        /// 
        /// </summary> 
        /// <param name="CommandText"></param> 
        /// <param name="ParameterValues"></param> 
        /// <returns></returns> 
        /// <remarks></remarks> 
        public static int NonQuery(string CommandText, List<SqlParameter> ParameterValues)
        {

            return NonQuery(CommandText, ParameterValues, CommandType.Text);
        }

        public static int NonQuery(string CommandText, List<SqlParameter> ParameterValues, CommandType CommandType)
        {

            int res = 0;
            SqlConnection SqlConn = Connection;
            SqlConn.Open();

            try
            {
                SqlComm = new SqlCommand(CommandText, SqlConn);
                SqlComm.CommandTimeout = 600;
                SqlComm.CommandType = CommandType;
                if ((ParameterValues != null))
                {
                    foreach (var Parameter in ParameterValues)
                    {
                        SqlComm.Parameters.Add(Parameter);
                    }
                }
                res = SqlComm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public static int NonQuery(string CommandText, List<SqlParameter> ParameterValues, CommandType CommandType, List<SqlParameter> OutputParameter, out List<string> OoutputString)
        {

            int res = 0;
            OoutputString = new List<string>();
            SqlConnection SqlConn = Connection;
            SqlConn.Open();

            try
            {
                SqlComm = new SqlCommand(CommandText, SqlConn);
                SqlComm.CommandTimeout = 600;
                SqlComm.CommandType = CommandType;
                if ((ParameterValues != null))
                {
                    foreach (var Parameter in ParameterValues)
                    {
                        SqlComm.Parameters.Add(Parameter);
                    }
                }
                if ((OutputParameter != null))
                {
                    foreach (var Parameter in OutputParameter)
                    {
                        Parameter.Direction = ParameterDirection.Output;
                        SqlComm.Parameters.Add(Parameter);
                    }                    
                }
                res = SqlComm.ExecuteNonQuery();
                if ((OutputParameter != null))
                {
                    foreach (var Parameter in OutputParameter)
                    {
                        OoutputString.Add(Parameter.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        // Return a SqlDataReader 
        public static SqlDataReader GetSqlDataReader(string CommandText)
        {

            return GetSqlDataReader(CommandText, null, CommandType.Text);
        }

        public static SqlDataReader GetSqlDataReader(string CommandText, List<SqlParameter> ParameterValues)
        {

            return GetSqlDataReader(CommandText, ParameterValues, CommandType.Text);
        }

        public static SqlDataReader GetSqlDataReader(string CommandText, List<SqlParameter> ParameterValues, CommandType CommandType)
        {

            SqlDataReader res = null;
            SqlConnection SqlConn = Connection;
            SqlConn.Open();

            try
            {
                SqlComm = new SqlCommand(CommandText, SqlConn);
                SqlComm.CommandTimeout = 600;
                SqlComm.CommandType = CommandType;
                if ((ParameterValues != null))
                {
                    foreach (var Parameter in ParameterValues)
                    {
                        SqlComm.Parameters.Add(Parameter);
                    }
                }
                res = SqlComm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                SqlConn.Close();
                throw ex;
            }
            return res;
        }

        // Return a DataSet 
        public static DataSet GetDataset(string CommandText)
        {

            return GetDataset(CommandText, null, CommandType.Text);
        }

        public static DataSet GetDataset(string CommandText, List<SqlParameter> ParameterValues)
        {
            return GetDataset(CommandText, ParameterValues, CommandType.Text);
        }

        public static DataSet GetDataset(string CommandText, List<SqlParameter> ParameterValues, CommandType CommandType)
        {
            DataSet res = new DataSet();
            SqlConnection SqlConn = Connection;
            SqlConn.Open();

            try
            {
                SqlComm = new SqlCommand(CommandText, SqlConn);
                SqlComm.CommandTimeout = 600;
                SqlComm.CommandType = CommandType;
                if ((ParameterValues != null))
                {
                    foreach (var Parameter in ParameterValues)
                    {
                        SqlComm.Parameters.Add(Parameter);
                    }
                }
                SqlDA = new SqlDataAdapter(SqlComm);
                SqlDA.Fill(res);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}