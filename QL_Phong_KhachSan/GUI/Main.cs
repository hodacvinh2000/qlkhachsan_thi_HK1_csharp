using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BUS;
using MODEL;
using System.Data.SqlClient;

namespace GUI
{
    public partial class Main : Form
    {
        BUS_phong phong = new BUS_phong();
        BUS_hoadon hoadon = new BUS_hoadon();
        int tablewidth = 60;
        int tableheight = 60;
        public Main()
        {
            InitializeComponent();
        }
        public void btn_click(object sender, EventArgs e)
        {
            MODEL_phong p = (sender as Button).Tag as MODEL_phong;
            thongtinphong(p);
        }
        public void thongtinphong(MODEL_phong p)
        {
            txtMaphong.Text = p.Maphong.ToString();
            txtTenphong.Text = p.Tenphong;
            txtGiaphong.Text = p.Giaphong.ToString();
            txtTrangthai.Text = p.Trangthai;
            // hiển thị thông tin
            if (!p.Trangthai.Equals("Trống"))
            {
                MODEL_hoadon hd = hoadon.thongtin_hoadonphong(p.Maphong);
                txtTenkhach.Text = hd.Tenkhachhang;
                txtCmnd.Text = hd.Cmnd;
                txtBatdau.Text = hd.Batdau.ToString("HH:mm:ss dd/MM/yyyy");
                if (!hd.Ketthuc.ToString("HH:mm:ss dd/MM/yyyy").Equals("00:00:00 01/01/0001"))
                    txtKetthuc.Text = hd.Ketthuc.ToString("HH:mm:ss dd/MM/yyyy");
                else
                {
                    txtKetthuc.Text = "";
                }
            }
            else
            {
                txtTenkhach.Text = "";
                txtCmnd.Text = "";
                txtBatdau.Text = "";
                txtKetthuc.Text = "";
                txtTongtien.Text = "";
                btnTraphong.Enabled = false;
                btnIn.Enabled = false;
            }
            // Điều chỉnh enable các button
            if (p.Trangthai.Equals("Trống"))
            {
                btnDatphong.Enabled = btnChothue.Enabled = true;
                btnHuydat.Enabled = btnTinhtien.Enabled = false;
            }
            else if (p.Trangthai.Equals("Được đặt trước"))
            {
                btnHuydat.Enabled = btnChothue.Enabled = true;
                btnDatphong.Enabled = btnTinhtien.Enabled = false;
            }
            else if (p.Trangthai.Equals("Đang thuê"))
            {
                btnHuydat.Enabled = btnChothue.Enabled = btnDatphong.Enabled = false;
                btnTinhtien.Enabled = true;
                MODEL_hoadon hd = hoadon.thongtin_hoadonphong(p.Maphong);
                if (hd.Tongtien >= 0)
                {
                    btnTraphong.Enabled = btnIn.Enabled = true;
                }
            }
        }
        public void load()
        {
            panel_dsphong.Controls.Clear();
            List<MODEL_phong> dsphong = phong.ds_phong();
            foreach (MODEL_phong p in dsphong)
            {
                // tao cac nut la danh sach phong
                Button btn = new Button() { Width = tablewidth, Height = tableheight };
                btn.Text = p.Tenphong;
                panel_dsphong.Controls.Add(btn);
                if (p.Trangthai.Equals("Trống"))
                {
                    btn.BackColor = Color.Cyan;
                }
                else if (p.Trangthai.Equals("Được đặt trước"))
                {
                    btn.BackColor = Color.Yellow;
                }
                else 
                {
                    btn.BackColor = Color.OrangeRed;
                }
                btn.Click += btn_click;
                btn.Tag = p;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnDatphong_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong.Text);
                string tenkhachhang = txtTenkhach.Text;
                string cmnd = txtCmnd.Text;
                if(tenkhachhang!="" && cmnd!="")
                {
                    hoadon.datphong(maphong, tenkhachhang, cmnd);
                    load();
                    thongtinphong(phong.thongtinphong(maphong));
                    MessageBox.Show("Đặt phòng thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng!");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnHuydat_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong.Text);
                hoadon.huydat(maphong);
                load();
                thongtinphong(phong.thongtinphong(maphong));
                MessageBox.Show("Đã hủy đặt phòng");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnChothue_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong.Text);
                string tenkhachhang = txtTenkhach.Text;
                string cmnd = txtCmnd.Text;
                if (tenkhachhang != "" && cmnd != "")
                {
                    hoadon.chothue(maphong, tenkhachhang, cmnd);
                    load();
                    thongtinphong(phong.thongtinphong(maphong));
                    MessageBox.Show("Cho thuê thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin khách hàng!");
                }

            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnTinhtien_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong.Text);
                hoadon.tinhtien(maphong);
                MODEL_hoadon hd = hoadon.thongtin_hoadonphong(maphong);
                txtTongtien.Text = hd.Tongtien.ToString();
                btnTraphong.Enabled = true;
                thongtinphong(phong.thongtinphong(maphong));
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnTraphong_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong.Text);
                hoadon.traphong(maphong);
                load();
                thongtinphong(phong.thongtinphong(maphong));
                MessageBox.Show("Trả phòng thành công");
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            int maphong = int.Parse(txtMaphong.Text);
            DataTable dt = hoadon.inhoadon(maphong);
            CrystalReport1 baocao = new CrystalReport1();
            baocao.SetDataSource(dt);
            inhoadon f = new inhoadon();
            f.crystalReportViewer1.ReportSource = baocao;
            f.Show();
        }
        private void tabpage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = tabpage.SelectedIndex;
            if (index==0)
            {
                load();
            }
            else if (index==1)
            {
                loadphong();
            }
            else if (index==2)
            {
                loadhoadon();
            }
        }
        public void loadphong()
        {
            DataTable dsphong = phong.getPhong();
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.DataSource = dsphong;
            txtTenphong_ql.Text = txtGiaphong_ql.Text = "";
        }
        public void loadhoadon()
        {
            DataTable dshoadon = hoadon.getHoadon();
            dgvHoadon.AutoGenerateColumns = false;
            dgvHoadon.DataSource = dshoadon;
            txtTenkhachhang_ql.Text = txtCMND_ql.Text = "";
        }

        private void txtTimphong_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimphong.Text;
            DataTable dsphong = phong.timPhong(key);
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.DataSource = dsphong;
        }

        private void btnThemphong_Click(object sender, EventArgs e)
        {
            try
            {
                string tenphong = txtTenphong_ql.Text;
                int giaphong = int.Parse(txtGiaphong_ql.Text); ;
                int status = phong.themphong(tenphong, giaphong);
                if (status == -1)
                    MessageBox.Show("Tên phòng đã tồn tại");
                else
                {
                    MessageBox.Show("Thêm phòng thành công");
                    loadphong();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }

        }

        private void dgvPhong_Click(object sender, EventArgs e)
        {
            int i = dgvPhong.CurrentRow.Index;
            txtTenphong_ql.Text = dgvPhong[2,i].Value.ToString();
            txtGiaphong_ql.Text = dgvPhong[3,i].Value.ToString();
            txtMaphong_ql.Text = dgvPhong[1, i].Value.ToString();
        }

        private void btnCapnhatphong_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong_ql.Text);
                string tenphong = txtTenphong_ql.Text;
                int giaphong = int.Parse(txtGiaphong_ql.Text); ;
                int status = phong.capnhatphong(maphong, tenphong, giaphong);
                if (status == -1)
                    MessageBox.Show("Tên phòng đã tồn tại");
                else
                {
                    MessageBox.Show("Cập nhật phòng thành công");
                    loadphong();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void btnXoaphong_Click(object sender, EventArgs e)
        {
            try
            {
                int maphong = int.Parse(txtMaphong_ql.Text);
                DialogResult xoa =  MessageBox.Show("Bạn có muốn xóa phòng này?", "Thông báo",MessageBoxButtons.YesNo);
                if (xoa==DialogResult.Yes)
                {
                    int status = phong.xoaphong(maphong);
                    if (status > 0)
                        MessageBox.Show("Xóa phòng thành công");
                    loadphong();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void txtTimhoadon_TextChanged(object sender, EventArgs e)
        {
            string key = txtTimhoadon.Text;
            DataTable dshoadon = hoadon.timHoadon(key);
            dgvHoadon.AutoGenerateColumns = false;
            dgvHoadon.DataSource = dshoadon;
        }

        private void dgvHoadon_Click(object sender, EventArgs e)
        {
            int i = dgvHoadon.CurrentRow.Index;
            txtTenkhachhang_ql.Text = dgvHoadon[2, i].Value.ToString();
            txtCMND_ql.Text = dgvHoadon[3, i].Value.ToString();
            txtMahoadon_ql.Text = dgvHoadon[1, i].Value.ToString();
        }

        private void btnCapnhathoadon_Click(object sender, EventArgs e)
        {
            try
            {
                int mahoadon = int.Parse(txtMahoadon_ql.Text);
                string tenkhachhang = txtTenkhachhang_ql.Text;
                string cmnd = txtCMND_ql.Text;
                int status = hoadon.capnhathoadon(mahoadon, tenkhachhang, cmnd);
                if (status > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    loadhoadon();
                }
            }
             catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btnXoahoadon_Click(object sender, EventArgs e)
        {
            try
            {
                int mahoadon = int.Parse(txtMahoadon_ql.Text);
                DialogResult xoa = MessageBox.Show("Bạn có muốn xóa hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo);
                if (xoa == DialogResult.Yes)
                {
                    int status = hoadon.xoahoadon(mahoadon);
                    if (status > 0)
                        MessageBox.Show("Xóa hóa đơn thành công");
                    loadhoadon();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
