using DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class XuatKhoDAO
    {
        private static XuatKhoDAO instance;
        public static XuatKhoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new XuatKhoDAO();
                return instance;
            }
        }
        public List<XuatKhoModel> GetXuatKho()
        {
            List<XuatKhoModel> xuatkhos = new List<XuatKhoModel>();

            xuatkhos = DataProvider.Ins.DB.xuatkhoes.Join(DataProvider.Ins.DB.sanphams,
                        x => x.id_sanpham,
                        s => s.id_sanpham,
                        (x, s) => new XuatKhoModel
                        {
                            maphieuxuat = x.maphieuxuat,
                            id_sanpham = x.id_sanpham,
                            soluong = x.soluong,
                            ngayxuat = x.ngayxuat,
                            sotien = x.sotien,
                            tensp = s.tensanpham
                        }).ToList();
            return xuatkhos;
        }
        public bool themXuatKho(xuatkho xk)
        {
            var a = findXuatKhoById(xk.maphieuxuat);
            var sp = SanPhamDAO.Instance.findSanPham(xk.id_sanpham);
            if (a == null && sp != null)
            {
                sp.soluong = sp.soluong - xk.soluong;
                DataProvider.Ins.DB.xuatkhoes.Add(xk);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool suaXuatKho(xuatkho xk)
        {
            xuatkho temp = findXuatKhoById(xk.maphieuxuat);
            if (temp != null)
            {
                temp.id_sanpham = xk.id_sanpham;
                temp.soluong = xk.soluong;
                temp.sotien = xk.sotien;    
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public bool xoaXuatKho(string maphieuxuat)
        {
            xuatkho a = findXuatKhoById(maphieuxuat);
            if (a != null && a.Id > 0)
            {
                DataProvider.Ins.DB.xuatkhoes.Remove(a);
                DataProvider.Ins.DB.SaveChanges();
                return true;
            }
            return false;
        }
        public xuatkho findXuatKhoById(string maphieuxuat)
        {
            var a = DataProvider.Ins.DB.xuatkhoes.Where(x => x.maphieuxuat.Equals(maphieuxuat)).FirstOrDefault();
            return a;
        }
    }
}
