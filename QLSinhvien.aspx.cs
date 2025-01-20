using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebQLDaoTao
{
    public partial class QLSinhvien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSinhVien();
            }
        }

        private void LoadSinhVien()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSV");
            dt.Columns.Add("HoTen");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("Lop");

            dt.Rows.Add("SV01", "Nguyen Van A", "Nam", "CNTT");
            dt.Rows.Add("SV02", "Tran Thi B", "Nu", "KinhTe");

            gvSinhVien.DataSource = dt;
            gvSinhVien.DataBind();
        }

        protected void btnAddSinhVien_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSinhVien.aspx");
        }
    }
    }
