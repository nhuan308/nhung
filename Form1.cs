using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace cau2_lan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void DanhSach()
        {
            string link = "http://localhost:90/Cau1Lan3/api/thuchanh";
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(NhanVien[]));
            object data = js.ReadObject(response.GetResponseStream());
            NhanVien[] danhsach = data as NhanVien[];
            dataGridView1.DataSource = danhsach;
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
              string postString = string.Format("?manv={0}&tenvn={1}&hsluong={2}", txtMaNV.Text, txtTenNV.Text, txtHSLuong.Text);
                String link = "http://localhost:90/Cau1Lan3/api/thuchanh" + postString;
                HttpWebRequest request = HttpWebRequest.CreateHttp(link);
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                byte[] byteArray = Encoding.UTF8.GetBytes(postString);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
                object data = js.ReadObject(request.GetResponse().GetResponseStream());
                bool kq = (bool)data;
                if (kq)
                {
                    DanhSach();
                    MessageBox.Show("Thêm thành công");
                }
                else
                    MessageBox.Show("Thêm ko thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string putString = string.Format("?manv={0}&tenvn={1}&hsluong={2}", txtMaNV.Text, txtTenNV.Text, txtHSLuong.Text);
            String link = "http://localhost:90/Cau1Lan3/api/thuchanh" + putString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteArray = Encoding.UTF8.GetBytes(putString);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                DanhSach();
                MessageBox.Show("sửa thành công");
            }
            else
                MessageBox.Show("Sửa ko thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string deleteString = string.Format("?manv={0}",txtHSLuong.Text);
            String link = "http://localhost:90/Cau1Lan3/api/thuchanh" + deleteString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] byteArray = Encoding.UTF8.GetBytes(deleteString);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                DanhSach();
                MessageBox.Show("Xóa thành công");
            }
            else
                MessageBox.Show("Xóa ko thành công");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
    }
}
