using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ComputerDAO
{
    public class DataHelper
    {
        string stcon;//= @"Data Source=LAPTOP-EFS339Q2\MSSQLSERVER04;Initial Catalog=QuanLySanPham;Integrated Security=True";
        SqlConnection con;
        public DataHelper()
        {
            stcon = ConfigurationManager.ConnectionStrings["model"].ConnectionString;
            con = new SqlConnection(stcon);
        }

        public DataTable GetDataTable(string sqlSelect)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con);
            da.Fill(dt);
            return dt;
        }

        public string Open()
        {

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public void Close()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }
        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            //string st = Open();
            //if (st != "")
            //    throw new Exception(st);
            Open();
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            SqlDataReader dr = cm.ExecuteReader();
            return dr;
        }
        public string ExcuteNonQuery(string sql)
        {
            Open();
            try
            {
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                return "";

            }
            catch (SqlException e)
            {
                return e.Message;
                //throw new Exception(e.Message);
                //if (e.Message.Contains("") )
            }
        }

        public DataTable StoreReader(string tenStore, params object[] giatri)
        {
            DataTable r = new DataTable();
            SqlCommand cm;
            Open();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                new SqlDataAdapter(cm).Fill(r);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return r;
        }

        public SqlDataReader StoreReaders(string tenStore, params object[] giatri)
        {
            SqlCommand cm; 
            Open();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                { cm.Parameters[i].Value = giatri[i - 1]; }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch
            { return null; }

        }

        public void StoreNonQuery(string tenStore, params object[] giatri)
        {
            Open();
            SqlCommand cm;
            try
            {
            cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// method to get database by sqldataadapter
        /// </summary>
        /// <param name="sql"> select sql statement</param>
        /// <returns> data table contain records</returns>
        public DataTable FillDataTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, stcon);
            DataTable dt = new DataTable();
            //da.Fill(dt);
            return dt;
        }
        public void InsertRow(DataTable dt, params object[] values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < values.Length; i++)
            {
                dr[i] = values[i];
            }
            dt.Rows.Add(dr);
        }
        public void InsertRows(DataTable dt, params object[] Filds_Values)
        {
            DataRow dr = dt.NewRow();
            for (int i = 0; i < Filds_Values.Length; i += 2)
            {
                dr[Filds_Values[i].ToString()] = Filds_Values[i + 1].ToString();
            }
        }
        public DataView FillterRow(DataTable dt, string dk)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = dk;
            return dv;

        }
        public void UpdateRow(DataTable dt, string dk, params object[] values)
        {
            //b1: Lọc ra các bản ghi cần sửa 
            DataView dv = FillterRow(dt, dk);
            dv.AllowEdit = true;
            //b2: sửa
            if (dv.Count > 0)
            {
                for (int i = 0; i < values.Length; i++)
                    dv[0][i] = values[i];
            }
        }
        public void DeleteRow(DataTable dt, string dk)
        {
            DataView dv = new DataView(dt);
            dv.AllowDelete = true;
            while (dv.Count > 0)
            {
                dv.Delete(0);
                // dv[0].Delete();
            }
        }
        /// <summary>
        /// Cập nhật dữ liệu từ datatable lên database
        /// </summary>
        /// <param name="datatable_tablenames">Cặp datatable và tên bảng</param>
        // Cập nhật nhiều bảng
        public void UpdateDataTableToDataBase(params object[] datatable_tablenames)
        {
            string st = "";
            for (int i = 1; i < datatable_tablenames.Length; i = i + 2)
            {
                st = st + "select * from " + datatable_tablenames[i] + ";";
                if (i == datatable_tablenames.Length - 1)
                {
                    st = st + "select * from " + datatable_tablenames[i];
                }
                else
                    st = st + "select*from " + datatable_tablenames[i] + ";";
            }
            SqlDataAdapter da = new SqlDataAdapter(st, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            for (int i = 0; i < datatable_tablenames.Length; i = i + 2)
            {
                ds.Tables.Add((DataTable)datatable_tablenames[i]);
            }
            da.Update(ds);
        }
        //cập nhật một bảng
        public void UpdateDataTableToDataBase(DataTable dt, string table_names)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from " + table_names, con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
        }
        public DataTable ExcuteStoreProcedure(string storePname, params object[] values)
        {
            SqlCommand cm = new SqlCommand(storePname, con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cm);
            for (int i = 1; i < cm.Parameters.Count; i++)
            {
                cm.Parameters[i].Value = values[i - 1];
            }
            //hướng kết nối
            // SqlDataReader dr = cm.ExecuteReader();
            //cm.ExecuteNonQuery();
            //phi kết nối
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            return dt;
        }
        public void ExcuteNoneStoreProcedure(string storePname, params object[] values)
        {
            SqlCommand cm = new SqlCommand(storePname, con);
            cm.CommandType = CommandType.StoredProcedure;
            SqlCommandBuilder.DeriveParameters(cm);
            for (int i = 1; i < cm.Parameters.Count; i++)
            {
                cm.Parameters[i].Value = values[i - 1];
            }
            //hướng kết nối
            // SqlDataReader dr = cm.ExecuteReader();
            cm.ExecuteNonQuery();
            //phi kết nối
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da = new SqlDataAdapter(cm);
            //    da.Fill(dt);
            //    return dt;
        }

    }
}
