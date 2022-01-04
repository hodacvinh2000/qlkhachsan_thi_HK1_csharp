using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    public class MODEL_hoadon
    {
        private int mahoadon, maphong, tongtien;
        private string tenkhachhang, cmnd, trangthai;
        private DateTime batdau, ketthuc;

        public MODEL_hoadon()
        {
        }

        public MODEL_hoadon(DataRow row)
        {
            if (row["mahoadon"].ToString() != "")
                this.Mahoadon = (int)row["mahoadon"];
            if (row["maphong"].ToString() != "")
                this.Maphong = (int)row["maphong"];
            if (row["tenkhachhang"].ToString() != "")
                this.Tenkhachhang = row["tenkhachhang"].ToString();
            if (row["cmnd"].ToString() != "")
                this.Cmnd = row["cmnd"].ToString();
            if (row["tongtien"].ToString()!="")
                this.Tongtien = (int)row["tongtien"];
            if (row["batdau"].ToString() != "")
                this.Batdau = (DateTime)row["batdau"];
            if (row["ketthuc"].ToString() != "")
                this.Ketthuc = (DateTime)row["ketthuc"];
            if (row["trangthai"].ToString() != "")
                this.Trangthai = row["trangthai"].ToString();
        }

        public MODEL_hoadon(int mahoadon, int maphong, string tenkhachhang, string cmnd, int tongtien, DateTime batdau, DateTime ketthuc, string trangthai)
        {
            this.Mahoadon = mahoadon;
            this.Maphong = maphong;
            this.Tenkhachhang = tenkhachhang;
            this.Cmnd = cmnd;
            this.Tongtien = tongtien;
            this.Batdau = batdau;
            this.Ketthuc = ketthuc;
            this.Trangthai = trangthai;
        }
        public int Mahoadon { get => mahoadon; set => mahoadon = value; }
        public int Maphong { get => maphong; set => maphong = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public string Tenkhachhang { get => tenkhachhang; set => tenkhachhang = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public DateTime Batdau { get => batdau; set => batdau = value; }
        public DateTime Ketthuc { get => ketthuc; set => ketthuc = value; }
    }
}
