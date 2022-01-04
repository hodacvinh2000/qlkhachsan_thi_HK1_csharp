using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MODEL;

namespace DAL
{
    public class DAL_phong : DBconnection
    {
        public List<MODEL_phong> ds_phong()
        {
            List<MODEL_phong> ds_phong = new List<MODEL_phong>();

            SqlDataAdapter da = new SqlDataAdapter("select * from phong", con);
            DataTable data = new DataTable();
            da.Fill(data);
            foreach (DataRow item in data.Rows)
            {
                MODEL_phong phong = new MODEL_phong(item);
                ds_phong.Add(phong);
            }

            return ds_phong;
        }
        public DataTable getPhong()
        {
            DataTable myTable = new DataTable();
            string sql = "select * from phong";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    myTable.Load(reader);
                }
            }
            myTable.Columns.Add("stt");
            for (int i = 1; i <= myTable.Rows.Count; i++)
                myTable.Rows[i - 1]["stt"] = i.ToString();
            con.Close();
            return myTable;
        }
        public MODEL_phong thongtinphong(int maphong)
        {
            MODEL_phong p = new MODEL_phong();

            string sql = string.Format("select * from phong where maphong = {0}", maphong);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable data = new DataTable();
            da.Fill(data);
            if (data.Rows.Count > 0)
            {
                p = new MODEL_phong(data.Rows[0]);
            }
            else
            {
                p = null;
            }

            return p;
        }
        public int themphong(string tenphong, int giaphong)
        {
            con.Open();
            DateTime batdau = DateTime.Now;
            string sql = "insert into phong (tenphong,giaphong,trangthai) values(@tenphong,@giaphong,N'Trống')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tenphong", tenphong);
            cmd.Parameters.AddWithValue("@giaphong", giaphong);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public int capnhatphong(int maphong, string tenphong, int giaphong)
        {
            con.Open();
            DateTime batdau = DateTime.Now;
            string sql = "update phong set tenphong=@tenphong, giaphong=@giaphong where maphong=@maphong";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@tenphong", tenphong);
            cmd.Parameters.AddWithValue("@giaphong", giaphong);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public int xoaphong(int maphong)
        {
            con.Open();
            DateTime batdau = DateTime.Now;
            string sql = "delete from phong where maphong=@maphong";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
    }
}
