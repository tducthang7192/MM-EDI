using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Globalization;
namespace MM_Project
{
    public class DAL
    {
        public static string CNS = Connection.connectionString;
        public static int LastKQ = 0;
        public static string LastSQLString = "";
        public static string LastExceptionString = "";
        public static DataTable LastDataTableKQ = new DataTable();

        public static string LastSQLStringDebug = "";

        public DAL()
        {

        }

        public static DataTable SELECT_NEWROW_FORSCHEMA(String TableName)
        {

            DataTable kq = new DataTable();
            SqlConnection con = new SqlConnection(CNS);
            String sql = "SELECT  TOP 0 * FROM " + TableName + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;


            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                kq.Load(dr);
                kq = TablePropertyRemove(kq);
                kq.Rows.Add(kq.NewRow());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return kq;
        }
        public static DataTable SELECT_SQL(String SQL)
        {
            LastSQLString = SQL;
            LastExceptionString = "";
            DataTable kq = new DataTable("KQ");
            SqlConnection con = new SqlConnection(CNS);
            String sql = SQL;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            LastSQLStringDebug = SQL;

            try
            {
                con.Open();
                SetAirFlow(con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                LastExceptionString = ex.ToString();
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            LastDataTableKQ = kq;
            TablePropertyRemove(kq);
            return kq;
        }
        public static DataTable SELECT_SQL(String SQL, string connect)
        {
            LastSQLString = SQL;
            LastExceptionString = "";
            DataTable kq = new DataTable("KQ");
            SqlConnection con = new SqlConnection(connect);
            String sql = SQL;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            LastSQLStringDebug = SQL;

            try
            {
                con.Open();
                SetAirFlow(con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                kq.Load(dr);
            }
            catch (Exception ex)
            {
                LastExceptionString = ex.ToString();
                // MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            LastDataTableKQ = kq;
            TablePropertyRemove(kq);
            return kq;
        }
        public static int DELETE(String TableName, String ID)
        {
            int kq = 0;
            SqlConnection con = new SqlConnection(CNS);
            String sql = String.Format("DELETE [" + TableName + "] WHERE REFERENCE = '{0}'", @ID);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", ID));


            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch
            {

            }

            finally
            {
                con.Close();
            }
            return kq;
        }

        public static void SetAirFlow(SqlConnection con)
        {
            using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", con))
            { comm.ExecuteNonQuery(); }
        }
        public static DataTable TablePropertyRemove(DataTable dt)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].AllowDBNull = true;
                dt.Columns[i].ReadOnly = false;
            }

            return dt;
        }
        public static int INSERT_IDENTITY(String TableName, DataTable dt)
        {
            int kq = 0;
            String S1 = "";
            String S2 = "";

            SqlConnection con = new SqlConnection(CNS);
            SqlCommand cmd = new SqlCommand("", con);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i == 0) continue;
                if (dt.Columns[i].ColumnName == "ADDDATE" || dt.Columns[i].ColumnName == "EDITDATE" || dt.Columns[i].ColumnName == "CDATETIME" || dt.Columns[i].ColumnName == "UDATETIME") continue;

                S1 = S1 == "" ? S1 + dt.Columns[i].ColumnName : S1 + "," + dt.Columns[i].ColumnName;
                S2 = S2 == "" ? S2 + "@" + dt.Columns[i].ColumnName : S2 + ",@" + dt.Columns[i].ColumnName;
                cmd.Parameters.Add(new SqlParameter("@" + dt.Columns[i].ColumnName, dt.Rows[0][i]));
            }
            cmd.CommandText = "INSERT INTO " + TableName + " (" + S1 + ") VALUES (" + S2 + ") ";

            try
            {
                con.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch 
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return kq;
        }
        public static void excutequery(string strSql, SqlParameter[] param, CommandType sqlCT)
        {


            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = CNS;
                using (SqlCommand cmd = new SqlCommand(strSql, Conn))
                {

                    cmd.CommandType = sqlCT;
                    cmd.CommandTimeout = 20000;
                    if (param != null)
                    {
                        if (param.Length > 0)
                        {
                            foreach (SqlParameter pr in param)
                            {
                                cmd.Parameters.Add(pr);
                            }
                        }
                    }

                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }

            }
        }
        public static void excutequery(string strSql, CommandType sqlCT)
        {


            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = CNS;
                using (SqlCommand cmd = new SqlCommand(strSql, Conn))
                {

                    cmd.CommandType = sqlCT;
                    cmd.CommandTimeout = 20000;
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                    Conn.Close();
                }
            }

        }
        public static DataSet GetDataSet(string mySql, CommandType sqlCT)
        {

            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = CNS;
                using (SqlCommand cmd = new SqlCommand(mySql, Conn))
                {

                    SqlDataAdapter adpAdapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adpAdapter.SelectCommand = cmd;
                    adpAdapter.Fill(ds);
                    return ds;
                }
            }
        }
        public static DataSet GetDataSet(string strSql, SqlParameter[] param, CommandType sqlCT)
        {


            using (SqlConnection Conn = new SqlConnection())
            {
                Conn.ConnectionString = CNS;
                using (SqlCommand cmd = new SqlCommand(strSql, Conn))
                {

                    cmd.CommandType = sqlCT;
                    cmd.CommandTimeout = 20000;
                    if (param != null)
                    {
                        if (param.Length > 0)
                        {
                            foreach (SqlParameter pr in param)
                            {
                                cmd.Parameters.Add(pr);
                            }
                        }
                    }

                    SqlDataAdapter adpAdapter = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    adpAdapter.SelectCommand = cmd;
                    adpAdapter.Fill(ds);
                    return ds;
                }
            }

        }
        public static int IntReturn(object d)  //return number from object
        {
            return (isDouble(d) ? (int)double.Parse(d.ToString()) : 0);
        }
        public static decimal DecimalReturn(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString(), nfi) : 0);
        }
        public static bool isDouble(object number) //Check double
        {
            bool kq = true;
            try
            {
                Double.Parse(number.ToString());
            }
            catch (Exception)
            {
                kq = false;
            }

            return kq;
        }
        public static float FloatReturn(object d) //return number from object
        {
            return (isDouble(d) ? float.Parse(d.ToString()) : 0);
        }
        public static float ChangeValue(int number, int value)
        {
            float result = 0;
            if (number == 1)
            {
                result = value / 10.0f;
            }
            else if (number == 2)
            {
                result = value / 100.0f;
            }
            else if (number == 3)
            {
                result = value / 1000.0f;
            }
            return result;
        }
        public static string GetString(string value,int number)
        {
            string zerostring = "000000000000";
            int lenght = value.Length;
            value = zerostring.Substring(0, number - lenght) + value;
            return value;
        }
        public static void UpdateStatus(string value1 , string value2, string value3)
        {
            string sql = string.Format(" exec [PR_MM_UPDATE_STATUS] '{0}','{1}','{2}'", value1, value2, value3);
            DAL.SELECT_SQL(sql);
        }
        public static DateTime GetTimeFinishToken()
        {
            string sql = string.Format("select ENDTIME from ION_TOKEN");
            DataTable dt = DAL.SELECT_SQL(sql);
            DateTime endTime = DateTime.Parse(dt.Rows[0][0].ToString());
            return endTime;
        }
        public static DataTable GetNewToken()
        {
            string sql = string.Format("select AccessToken,EndTime from ION_TOKEN");
            DataTable dtToken = DAL.SELECT_SQL(sql);
            return dtToken;
        }

    }
}
