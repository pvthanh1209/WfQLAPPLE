using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class GiaoHangDAO
    {
        private static GiaoHangDAO instance;
        public static GiaoHangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GiaoHangDAO();
                return instance;
            }
        }
        public List<GiaoHangModel> GetGiaoHangs()
        {
            List<GiaoHangModel> giaoHangs = new List<GiaoHangModel>();

            giaoHangs = DataProvider.Ins.DB.phieugiaohangs.Join(
                DataProvider.Ins.DB.phuongthucthanhtoans,
                g => g.phuongthucthanhtoanId,
                p => p.id_thanhtoan,
                (g,p) => new GiaoHangModel
                {
                    id_pgh = g.id_pgh,
                    ngaygiaohang = g.ngaygiaohang,
                    diachi = g.diachi,
                    tenkhachhang = g.tenkhachhang,
                    sodienthoai = g.sodienthoai,
                    maphieuxuat = g.maphieuxuat,
                    ghichu = g.ghichu,
                    phigiaohang = g.phigiaohang,
                    tongtienpx = g.tongtienpx,  
                    tongtienthanhtoan = g.tongtienthanhtoan,
                    phuongthucthanhtoanId = g.phuongthucthanhtoanId,
                    TenThanhToan = p.tenthanhtoan
                }).ToList();
            return giaoHangs;
        }
        public bool themGiaoHang(phieugiaohang pgh)
        {
            try
            {
                phieugiaohang a = findGiaoHang(pgh.id_pgh);
                if (a == null)
                {
                    DataProvider.Ins.DB.phieugiaohangs.Add(pgh);
                    DataProvider.Ins.DB.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }
        public bool suaGiaoHang(phieugiaohang pgh)
        {
            phieugiaohang temp = findGiaoHang(pgh.id_pgh);
            if (temp != null)
            {
                var xuatKhos = XuatKhoDAO.Instance.findXuatKhoById(temp.maphieuxuat);
                if(xuatKhos == null)
                {
                    return false;
                }
                temp.ngaygiaohang = pgh.ngaygiaohang;
                temp.diachi = pgh.diachi;
                temp.tenkhachhang = pgh.tenkhachhang;
                temp.maphieuxuat = pgh.maphieuxuat;
                temp.sodienthoai = pgh.sodienthoai;
                temp.ghichu = pgh.ghichu;
                temp.phigiaohang = pgh.phigiaohang;
                temp.tongtienpx = xuatKhos.sotien;
                temp.tongtienthanhtoan = temp.tongtienpx + temp.phigiaohang;
                temp.phuongthucthanhtoanId = pgh.phuongthucthanhtoanId;
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public phieugiaohang findGiaoHang(int id)
        {
            phieugiaohang a = null;
            a = DataProvider.Ins.DB.phieugiaohangs.Find(id);
            if (a != null)
                return a;
            return null;
        }
        public phieugiaohang findGiaoHangByMaPhieuXuat(string maphieu)
        {
            phieugiaohang a = null;
            a = DataProvider.Ins.DB.phieugiaohangs.Where(x => x.maphieuxuat.Equals(maphieu)).FirstOrDefault();
            if (a != null)
                return a;
            return null;
        }
        // lấy các phiếu xuất không có trong giao hàng
        public List<xuatkho> comBoxMaPhieu()
        {
            var list = new List<xuatkho>();
            var lstXuatKho = DataProvider.Ins.DB.xuatkhoes.ToList();
            foreach(var item in lstXuatKho)
            {
                var pgh = findGiaoHangByMaPhieuXuat(item.maphieuxuat);
                if(pgh == null)
                {
                    list.Add(item); 
                }
            }
            return list;
        }
        public bool xoaGiaoHang(int id)
        {
            phieugiaohang a = findGiaoHang(id);
            if (a != null && a.id_pgh > 0)
            {
                DataProvider.Ins.DB.phieugiaohangs.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
