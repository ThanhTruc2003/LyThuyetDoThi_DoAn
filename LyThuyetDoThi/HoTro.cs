using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyThuyetDoThi
{
    public class HoTro
    {
        public DoThi docfile()
        {
            return new DoThi();
        }
        public bool xetLienThong(DoThi doThi)
        {
            bool ketqua = true;

            // Khởi tạo danh sách đỉnh và danh sách cạnh từ đối tượng doThi
            List<Dinh> dinh = doThi.Dinh;
            List<Canh> canh = doThi.Canh; 

            // Số đỉnh
            int sodinh = dinh.Count;

            // Tạo ma trận kề
            // Ma trận kề được lưu trữ trong một mảng hai chiều có kích thước sodinh x sodinh
            int[,] a = new int[sodinh, sodinh];
            for (int i = 0; i < canh.Count; i++)
            {
                // IndexOf được sử dụng để tìm chỉ số của đỉnh trong danh sách đỉnh
                int u = dinh.IndexOf(canh[i].Dinhdau);
                int v = dinh.IndexOf(canh[i].Dinhcuoi);
                // Vì là đồ thị vô hướng nên việc gán = 1 sẽ đảm bảo ma trận kề đối xứng qua đường chéo chính
                // Tức là đỉnh u sẽ được nối với đỉnh v và ngược lại
                a[u, v] = a[v, u] = 1;
            }

            // Khởi tạo mảng visited và số miền liên thông
            int[] visited = new int[sodinh];
            int nSoMienLienThong = 0;

            // Hàm visit
            void visit(int i, int nLabel)
            {
                // Gán nhãn nLabel cho đỉnh i
                visited[i] = nLabel;

                // Gọi Visit với các đỉnh j chưa được viếng thăm và có nối với i
                for (int j = 0; j < sodinh; j++)
                {
                    if (visited[j] == 0 && a[i, j] != 0)
                    {
                        visit(j, nLabel);
                    }
                }
            }

            // Hàm XetLienThong
            void XetLienThong()
            {
                // Khởi tạo visited và số miền liên thông
                for (int i = 0; i < sodinh; i++)
                {
                    visited[i] = 0;
                }
                nSoMienLienThong = 0;

                // Duyệt qua tất cả các đỉnh
                for (int i = 0; i < sodinh; i++)
                {
                    if (visited[i] == 0)
                    {
                        nSoMienLienThong++;
                        visit(i, nSoMienLienThong);
                    }
                }
            }
            // Gọi hàm XetLienThong
            XetLienThong();
            // Kiểm tra số miền liên thông
            if (nSoMienLienThong == 0 || nSoMienLienThong > 1)
            {
                ketqua = false;
            }
            return ketqua;
        }
  
        public List<Dinh> timDuongDiThuatToanPrim(DoThi dothi, Dinh dinhBatDau)
        {
            List<Dinh> duongdi = new List<Dinh>();
            // Kiểm tra nếu đồ thị không có đỉnh hoặc không có cạnh
            if (dothi.Dinh.Count == 0 || dothi.Canh.Count == 0)
                return duongdi;
            // Chọn một đỉnh bất kỳ làm đỉnh xuất phát
            Dinh dinhBatKy = dinhBatDau;
            duongdi.Add(dinhBatKy);
            // Tạo một tập hợp chứa các đỉnh đã được thăm
            HashSet<Dinh> daTham = new HashSet<Dinh>();
            daTham.Add(dinhBatKy);
            // Kiểm tra nếu tồn tại cạnh có trọng số âm
            foreach (Canh canh in dothi.Canh)
            {
                if (canh.Trongso < 0)
                {
                    // Đồ thị có cạnh âm, không chạy thuật toán Prim
                    return duongdi;
                }
            }
            // Lặp cho đến khi tất cả các đỉnh được thăm
            while (duongdi.Count < dothi.Dinh.Count)
            {
                Canh canhNhoNhat = null;
                int trongSoNhoNhat = int.MaxValue;

                // Tìm cạnh có trọng số nhỏ nhất kết nối từ tập hợp đã thăm đến tập hợp chưa thăm
                foreach (Canh canh in dothi.Canh)
                {
                    if ((daTham.Contains(canh.Dinhdau) && !daTham.Contains(canh.Dinhcuoi)) ||
                        (daTham.Contains(canh.Dinhcuoi) && !daTham.Contains(canh.Dinhdau)))
                    {
                        if (canh.Trongso < trongSoNhoNhat)
                        {
                            trongSoNhoNhat = canh.Trongso;
                            canhNhoNhat = canh;
                        }
                    }
                }
                // Nếu không tìm thấy cạnh, thoát khỏi vòng lặp
                if (canhNhoNhat == null)
                    break;

                // Thêm đỉnh kề và cạnh tương ứng vào đường đi
                if (!daTham.Contains(canhNhoNhat.Dinhdau))
                {
                    duongdi.Add(canhNhoNhat.Dinhdau);
                    daTham.Add(canhNhoNhat.Dinhdau);
                }
                else if (!daTham.Contains(canhNhoNhat.Dinhcuoi))
                {
                    duongdi.Add(canhNhoNhat.Dinhcuoi);
                    daTham.Add(canhNhoNhat.Dinhcuoi);
                }
            }
            return duongdi;
        }

        public List<Dinh> timDuongDiThuatToanFordBellmanDoThiVoHuong(DoThi dothi, Dinh dinhBatDau, Dinh dinhCuoi)
        {
            List<Dinh> duongdi = new List<Dinh>();

            // Khởi tạo các giá trị ban đầu
            Dictionary<Dinh, int> khoangCach = new Dictionary<Dinh, int>();
            Dictionary<Dinh, Dinh> duongDiTruoc = new Dictionary<Dinh, Dinh>();

            // Khởi tạo khoảng cách và đường đi trước cho mỗi đỉnh trong đồ thị
            foreach (Dinh dinh in dothi.Dinh)
            {
                khoangCach[dinh] = int.MaxValue; // Đặt khoảng cách ban đầu là vô cùng
                duongDiTruoc[dinh] = null; // Đặt đường đi trước ban đầu là null
            }

            khoangCach[dinhBatDau] = 0; // Khoảng cách từ đỉnh bắt đầu đến chính nó là 0

            //Gán số lượng đỉnh và số lượng cạnh của đồ thị vào các biến.
            int soDinh = dothi.Dinh.Count;
            int soCanh = dothi.Canh.Count;

            // Thực hiện thuật toán Bellman-Ford
            // Với mỗi bước k từ 1 đến soDinh - 1
            // Duyệt qua tất cả các cạnh trong đồ thị
            // Cập nhật khoảng cách và đường đi trước đó nếu tìm thấy đường đi ngắn hơn.
            for (int k = 1; k <= soDinh - 1; k++)
            {
                for (int i = 0; i < soCanh; i++)
                {
                    Dinh u = dothi.Canh[i].Dinhdau; // Đỉnh đầu của cạnh
                    Dinh v = dothi.Canh[i].Dinhcuoi; // Đỉnh cuối của cạnh
                    int trongSo = dothi.Canh[i].Trongso; // Trọng số của cạnh

                    // Cập nhật khoảng cách và đường đi trước nếu tìm thấy đường đi ngắn hơn
                    if (khoangCach[u] != int.MaxValue && khoangCach[u] + trongSo < khoangCach[v])
                    {
                        khoangCach[v] = khoangCach[u] + trongSo;
                        duongDiTruoc[v] = u;
                    }

                    // Với đồ thị vô hướng, thêm đoạn code sau để xử lý cạnh ngược lại
                    if (khoangCach[v] != int.MaxValue && khoangCach[v] + trongSo < khoangCach[u])
                    {
                        khoangCach[u] = khoangCach[v] + trongSo;
                        duongDiTruoc[u] = v;
                    }
                }
            }
            bool ChuTrinhAm = false;
            // Kiểm tra xem có chứa chu trình âm hay không
            //Bằng cách duyệt qua tất cả các cạnh trong đồ thị và kiểm tra điều kiện.
            for (int i = 0; i < soCanh; i++)
            {
                Dinh u = dothi.Canh[i].Dinhdau;
                Dinh v = dothi.Canh[i].Dinhcuoi;
                int trongSo = dothi.Canh[i].Trongso;
                if (khoangCach[u] != int.MaxValue && khoangCach[u] + trongSo < khoangCach[v])
                {
                    ChuTrinhAm = true;
                    break;
                }

                // Kiểm tra cạnh ngược lại
                if (khoangCach[v] != int.MaxValue && khoangCach[v] + trongSo < khoangCach[u])
                {
                    ChuTrinhAm = true;
                    break;
                }
            }
            bool coDuongDi = duongDiTruoc[dinhCuoi] != null; // Kiểm tra xem có đường đi từ đỉnh bắt đầu đến đỉnh kết thúc

            if (!coDuongDi)
            {
                return null;
            }
            else
            {
                // Tạo đường đi từ đỉnh đầu đến đỉnh cuối
                //bằng cách đi ngược từ đỉnh cuối theo đường đi trước đó V
                //Và thêm các đỉnh vào danh sách duongdi
                Dinh dinhHienTai = dinhCuoi;
                while (dinhHienTai != null)
                {
                    duongdi.Add(dinhHienTai); // Thêm đỉnh vào danh sách đường đi
                    dinhHienTai = duongDiTruoc[dinhHienTai]; // Di chuyển đến đỉnh trước đó trong đường đi
                    if (dinhHienTai == dinhBatDau)
                    {
                        duongdi.Add(dinhHienTai); // Thêm đỉnh đầu vào danh sách đường đi
                        break;// Nếu gặp đỉnh bắt đầu, thêm đỉnh đầu vào danh sách và dừng vòng lặp.
                    }
                }

                duongdi.Reverse(); // Đảo ngược danh sách để có đường đi từ đỉnh cuối đến đỉnh đầu

                return duongdi;//Trả về danh sách duongdi là đường đi từ dinhBatDau đến dinhCuoi.
            }    
        }

        public List<Dinh> timDuongDiThuatToanFordBellmanDoThiCoHuong(DoThi dothi)
        {
            List<Dinh> duongdi = new List<Dinh>();
            return duongdi;
        }
    }
}
