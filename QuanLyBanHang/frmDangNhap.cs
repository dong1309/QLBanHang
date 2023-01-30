using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace QuanLyBanHang
{
    public partial class frmDangNhap : Form
    {

      
        public frmDangNhap()
        {
            InitializeComponent();
          
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           SqlConnection conn = new SqlConnection(@"Data Source =DESKTOP-IE75C7P; Initial Catalog = Quanlybanhang; Persist Security Info = T" +
            "rue;User ID=sa;Password=123456");
            try
            {
                conn.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = "select * from NguoiDung where TaiKhoan ='" + tk + "' and MatKhau ='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmMain main = new frmMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
       

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
