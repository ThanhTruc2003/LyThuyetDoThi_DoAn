using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LyThuyetDoThi
{
    public partial class main : Form
    {
        private DoThi dt;
        private int widthDinh = 180;
        private int heightDinh = 100;
        private int heightTextbox = 46;

        public main()
        {
            InitializeComponent();
            dt = new DoThi();
        }

        private void panel_Graph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Lấy thông tin kích thước của Panel_Graph
            int panel_GraphWidth = panel_Graph.Width;
            int panel_GraphHeight = panel_Graph.Height;

            // Vẽ hình chữ nhật trùng với kích thước của Panel_Graph
            Pen p = new Pen(Color.SkyBlue, 5);
            g.DrawRectangle(p, 0, 0, panel_GraphWidth - 1, panel_GraphHeight - 1);
        }

        private void panel_Feature_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Lấy thông tin kích thước của Panel_Feature
            int panel_FeatureWidth = panel_Feature.Width;
            int panel_FeatureHeight = panel_Feature.Height;

            // Vẽ hình chữ nhật trùng với kích thước của Panel_Feature
            Pen p = new Pen(Color.SkyBlue, 5);
            g.DrawRectangle(p, 0, 0, panel_FeatureWidth - 1, panel_FeatureHeight - 1);
        }

        private void veDinh()
        {
            // Lấy graphics từ panel_Graph
            Graphics g = panel_Graph.CreateGraphics();

            // Vẽ các đỉnh trên đồ thị
            foreach (Dinh dinh in dt.Dinh)
            {
                // Vẽ đỉnh dưới dạng hình tròn
                int x = dinh.ToadoX;
                int y = dinh.ToadoY;
                g.FillEllipse(Brushes.Red, x, y, 20, 20);
                g.DrawString(dinh.Ten, new Font("Arial", 14), Brushes.Black, x - 7, y - 20);
            }
        }

        private bool KiemTraTonTaiDinh(string tenDinh)
        {
            // Phương thức Exists dùng để duyệt phần tử trong danh sách Dinh, nếu phần tử tồn tại trong danh sách thì trả về true, ngược lại trả về false
            return dt.Dinh.Exists(dinh => dinh.Ten == tenDinh);
        }


        private void bt_themDinh_Click(object sender, EventArgs e)
        {
            Dinh newDinh = new Dinh();
            string tenDinh = txbThemDinh.Text;
            int length = dt.Dinh.Count;        // Lấy số lượng của lớp Đỉnh
            if (txbThemDinh.Text == "")
            {
                // Kiểm tra đầu vào
                MessageBox.Show("Vui lòng nhập đỉnh", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (KiemTraTonTaiDinh(tenDinh))
            {
                MessageBox.Show("Đỉnh đã tồn tại", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbThemDinh.Text = "";
            }    
            else
            {
                // Tạo đỉnh đầu tiên
                if (length == 0)
                {
                    newDinh.Ten = tenDinh;
                    newDinh.ToadoX = 137;
                    newDinh.ToadoY = 99;
                    dt.Dinh.Add(newDinh);
                    veDinh();
                }
                // Tạo đỉnh tiếp theo
                else if (length > 0)
                {
                    // Lấy đỉnh cuối của mảng Đỉnh
                    Dinh dinhCuoi = dt.Dinh[length - 1];

                    // Kiểm tra tọa độ x của đỉnh được tạo với chiều rộng của panel_Graph
                    if (dinhCuoi.ToadoX + 20 + widthDinh >= panel_Graph.Width - 1)
                    {
                        // Kiểm tra tọa độ y của đỉnh được tạo với (chiều cao của panel_Graph - chiều cao của textbox)
                        if (dinhCuoi.ToadoY + 20 + heightDinh >= panel_Graph.Height - heightTextbox)
                        {
                            MessageBox.Show("Không thể thêm đỉnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;      // Thoát khỏi hàm
                        }
                        else
                        {
                            // Gán giá trị tọa độ x của đỉnh được tạo = với giá trị tọa độ x đỉnh đầu tiên
                            // Gía trị tọa độ y của đỉnh được tạo = giá trị tọa độ y đỉnh đầu tiên + đường kính của hình tròn được vẽ + khoảng cách chiều cao của 2 đỉnh
                            newDinh.ToadoX = 137;
                            newDinh.ToadoY = dinhCuoi.ToadoY + 20 + heightDinh;
                        }
                    }
                    else
                    {
                        // Gán giá trị tọa độ x của đỉnh được tạo = giá trị tọa độ x của đỉnh đầu tiên + đường kính của hình tròn được vẽ + khoảng cách chiều rộng của 2 đỉnh
                        // Gán giá trị tọa độ y của đỉnh được tạo = giá trị tọa độ y của đỉnh đầu tiên
                        newDinh.ToadoX = dinhCuoi.ToadoX + 20 + widthDinh;
                        newDinh.ToadoY = dinhCuoi.ToadoY;
                    }
                    newDinh.Ten = tenDinh;
                    dt.Dinh.Add(newDinh);
                    veDinh();
                }
                // Clear giá trị đầu vào
                txbThemDinh.Text = "";
            }
        }

        private void veCanh()
        {
            // Lấy graphics từ panel_Graph
            Graphics g = panel_Graph.CreateGraphics();

            // Vẽ các cạnh trên đồ thị
            foreach (Canh canh in dt.Canh)
            {
                // Vẽ cạnh dưới dạng đường thẳng
                int x1 = canh.Dinhdau.ToadoX;
                int y1 = canh.Dinhdau.ToadoY;
                int x2 = canh.Dinhcuoi.ToadoX;
                int y2 = canh.Dinhcuoi.ToadoY;
                string trongso = Convert.ToString(canh.Trongso);
                Pen p = new Pen(Color.Black, 5);
                g.DrawLine(p, x1 + 10 , y1 + 10, x2 + 10, y2 + 10);     // các tọa độ + (đường kính hình tròn của đỉnh được vẽ / 2)

                // Vẽ trọng số
                Font font = new Font("Arial", 14);
                Brush brush = Brushes.Black;
                StringFormat stringFormat = new StringFormat();
                stringFormat.LineAlignment = StringAlignment.Center;    // Căn chỉnh dòng ở giữa
                stringFormat.Alignment = StringAlignment.Center;        // Căn lề giữa
                int trungdiemX = (x1 + x2) / 2;                         // Tọa độ x tại vị trí trung tâm của cạnh
                int trungdiemY = (y1 + y2) / 2;                         // Tọa độ y tại vị trí trung tâm của cạnh
                g.DrawString(trongso, font, brush, trungdiemX, trungdiemY, stringFormat);
            }
        }

        private void bt_themCanh_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (txbDinhDau.Text == "" || txbDinhCuoi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đỉnh", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string DinhDau = txbDinhDau.Text;
                string DinhCuoi = txbDinhCuoi.Text;
                int TrongSo = Convert.ToInt16(txbTrongSo.Text);
                
                /* Phương thức FirstOrDefault trả về phần tử đầu tiên của danh sách Dinh trong class DoThi theo điều kiện, nếu không có phần tử thoả mãn,
                   kết quả trả về sẽ là giá trị default của object (thường là null) */
                Dinh DinhDauDaTonTai = dt.Dinh.FirstOrDefault(d => d.Ten == DinhDau);
                Dinh DinhCuoiDaTonTai = dt.Dinh.FirstOrDefault(d => d.Ten == DinhCuoi);
                if (DinhDauDaTonTai == null || DinhCuoiDaTonTai == null)
                {
                    MessageBox.Show("Không tìm thấy đỉnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Canh newCanh = new Canh();
                    newCanh.Dinhdau = DinhDauDaTonTai;
                    newCanh.Dinhcuoi = DinhCuoiDaTonTai;
                    newCanh.Trongso = TrongSo;
                    dt.Canh.Add(newCanh);
                    veCanh();
                }
                // Clear giá trị đầu vào
                txbDinhDau.Text = "";
                txbDinhCuoi.Text = "";
                txbTrongSo.Text = "";
            }     
        }
        private void tomau_Canh(Graphics g, int x1, int y1, int x2, int y2, Color color1, Color color2)
        {

            // Tạo đối tượng Brush với màu sắc
            LinearGradientBrush brush = new LinearGradientBrush(new Point(x1, y1), new Point(x2, y2), color1, color2);

            // Vẽ cạnh với màu gradient
            Pen p1 = new Pen(brush, 5);
            g.DrawLine(p1, x1 + 10, y1 + 10, x2 + 10, y2 + 10);
        }
    }
}