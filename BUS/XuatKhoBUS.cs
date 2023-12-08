using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class XuatKhoBUS
    {
        private static XuatKhoBUS instance;

        public static XuatKhoBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new XuatKhoBUS();
                return instance;
            }
        }
        public void showXuatKho(DataGridView data)
        {
            var result = from a in DAO.XuatKhoDAO.Instance.GetXuatKho() select new { 
                maphieuxuat = a.maphieuxuat,
                tensp = a.tensp,
                soluong = a.soluong,
                ngayxuat = a.ngayxuat,
                sotien = a.sotien
            };
            data.DataSource = result.ToList();
        }
        public bool themXuatKho(ComboBox cbSanPham, int soluong, string sotien)
        {
            xuatkho a = new xuatkho();
            sanpham nsp = cbSanPham.SelectedItem as sanpham;
            if (nsp != null)
            {
                a.id_sanpham = nsp.id_sanpham;
                a.maphieuxuat = DateTime.Now.ToString("yymmddhhmmssfff");
                a.soluong = soluong;
                a.ngayxuat = DateTime.Now;
                a.sotien = decimal.Parse(sotien);
            }
            return XuatKhoDAO.Instance.themXuatKho(a);
        }
        public bool xoaXuatKho(string maphieu)
        {
            return XuatKhoDAO.Instance.xoaXuatKho(maphieu);
        }
        public void showListXuatKho(ComboBox cbo)
        {
            cbo.DataSource = DAO.XuatKhoDAO.Instance.GetXuatKho();
            cbo.ValueMember = "maphieuxuat";
            cbo.DisplayMember = "maphieuxuat";
        }
    }
}
