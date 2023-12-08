using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class GiaoHangBUS
    {
        private static GiaoHangBUS instance;

        public static GiaoHangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoHangBUS();
                return instance;
            }
        }
        public void showGiaoHang(DataGridView data)
        {
            var result = from a in DAO.GiaoHangDAO.Instance.GetGiaoHangs()
                         select new
                         {
                             idpgh = a.id_pgh,
                             maphieuxuat = a.maphieuxuat,
                             tenkhachhang = a.tenkhachhang,
                             sodienthoai = a.sodienthoai,
                             diachi = a.diachi,
                             ngaygiaohang = a.ngaygiaohang,
                             tenthanhtoan = a.TenThanhToan,
                             tongtienpx = a.tongtienpx,
                             phigiaohang = a.phigiaohang,
                             tongtienthanhtoan = a.tongtienthanhtoan,
                             ghichu = a.ghichu
                         };
            data.DataSource = result.ToList();
        }
        public bool themGiaoHang(ComboBox cbPhieuXuat, string ngaygiaohang, string tenkh, string sdt, string diachi, string ghichu, ComboBox cbThanhtoan, string phiship)
        {
            phieugiaohang a = new phieugiaohang();
            xuatkho cbXk = cbPhieuXuat.SelectedItem as xuatkho;
            phuongthucthanhtoan cbtt = cbThanhtoan.SelectedItem as phuongthucthanhtoan;
            if (cbXk != null && cbtt != null)
            {
                a.ngaygiaohang = DateTime.Parse(ngaygiaohang);
                a.tenkhachhang = tenkh;
                a.sodienthoai = sdt;
                a.diachi = diachi;
                a.ghichu = ghichu;
                a.maphieuxuat = cbXk.maphieuxuat;
                a.phuongthucthanhtoanId = cbtt.id_thanhtoan;
                a.phigiaohang = decimal.Parse(phiship);
                var phieuxuat = XuatKhoDAO.Instance.findXuatKhoById(cbXk.maphieuxuat);
                if(phieuxuat == null || phieuxuat.Id == 0)
                {
                    return false;
                }
                a.tongtienpx = phieuxuat.sotien;
                a.tongtienthanhtoan = a.phigiaohang + a.tongtienpx;
            }
            return GiaoHangDAO.Instance.themGiaoHang(a);
        }
        public bool suaGiaoHang(ComboBox cbPhieuXuat, string ngaygiaohang, string tenkh, string sdt, string diachi, string ghichu, ComboBox cbThanhtoan, string phiship)
        {
            phieugiaohang a = new phieugiaohang();
            xuatkho cbXk = cbPhieuXuat.SelectedItem as xuatkho;
            phuongthucthanhtoan cbtt = cbThanhtoan.SelectedItem as phuongthucthanhtoan;
            if (cbXk != null && cbtt != null)
            {
                a.ngaygiaohang = DateTime.Parse(ngaygiaohang);
                a.tenkhachhang = tenkh;
                a.sodienthoai = sdt;
                a.diachi = diachi;
                a.ghichu = ghichu;
                a.maphieuxuat = cbXk.maphieuxuat;
                a.phuongthucthanhtoanId = cbtt.id_thanhtoan;
                a.phigiaohang = decimal.Parse(phiship);      
            }
            return GiaoHangDAO.Instance.suaGiaoHang(a);
        }
        public bool xoaGiaoHang(int id)
        {
            return GiaoHangDAO.Instance.xoaGiaoHang(id);
        }
    }
}
