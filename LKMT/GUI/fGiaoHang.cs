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
    public partial class fGiaoHang : UserControl
    {
        public fGiaoHang()
        {
            InitializeComponent();
            GiaoHangBUS.Instance.showGiaoHang(dgvGiaoHang);
            dgvGiaoHang.Columns[0].HeaderText = "Id";
            dgvGiaoHang.Columns[1].HeaderText = "Mã phiếu xuất";
            dgvGiaoHang.Columns[2].HeaderText = "Tên khách hàng";
            dgvGiaoHang.Columns[3].HeaderText = "Số điện thoại";
            dgvGiaoHang.Columns[4].HeaderText = "Địa chỉ";
            dgvGiaoHang.Columns[5].HeaderText = "Ngày giao hàng";
            dgvGiaoHang.Columns[6].HeaderText = "PT thanh toán";
            dgvGiaoHang.Columns[7].HeaderText = "Tổng tiền PX";
            dgvGiaoHang.Columns[8].HeaderText = "Phí giao hàng";
            dgvGiaoHang.Columns[9].HeaderText = "Tổng tiền thanh toán";
            dgvGiaoHang.Columns[10].HeaderText = "Ghi chú";
            XuatKhoBUS.Instance.showListXuatKho(cbPhieuXuat);
            ThanhToanBUS.Instance.showListThanhToan(cbThanhToan);
        }

        private void fGiaoHang_Load(object sender, EventArgs e)
        {
            txtPhiShip.Text = "0";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtGiaoHang.Text = "";
            txtKhachHang.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            cbPhieuXuat.SelectedText = "";
            txtGhiChu.Text = "";
            cbThanhToan.SelectedText = "";
            txtPhiShip.Text = "0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập tổng số điện thoại", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtDiachi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(cbPhieuXuat.Text))
            {
                MessageBox.Show("Vui lòng nhập phiếu xuất", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(cbThanhToan.Text))
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (string.IsNullOrEmpty(txtPhiShip.Text))
            {
                MessageBox.Show("Vui lòng nhập phí ship", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (GiaoHangBUS.Instance.themGiaoHang(cbPhieuXuat,dtGiaoHang.Text, txtKhachHang.Text, txtSDT.Text, txtDiachi.Text, txtGhiChu.Text, cbThanhToan, txtPhiShip.Text))
            {
                MessageBox.Show("Thêm đơn giao hàng thành công!!", "Thông Báo", MessageBoxButtons.OK);
                GiaoHangBUS.Instance.showGiaoHang(dgvGiaoHang);
                btnLamMoi_Click(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm đơn giao hàng thất bại!!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void dgvGiaoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedRowCount = dgvGiaoHang.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount >= 1)
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = dgvGiaoHang.Rows[e.RowIndex];
                    lblGiaoHang.Text = row.Cells[0].Value.ToString();
                    cbPhieuXuat.SelectedText = row.Cells[1].Value.ToString();
                    txtKhachHang.Text = row.Cells[2].Value.ToString();
                    txtSDT.Text = row.Cells[3].Value.ToString();
                    txtDiachi.Text = row.Cells[4].Value.ToString();
                    txtPhiShip.Text = row.Cells[5].Value.ToString();
                    txtGhiChu.Text = row.Cells[6].Value.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dgvGiaoHang.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (GiaoHangBUS.Instance.suaGiaoHang(cbPhieuXuat, dtGiaoHang.Text, txtKhachHang.Text, txtSDT.Text, txtDiachi.Text, txtGhiChu.Text, cbThanhToan, txtPhiShip.Text))
                {
                    MessageBox.Show("Cập nhật thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    GiaoHangBUS.Instance.showGiaoHang(dgvGiaoHang);
                    btnLamMoi_Click(sender, e);
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn giao hàng muốn cập nhật!!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            Int32 selectedRowCount = dgvGiaoHang.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                if (GiaoHangBUS.Instance.xoaGiaoHang(int.Parse(lblGiaoHang.Text)))
                {
                    MessageBox.Show("Xóa phiếu giao hàng thành công!!", "Thông Báo", MessageBoxButtons.OK);
                    GiaoHangBUS.Instance.showGiaoHang(dgvGiaoHang);
                    btnLamMoi_Click(sender, e);
                    return;
                }
                else
                {
                    MessageBox.Show("Xóa phiếu giao hàng thất bại!!", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu giao hàng muốn xóa!!", "Thông Báo", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
