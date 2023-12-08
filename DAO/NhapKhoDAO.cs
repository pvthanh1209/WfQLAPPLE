using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class NhapKhoDAO
    {
        private static NhapKhoDAO instance;
        public static NhapKhoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhapKhoDAO();
                return instance;
            }
        }
        public List<PhieuNhapModel> GetPhieunhaps()
        {
            List<PhieuNhapModel> dsPhieuNhap = new List<PhieuNhapModel>();

            dsPhieuNhap = DataProvider.Ins.DB.phieunhaps.Join(DataProvider.Ins.DB.sanphams,
                p => p.id_sanpham,
                s => s.id_sanpham,
                (p, s) => new PhieuNhapModel
                {
                    id_phieunhap = p.id_phieunhap,
                    id_sanpham = p.id_sanpham,
                    soluongsp = p.soluongsp,
                    gianhap = p.gianhap,
                    ngaynhap = p.ngaynhap,
                    tensanpham = s.tensanpham
                }).ToList();

            return dsPhieuNhap;
        }
        public bool themPhieuNhap(phieunhap pn)
        {
            phieunhap a = findPhieuNhap(pn.id_phieunhap);
            var sp = SanPhamDAO.Instance.findSanPham(pn.id_sanpham);
            if (a == null && sp != null)
            {
                sp.soluong = sp.soluong + pn.soluongsp;
                DataProvider.Ins.DB.phieunhaps.Add(pn);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public phieunhap findPhieuNhap(int id)
        {
            phieunhap a = null;
            a = DataProvider.Ins.DB.phieunhaps.Find(id);
            if (a != null)
                return a;
            return null;
        }
    }
}
