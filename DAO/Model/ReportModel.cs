using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class ReportModel
    {
        public string id_sanpham { get; set; }
        public string tensanpham { get; set; }
        public int TongSoLuongNhap { get; set; }
        public int TongSoLuongXuat { get; set; }
        public decimal TongTienNhap { get; set; }   
        public decimal TongTienXuat { get;set; }
    }
}
