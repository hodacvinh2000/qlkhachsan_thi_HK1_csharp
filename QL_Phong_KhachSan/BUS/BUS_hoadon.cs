using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;

namespace BUS
{
    public class BUS_hoadon
    {
        DAL_hoadon hoadon = new DAL_hoadon();
        public List<MODEL_hoadon> ds_hoadon()
        {
            return hoadon.ds_hoadon();
        }
        public MODEL_hoadon thongtin_hoadonphong(int maphong)
        {
            return hoadon.thongtin_hoadonphong(maphong);
        }
        public int datphong(int maphong, string tenkhachhang, string cmnd)
        {
            return hoadon.datphong(maphong, tenkhachhang, cmnd);
        }
        public int tinhtien(int maphong)
        {
            return hoadon.tinhtien(maphong);
        }
        public int traphong(int maphong)
        {
            return hoadon.traphong(maphong);
        }
        public int huydat(int maphong)
        {
            return hoadon.huydat(maphong);
        }
        public int chothue(int maphong, string tenkhachhang, string cmnd)
        {
            return hoadon.chothue(maphong, tenkhachhang, cmnd);
        }
        public DataTable inhoadon(int maphong)
        {
            return hoadon.inhoadon(maphong);
        }
        public DataTable getHoadon()
        {
            return hoadon.getHoadon();
        }
        public DataTable timHoadon(string key)
        {
            key = key.ToLower();
            DataTable dshoadon = this.getHoadon();
            if (key != "")
            {
                for (int i = 0; i < dshoadon.Rows.Count; i++)
                {
                    if (!dshoadon.Rows[i]["trangthai"].ToString().ToLower().Trim().Contains(key) &&
                        !dshoadon.Rows[i]["tenphong"].ToString().ToLower().Trim().Contains(key) &&
                        !dshoadon.Rows[i]["tenkhachhang"].ToString().ToLower().Trim().Contains(key) &&
                        !dshoadon.Rows[i]["cmnd"].ToString().ToLower().Trim().Contains(key))
                        dshoadon.Rows[i].Delete();
                }
            }
            return dshoadon;
        }
        public int capnhathoadon(int mahoadon, string tenkhachhang, string cmnd)
        {
            return hoadon.capnhathoadon(mahoadon, tenkhachhang, cmnd);
        }
        public int xoahoadon(int mahoadon)
        {
            return hoadon.xoahoadon(mahoadon);
        }
    }
}
