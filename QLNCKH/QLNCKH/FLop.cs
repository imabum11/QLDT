﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLNCKH
{
    public partial class FLop : Form
    {
        public FLop()
        {
            InitializeComponent();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {   //Tạo đối tượng conn
            SqlConnection conn = DB.GetDBConnection();
            string malop = txtmalop.Text;
            string tenlop = txttenlop.Text;
            string makhoa = cbmakhoa.Text;
            try
            {   //Tạo đối tượng cmd thao tác với sql thông qua store procedure
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Lop_Insert";
                cmd.Parameters.Add("@malop", SqlDbType.VarChar).Value = malop;
                cmd.Parameters.Add("@tenlop", SqlDbType.NVarChar).Value = tenlop;
                cmd.Parameters.Add("@makhoa", SqlDbType.VarChar).Value = makhoa;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm thành công");
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
            finally
            {
                conn.Close();
            }
        }

        private void FLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNCKHDataSet1.Khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.qLNCKHDataSet1.Khoa);
            // TODO: This line of code loads data into the 'qLDTDataSet1.Lop' table. You can move, or remove it, as needed.


        }

        private void btnxoa_Click(object sender, EventArgs e)
        {   //Giống với button thêm
            string malop = txtmalop.Text;
            SqlConnection conn = DB.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Lop_Delete";
                cmd.Parameters.Add("@malop", SqlDbType.VarChar).Value = malop;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã xóa thành công");
            }
            catch
            {
                MessageBox.Show("Xoá gặp lỗi");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {   //Giống với button thêm
            SqlConnection conn = DB.GetDBConnection();
            string malop = txtmalop.Text;
            string tenlop = txttenlop.Text;
            string makhoa = cbmakhoa.Text;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Lop_Update";
                cmd.Parameters.Add("@malop", SqlDbType.VarChar).Value = malop;
                cmd.Parameters.Add("@tenlop", SqlDbType.NVarChar).Value = tenlop;
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar).Value = makhoa;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thay đổi thành công");
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {   //Set giá trị rỗng cho các textfield và set vị trí cho con trỏ
            txtmalop.Text = "";
            txttenlop.Text = "";
            cbmakhoa.Text = "";
            this.ActiveControl = cbmakhoa;
        }
    }
}
