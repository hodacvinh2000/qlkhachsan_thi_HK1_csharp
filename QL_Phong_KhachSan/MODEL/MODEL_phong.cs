using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MODEL
{
    public class MODEL_phong
    {
        private int maphong, giaphong;
        private string tenphong, trangthai;

        public MODEL_phong(int maphong, string tenphong, int giaphong, String trangthai)
        {
            this.Maphong = maphong;
            this.Tenphong = tenphong;
            this.Giaphong = giaphong;
            this.Trangthai = trangthai;
        }
        public MODEL_phong(DataRow row)
        {
            if (row["maphong"].ToString() != "")
                this.Maphong = (int)row["maphong"];
            if (row["tenphong"].ToString() != "")
                this.Tenphong = row["tenphong"].ToString();
            if (row["giaphong"].ToString() != "")
                this.Giaphong = (int)row["giaphong"];
            if (row["trangthai"].ToString() != "")
                this.Trangthai = row["trangthai"].ToString();
        }

        public MODEL_phong()
        {
        }

        public int Maphong { get => maphong; set => maphong = value; }
        public int Giaphong { get => giaphong; set => giaphong = value; }
        public string Tenphong { get => Tenphong1; set => Tenphong1 = value; }
        public string Tenphong1 { get => tenphong; set => tenphong = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
