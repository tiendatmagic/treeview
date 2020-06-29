using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using treeview.Class;

namespace treeview
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        DataTable tblCL;
        private void Form1_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            //txtmasach.Enabled = false;
            //txttieude.Enabled = false;
            //btnBoqua.Enabled = false;
            Loadbang();
            
        }

        private void Loadbang()
        {
            string sql;
            sql = "SELECT Masach,Tieude,Soluongsach,Dongia,TenNXB,MaTG FROM Sach";
            tblCL = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            bang.DataSource = tblCL; //Nguồn dữ liệu            
            bang.Columns[0].HeaderText = "Mã sách";
            bang.Columns[1].HeaderText = "Tên sách";
            bang.Columns[2].HeaderText = "Số lượng";
            bang.Columns[3].HeaderText = "Đơn giá";
            bang.Columns[4].HeaderText = "Thành tiền";
            bang.Columns[5].HeaderText = "Nhà xuất bản";
            bang.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            bang.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
            
            /*
            treeView1.DataSource = tblCL; //Nguồn dữ liệu            
            treeView1.Columns[0].HeaderText = "Mã chất liệu";
            treeView1.Columns[1].HeaderText = "Mã chất liệu";
            treeView1.Columns[0].Width = 100;
            treeView1.Columns[1].Width = 300;
            treeView1.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            treeView1.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
           /*
            treeView1.DataSource = tblCL;
            TreeNode tNode;

            
            treeView1.Nodes[0].Nodes.Add();
            treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");

            treeView1.Nodes[0].Nodes.Add("csharpcanban.com");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("String Tutorial");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Excel Tutorial");

            treeView1.Nodes[0].Nodes.Add("csharpcanban.com");
            treeView1.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
            treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");
            */
       
        }

        private void Form1_Shown(object sender, EventArgs e)
        {



        }



        private void button4_Click(object sender, EventArgs e)
        {
            //SqlDataAdapter ad = new SqlDataAdapter(SqlDataAdapter,conn
            
                
        }

        private void ResetValue()
        {
            txtmasach.Text = "";
            txttieude.Text = "";
        }

        private void bang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasach.Focus();
                return;
            }
            if (tblCL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmasach.Text = bang.CurrentRow.Cells["MaSach"].Value.ToString();
            txttieude.Text = bang.CurrentRow.Cells["Tieude"].Value.ToString();
            //btnSua.Enabled = true;
            //btnXoa.Enabled = true;
            //btnBoqua.Enabled = true;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;
            btnThem.Enabled = false;
            txtmasach.Enabled = true; //cho phép nhập mới
            ResetValue();
            txttieude.Focus();
        }
        


        

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtmasach.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasach.Focus();
                return;
            }
            if (txttieude.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttieude.Focus();
                return;
            }
            sql = "Select MaSach From Sach where MaSach=N'" + txtmasach.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmasach.Focus();
                return;
            }

            sql = "INSERT INTO Sach VALUES(N'" +
                txtmasach.Text + "',N'" + txttieude.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            Loadbang(); //Nạp lại DataGridView
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            ResetValue();
            txtmasach.Enabled = false;
        }

        private void btnBoqua_Click_1(object sender, EventArgs e)
        {
            ResetValue();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmasach.Enabled = false;
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmasach.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txtmasach.Text + "'";
                Class.Functions.RunSqlDel(sql);
                ResetValue();
                Loadbang();
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmasach.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttieude.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE Sach SET Tieude=N'" +
                txttieude.Text.ToString() +
                "' WHERE Machatlieu=N'" + txtmasach.Text + "'";
            Class.Functions.RunSQL(sql);
            Loadbang();
            ResetValue();
            btnBoqua.Enabled = false;
        }
    }
}
