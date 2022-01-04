using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_hoadon : DBconnection
    {
        public List<MODEL_hoadon> ds_hoadon()
        {
            List<MODEL_hoadon> ds_hoadon = new List<MODEL_hoadon>();

            SqlDataAdapter da = new SqlDataAdapter("select * from hoadon", con);
            DataTable data = new DataTable();
            da.Fill(data);
            foreach (DataRow item in data.Rows)
            {
                MODEL_hoadon hoadon = new MODEL_hoadon(item);
                ds_hoadon.Add(hoadon);
            }

            return ds_hoadon;
        }
        public DataTable getHoadon()
        {
            DataTable myTable = new DataTable();
            string sql = "select * from hoadon join phong on hoadon.maphong=phong.maphong";
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
        public MODEL_hoadon thongtin_hoadonphong(int maphong)
        {
            MODEL_hoadon hd = new MODEL_hoadon();

            string sql = string.Format("select * from hoadon where maphong = {0} and trangthai != N'Đã trả phòng' order by mahoadon desc", maphong);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable data = new DataTable();
            da.Fill(data);
            if (data.Rows.Count > 0)
            {
                hd = new MODEL_hoadon(data.Rows[0]);
            }
            else
            {
                hd = null;
            }

            return hd;
        }
        public int datphong(int maphong, string tenkhachhang, string cmnd)
        {
            con.Open();
            DateTime batdau = DateTime.Now;
            string sql = "insert into hoadon(maphong,tenkhachhang,cmnd,batdau,trangthai) values (@maphong,@tenkhachhang,@cmnd,@batdau,N'Được đặt trước')" +
                          "update phong set trangthai = N'Được đặt trước' where maphong=@maphong";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            cmd.Parameters.AddWithValue("@tenkhachhang", tenkhachhang);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            cmd.Parameters.AddWithValue("@batdau", batdau.ToString("yyyy/MM/dd HH:mm:ss"));
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public int tinhtien(int maphong)
        {
            con.Open();

            string sql = "update hoadon set ketthuc=@ketthuc,tongtien=@tongtien where maphong=@maphong and trangthai = N'Đang thuê'";
            MODEL_hoadon hd = this.thongtin_hoadonphong(maphong);
            DAL_phong phong = new DAL_phong();
            MODEL_phong p = phong.thongtinphong(maphong);
            DateTime ketthuc = DateTime.Now;
            TimeSpan giothue = ketthuc - hd.Batdau;
            double sogiothue = giothue.Days * 24 + giothue.Hours + (double)giothue.Minutes / 60;
            int tongtien = (int)(sogiothue * (double)p.Giaphong)/1000*1000;
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ketthuc", ketthuc.ToString("yyyy/MM/dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@tongtien", tongtien);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            int a = cmd.ExecuteNonQuery();

            con.Close();
            return a;
        }
        public int traphong(int maphong)
        {
            con.Open();
            string sql = "update hoadon set trangthai = N'Đã thanh toán' where maphong=@maphong and trangthai=N'Đang thuê'" +
                          "update phong set trangthai = N'Trống' where maphong=@maphong";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public int huydat(int maphong)
        {
            con.Open();
            string sql = "delete from hoadon where maphong=@maphong and trangthai=N'Được đặt trước' " +
                "update phong set trangthai=N'Trống' where maphong=@maphong";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public int chothue(int maphong, string tenkhachhang, string cmnd)
        {
            con.Open();
            DateTime batdau = DateTime.Now;
            string sql = "insert into hoadon(maphong,tenkhachhang,cmnd,batdau,trangthai) values (@maphong,@tenkhachhang,@cmnd,@batdau,N'Đang thuê')" +
                          "update phong set trangthai = N'Đang thuê' where maphong=@maphong " +
                          "delete from hoadon where maphong=@maphong and trangthai=N'Được đặt trước'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maphong", maphong);
            cmd.Parameters.AddWithValue("@tenkhachhang", tenkhachhang);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            cmd.Parameters.AddWithValue("@batdau", batdau.ToString("yyyy/MM/dd HH:mm:ss"));
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public DataTable inhoadon(int maphong)
        {
            SqlDataAdapter da = new SqlDataAdapter("select tenkhachhang,cmnd,tenphong,giaphong,batdau,ketthuc as kethuc,tongtien " +
                "from hoadon join phong on hoadon.maphong=phong.maphong " +
                "where hoadon.trangthai=N'Đang thuê' and hoadon.maphong="+maphong, con);
            DataTable data = new DataTable("inhoadon");
            da.Fill(data);
            return data;
        }
        public int capnhathoadon(int mahoadon, string tenkhachhang, string cmnd)
        {
            con.Open();
            string sql = "update hoadon set tenkhachhang=@tenkhachhang, cmnd=@cmnd where mahoadon=@mahoadon";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mahoadon", mahoadon);
            cmd.Parameters.AddWithValue("@tenkhachhang", tenkhachhang);
            cmd.Parameters.AddWithValue("@cmnd", cmnd);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
        public int xoahoadon(int mahoadon)
        {
            con.Open();
            string sql = "delete from hoadon where mahoadon=@mahoadon";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mahoadon", mahoadon);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
    }
}
