using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Model
{
    public class LoaiSPModel
    {
        public string id_loai { get; set; }
        public string id_nhom { get; set; }
        public string tenloai { get; set; }
        public System.DateTime ngaytao { get; set; }
        public System.DateTime ngaycapnhat { get; set; }
    }
}
