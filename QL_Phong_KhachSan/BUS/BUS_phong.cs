using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using MODEL;

namespace BUS
{
    public class BUS_phong
    {
        DAL_phong phong = new DAL_phong();
        public List<MODEL_phong> ds_phong()
        {
            return phong.ds_phong();
        }
        public MODEL_phong thongtinphong(int maphong)
        {
            return phong.thongtinphong(maphong);
        }
        public DataTable getPhong()
        {
            return phong.getPhong();
        }
        public DataTable timPhong(string key)
        {
            key = key.ToLower();
            DataTable dsphong = this.getPhong();
            if (key != "")
            {
                for (int i = 0; i < dsphong.Rows.Count; i++)
                {
                    if (!dsphong.Rows[i]["trangthai"].ToString().ToLower().Trim().Contains(key) && !dsphong.Rows[i]["tenphong"].ToString().ToLower().Trim().Contains(key) && !dsphong.Rows[i]["giaphong"].ToString().ToLower().Trim().Contains(key))
                        dsphong.Rows[i].Delete();
                }
            }
            return dsphong;
        }
        public int themphong(string tenphong, int giaphong)
        {
            DataTable dsphong = this.getPhong();
            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                if (dsphong.Rows[i]["tenphong"].ToString().ToLower().Trim().Equals(tenphong.ToLower().Trim()))
                    return -1;
            }
            return phong.themphong(tenphong, giaphong);
        }
        public int capnhatphong(int maphong, string tenphong, int giaphong)
        {
            DataTable dsphong = this.getPhong();
            MODEL_phong p = this.thongtinphong(maphong);
            if (!p.Tenphong.ToLower().Trim().Equals(tenphong.ToLower().Trim()))
            {
                for (int i = 0; i < dsphong.Rows.Count; i++)
                {
                    if (dsphong.Rows[i]["tenphong"].ToString().ToLower().Trim().Equals(tenphong.ToLower().Trim()))
                        return -1;
                }
            }
            return phong.capnhatphong(maphong, tenphong, giaphong);
        }
        public int xoaphong(int maphong)
        {
            return phong.xoaphong(maphong);
        }
    }
}
