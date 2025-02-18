using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLMonHoc : System.Web.UI.Page
    {
        MonHocDao mhDao = new MonHocDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LienKetDuLieu();
            }
        }

        private void LienKetDuLieu()
        {
            gvMonhoc.DataSource = mhDao.getAll();
            gvMonhoc.DataBind();
        }

        protected void gvMonhoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMonhoc_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gvMonhoc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // chọn vào slipt vào hình sấm sét click vô
            //chuyển trạng thái từ Reaonly - > edit + RowEditing
            gvMonhoc.EditIndex = e.NewEditIndex;
            LienKetDuLieu();
        }

        protected void gvMonhoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // cancel
            gvMonhoc.EditIndex = -1;
            LienKetDuLieu();
        }

        protected void gvMonhoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //b1 xóa  môn học
            string mamh = gvMonhoc.DataKeys[e.RowIndex].Value.ToString();
            //b1,2 goi phương thức xóa của lớp DAO
            mhDao.Delete(mamh);
            LienKetDuLieu();
        }

        protected void gvMonhoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //b1 cập nhật thông tin môn học xuống CSDL
            //b1.1 lấy thông tín môn học dòng hiện hành
            string mamh = gvMonhoc.DataKeys[e.RowIndex].Value.ToString();
            String tenmh = ((TextBox)gvMonhoc.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int sotiet = int.Parse(((TextBox)gvMonhoc.Rows[e.RowIndex].Cells[2].Controls[0]).Text);

            // nếu như bên    public int Update(MonHoc mh) chưa khai báo ra thì khai báo
            MonHoc mh = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
            //b1.2 gọi phương thức cập nhật lại cho lớp Dao
            mhDao.Update(mh);
            //b2 chuyển trạng thái từ Edit sang ReaOnly
            gvMonhoc.EditIndex = -1;
            LienKetDuLieu();
        }

        protected void btThem_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMH.Text;
            string tenMH = txtTenMH.Text;
            int soTiet;

            // Kiểm tra đầu vào
            if (int.TryParse(txtSoTiet.Text, out soTiet))
            {
          
            }
            else
            {
                lbThongBao.Text = "Số tiết phải là một số hợp lệ!";
                lbThongBao.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvMonhoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMonhoc.PageIndex = e.NewPageIndex;
            LienKetDuLieu();
        }
    }
    
}