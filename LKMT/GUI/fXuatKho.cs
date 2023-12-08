using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKMT.GUI
{
    public partial class fXuatKho : UserControl
    {
        public fXuatKho()
        {
            InitializeComponent();
            XuatKhoBUS.Instance.showXuatKho(dgvXuatKho);
            dgvXuatKho.Columns[0].HeaderText = "Mã phiếu xuất";
            dgvXuatKho.Columns[1].HeaderText = "Tên sản phẩm";
            dgvXuatKho.Columns[2].HeaderText = "Số lượng";
            dgvXuatKho.Columns[3].HeaderText = "Ngày xuất";
            dgvXuatKho.Columns[4].HeaderText = "Tổng tiền";
            SanPhamBUS.Instance.showListSP(cbSanPham);
        }

        private void fXuatKho_Load(object sender, EventArgs e)
        {
            lblMaphieuxuat.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nbSoLuong.Value = 0;
            txtTongtien.Text = "";
            cbSanPham.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (nbSoLuong.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtTongtien.Text))
            {
                MessageBox.Show("Vui lòng nhập tổng số tiền", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if(!SanPhamBUS.Instance.getSanPhamById(cbSanPham, int.Parse(nbSoLuong.Value.ToString())))
            {
                MessageBox.Show("Sản phẩm bạn mua đã vượt quá số lượng trong kho", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (XuatKhoBUS.Instance.themXuatKho(cbSanPham, int.Parse(nbSoLuong.Value.ToString()), txtTongtien.Text))
            {
                MessageBox.Show("Thêm xuất kho thành công!!", "Thông Báo", MessageBoxButtons.OK);
                XuatKhoBUS.Instance.showXuatKho(dgvXuatKho);
                button3_Click(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm xuất kho thất bại!!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void dgvXuatKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvXuatKho.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvXuatKho.Rows[e.RowIndex];
                    lblMaphieuxuat.Text = row.Cells[0].Value.ToString();
                    cbSanPham.SelectedText = row.Cells[1].Value.ToString();
                    nbSoLuong.Value = int.Parse(row.Cells[2].Value.ToString());
                    txtTongtien.Text = row.Cells[4].Value.ToString();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvXuatKho.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (XuatKhoBUS.Instance.xoaXuatKho(lblMaphieuxuat.Text))
                {
                    MessageBox.Show("Xóa xuất kho thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    XuatKhoBUS.Instance.showXuatKho(dgvXuatKho);
                    button3_Click(sender, e);
                    return;
                }
                else { 
                    MessageBox.Show("Xóa xuất kho thất bại!!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn xuất kho muốn xóa!!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
