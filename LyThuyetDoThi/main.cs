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
        private DoThi dothibandau;
        private int widthDinh = 180;
        private int heightDinh = 100;
        private int heightTextbox = 46;
        private int DuongKinh = 20;
        private int ToaDoX_DinhDauTien = 137;
        private int ToaDoY_DinhDauTien = 99;
        private int TrongSoCanhDaThem = 0;
        private Bitmap graphImage;

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

            if (graphImage != null)
            {
                e.Graphics.DrawImage(graphImage, 0, 0);
            }
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
            // Tạo một bitmap mới có kích thước tương tự với panel_Graph
            graphImage = new Bitmap(panel_Graph.Width, panel_Graph.Height);

            // Lấy graphics từ bitmap
            using (Graphics g = Graphics.FromImage(graphImage))
            {
                // Vẽ các đỉnh trên đồ thị
                foreach (Dinh dinh in dt.Dinh)
                {
                    // Vẽ đỉnh dưới dạng hình tròn
                    int x = dinh.ToadoX;
                    int y = dinh.ToadoY;
                    g.FillEllipse(Brushes.Red, x, y, DuongKinh, DuongKinh);
                    g.DrawString(dinh.Ten, new Font("Arial", 14), Brushes.Black, x - 7, y - 20);
                }
            }
            // Vẽ lại graphImage trên panel_Graph
            panel_Graph.Refresh();
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
                MessageBox.Show("Đỉnh đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbThemDinh.Text = "";
            }    
            else
            {
                // Tạo đỉnh đầu tiên
                if (length == 0)
                {
                    newDinh.Ten = tenDinh;
                    newDinh.ToadoX = ToaDoX_DinhDauTien;
                    newDinh.ToadoY = ToaDoY_DinhDauTien;
                    dt.Dinh.Add(newDinh);
                    veDinh();
                }
                // Tạo đỉnh tiếp theo
                else if (length > 0)
                {
                    // Lấy đỉnh cuối của mảng Đỉnh
                    Dinh dinhCuoi = dt.Dinh[length - 1];

                    // Kiểm tra tọa độ x của đỉnh được tạo với chiều rộng của panel_Graph
                    if (dinhCuoi.ToadoX + DuongKinh + widthDinh >= panel_Graph.Width - 1)
                    {
                        // Kiểm tra tọa độ y của đỉnh được tạo với (chiều cao của panel_Graph - chiều cao của textbox)
                        if (dinhCuoi.ToadoY + DuongKinh + heightDinh >= panel_Graph.Height - heightTextbox)
                        {
                            MessageBox.Show("Không thể thêm đỉnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;      // Thoát khỏi hàm
                        }
                        else
                        {
                            // Gán giá trị tọa độ x của đỉnh được tạo = với giá trị tọa độ x đỉnh đầu tiên
                            // Gía trị tọa độ y của đỉnh được tạo = giá trị tọa độ y đỉnh đầu tiên + đường kính của hình tròn được vẽ + khoảng cách chiều cao của 2 đỉnh
                            newDinh.ToadoX = ToaDoX_DinhDauTien;
                            newDinh.ToadoY = dinhCuoi.ToadoY + DuongKinh + heightDinh;
                        }
                    }
                    else
                    {
                        // Gán giá trị tọa độ x của đỉnh được tạo = giá trị tọa độ x của đỉnh đầu tiên + đường kính của hình tròn được vẽ + khoảng cách chiều rộng của 2 đỉnh
                        // Gán giá trị tọa độ y của đỉnh được tạo = giá trị tọa độ y của đỉnh đầu tiên
                        newDinh.ToadoX = dinhCuoi.ToadoX + DuongKinh + widthDinh;
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
            panel_Graph.Refresh();
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

        private bool KiemTraCanhDaTonTai(string dinhDau, string dinhCuoi)
        {
            // Duyệt qua danh sách các cạnh trong List Canh cua dothi
            foreach (Canh canh in dt.Canh)
            {
                // Kiểm tra xem cạnh mới có đỉnh đầu và đỉnh cuối như cạnh đã cho hay không
                if ((canh.Dinhdau.Ten == dinhDau && canh.Dinhcuoi.Ten == dinhCuoi) ||
                    (canh.Dinhdau.Ten == dinhCuoi && canh.Dinhcuoi.Ten == dinhDau))
                {
                    return true; // Cạnh đã tồn tại
                }
            }
            return false; // Cạnh chưa tồn tại
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
                TrongSoCanhDaThem = Convert.ToInt16(txbTrongSo.Text);
                /* Phương thức FirstOrDefault trả về phần tử đầu tiên của danh sách Dinh trong class DoThi theo điều kiện, nếu không có phần tử thoả mãn,
                   kết quả trả về sẽ là giá trị default của object (thường là null) */
                Dinh DinhDauDaTonTai = dt.Dinh.FirstOrDefault(d => d.Ten == DinhDau);
                Dinh DinhCuoiDaTonTai = dt.Dinh.FirstOrDefault(d => d.Ten == DinhCuoi);
                if (DinhDauDaTonTai == null || DinhCuoiDaTonTai == null)
                {
                    MessageBox.Show("Không tìm thấy đỉnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (TrongSoCanhDaThem == 0)
                {
                    MessageBox.Show("Không thể thêm cạnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
                else
                {
                    if (DinhDauDaTonTai == DinhCuoiDaTonTai)
                    {
                        MessageBox.Show("Hai đỉnh trùng nhau", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (KiemTraCanhDaTonTai(DinhDau, DinhCuoi))
                        {
                            MessageBox.Show("Cạnh này đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Canh newCanh = new Canh();
                            newCanh.Dinhdau = DinhDauDaTonTai;
                            newCanh.Dinhcuoi = DinhCuoiDaTonTai;
                            newCanh.Trongso = TrongSoCanhDaThem;
                            dt.Canh.Add(newCanh);
                            veCanh();
                        }
                    }
                }
                // Clear giá trị đầu vào
                txbDinhDau.Text = "";
                txbDinhCuoi.Text = "";
                txbTrongSo.Text = "";
            }     
        }

        private void xoaDinh(string tenDinh)
        {
            // Xóa đỉnh khỏi danh sách đỉnh
            // Tạo một biến dinhXoa kiểu Dinh và khởi tạo nó bằng null. Biến này sẽ được sử dụng để lưu đỉnh cần xóa.
            Dinh dinhXoa = null;
            foreach (Dinh dinh in dt.Dinh)
            {
                // Kiểm tra xem tên của đỉnh có trùng khớp với tenDinh (tên đỉnh cần xóa) hay không.
                // Nếu có, gán giá trị của dinhXoa bằng đỉnh hiện tại và dừng vòng lặp bằng lệnh break.
                if (dinh.Ten == tenDinh)
                {
                    dinhXoa = dinh;
                    break;
                }
            }
            if (dinhXoa != null)
            {
                // Kiểm tra xem giá trị của dinhXoa có khác null hay không.
                // Nếu có, là đã tìm thấy đỉnh cần xóa trong danh sách dt.Dinh và sử dụng phương thức Remove để xóa đỉnh.
                dt.Dinh.Remove(dinhXoa);
            }
        }

        private void bt_xoaDinh_Click(object sender, EventArgs e)
        {
            string tenDinhXoa = txbXoaDinh.Text;
            if (tenDinhXoa == "")
            {
                MessageBox.Show("Vui lòng nhập đỉnh cần xóa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem đỉnh có tồn tại trong danh sách không
            bool dinhTonTai = false;
            foreach (Dinh dinh in dt.Dinh)
            {
                if (dinh.Ten == tenDinhXoa)
                {
                    dinhTonTai = true;
                    break;
                }
            }
            if (dinhTonTai)
            {
                xoaDinh(tenDinhXoa);
                int length = dt.Dinh.Count;
                for (int i = 0; i < length; i++)
                {
                    if (i == 0)
                    {
                        // Nếu đây là đỉnh đầu tiên, không có đỉnh trước đó, vì vậy không thể tính toán tọa độ dựa trên đỉnh trước đó.
                        dt.Dinh[i].ToadoX = ToaDoX_DinhDauTien;
                        dt.Dinh[i].ToadoY = ToaDoY_DinhDauTien;
                    }
                    else
                    {
                        // Tính toán tọa độ của đỉnh hiện tại dựa trên đỉnh trước đó
                        Dinh dinhTruoc = dt.Dinh[i - 1];
                        if (dinhTruoc.ToadoX + DuongKinh + widthDinh >= graphImage.Width)
                        {
                            if (dinhTruoc.ToadoY + DuongKinh + heightDinh >= graphImage.Height)
                            {
                                MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // Đặt tọa độ X của đỉnh hiện tại bằng tọa độ X của đỉnh đầu tiên
                                // Tọa độ Y của đỉnh hiện tại bằng tọa độ Y của đỉnh trước + đường kính hình tròn được vẽ + khoảng cách chiều cao giữa 2 đỉnh
                                dt.Dinh[i].ToadoX = ToaDoX_DinhDauTien;                         
                                dt.Dinh[i].ToadoY = dinhTruoc.ToadoY + DuongKinh + heightDinh; 
                            }    
                        }
                        else
                        {
                            // Đặt tọa độ Y của đỉnh hiện tại bằng tọa độ Y của đỉnh đầu tiên
                            // Tọa độ X của đỉnh hiện tại bằng tọa độ X của đỉnh trước + đường kính hình tròn được vẽ + khoảng cách chiều rộng giữa 2 đỉnh
                            dt.Dinh[i].ToadoX = dinhTruoc.ToadoX + DuongKinh + widthDinh; 
                            dt.Dinh[i].ToadoY = dinhTruoc.ToadoY; 
                        }   
                    }
                }
                veDinh(); // Vẽ lại các đỉnh còn lại trên graphImage
                txbXoaDinh.Text = "";
            }
            else
            {
                MessageBox.Show("Đỉnh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbXoaDinh.Text = "";
            }
        }

        private void bt_xoaCanh_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (txbDinhDauCanXoa.Text == "" || txbDinhCuoiCanXoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đỉnh", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string dinhDauCanXoa = txbDinhDauCanXoa.Text;
                string dinhCuoiCanXoa = txbDinhCuoiCanXoa.Text;
                Canh canhDaTonTai = dt.Canh.FirstOrDefault(c => c.Dinhdau.Ten == dinhDauCanXoa && c.Dinhcuoi.Ten == dinhCuoiCanXoa);
                if (canhDaTonTai == null)
                {
                    MessageBox.Show("Không tìm thấy cạnh", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    int trongSo = canhDaTonTai.Trongso; // Lấy trọng số của cạnh
                    dt.Canh.Remove(canhDaTonTai);
                    MessageBox.Show($"Đã xóa cạnh với trọng số {trongSo}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    veCanh();
                }
            }
            txbDinhDauCanXoa.Text = "";
            txbDinhCuoiCanXoa.Text = "";
        }

        private void toMau(List<Dinh> duongDi)
        {
            Graphics g = panel_Graph.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 5);
            // Vòng lặp for để duyệt qua các đỉnh trong duongDiThuatToanPrim.
            // Trừ đi 1 ở điều kiện i < duongDiThuatToanPrim.Count - 1 để tránh truy cập đỉnh vượt quá chỉ số cuối cùng.
            for (int i = 0; i < duongDi.Count - 1; i++)
            {
                Dinh dinhDau = duongDi[i];
                Dinh dinhCuoi = duongDi[i + 1];
                Canh canh = dt.Canh.FirstOrDefault(c => (c.Dinhdau == dinhDau && c.Dinhcuoi == dinhCuoi) || (c.Dinhdau == dinhCuoi && c.Dinhcuoi == dinhDau));
                // Nếu canh khác null, tức là đã tìm thấy cạnh tương ứng với đường đi Prim
                if (canh != null)
                {
                    int x1 = dinhDau.ToadoX + 10;
                    int y1 = dinhDau.ToadoY + 10;
                    int x2 = dinhCuoi.ToadoX + 10;
                    int y2 = dinhCuoi.ToadoY + 10;
                    // Vẽ cạnh thuộc đường đi Prim bằng màu sắc xanh
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        private int tinhTongTrongSo(List<Dinh> duongDiThuatToanPrim)
        {
            int tongTrongSo = 0;
            for (int i = 0; i < duongDiThuatToanPrim.Count - 1; i++)
            {
                Dinh dinhDau = duongDiThuatToanPrim[i];
                Dinh dinhCuoi = duongDiThuatToanPrim[i + 1];
                foreach (Canh canh in dt.Canh)
                {
                    if ((canh.Dinhdau == dinhDau && canh.Dinhcuoi == dinhCuoi) ||
                        (canh.Dinhdau == dinhCuoi && canh.Dinhcuoi == dinhDau))
                    {
                        tongTrongSo += canh.Trongso;
                        break;
                    }
                }
            }
            return tongTrongSo;
        }

        private void bt_Prim_Click(object sender, EventArgs e)
        {
            string tenDinh = txb_Prim.Text;
            Dinh dinhBatDau = dt.Dinh.FirstOrDefault(d => d.Ten == tenDinh);
            if (txb_Prim.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đỉnh", "Warming", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                List<Dinh> duongDiThuatToanPrim = new HoTro().timDuongDiThuatToanPrim(dt, dinhBatDau);
                toMau(duongDiThuatToanPrim);
                // Tính tổng trọng số cây khung nhỏ nhất
                int tongTrongSo = tinhTongTrongSo(duongDiThuatToanPrim);
                
                // Kết hợp các giá trị của thuộc tính Ten của các đối tượng trong danh sách duongDiThuatToanPrim thành một chuỗi duy nhất, với chuỗi phân tách " -> " nằm giữa các giá trị.
                // Kết quả là một chuỗi sẽ hiển thị các tên của các đỉnh trong danh sách được nối lại với nhau, ngăn cách bằng chuỗi phân tách. 
                string ketLuan = "Vậy cây khung nhỏ nhất của đồ thị là: " + string.Join(" -> ", duongDiThuatToanPrim.Select(d => d.Ten));
                
                // \r\n dùng để xuống dòng
                ketLuan += "\r\nTổng trọng số của cây khung là: " + tongTrongSo;
                txb_KetLuan.Text = ketLuan;
            }
            txb_Prim.Text = "";
        }

        private void bt_XetLienThong_Click(object sender, EventArgs e)
        {

        }

        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            // Xóa và vẽ lại các đỉnh và cạnh trên panel_Graph
            panel_Graph.Refresh();
            veCanh();
            txb_KetLuan.Text = "";
        }

        private void bt_XoaDoThi_Click(object sender, EventArgs e)
        {
            dt.Dinh.Clear();    // Xóa tất cả các đỉnh trong danh sách dt.Dinh
            dt.Canh.Clear();    // Xóa tất cả các cạnh trong danh sách dt.Canh

            // Xóa đồ thị trên panel_Graph bằng cách vẽ lại graphImage rỗng
            graphImage = new Bitmap(panel_Graph.Width, panel_Graph.Height);
            // Refresh() để hiển thị panel rỗng
            panel_Graph.Refresh();
            txb_KetLuan.Text = "";
        }
    }
}