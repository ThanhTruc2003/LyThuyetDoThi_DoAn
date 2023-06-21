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

        public List<Dinh> timDuongDiThuatToanFordBellmanDoThiVoHuong(DoThi dothi)
        {
            List<Dinh> duongdi = new List<Dinh>();
            return duongdi;
        }
        public List<Dinh> timDuongDiThuatToanFordBellmanDoThiCoHuong(DoThi dothi)
        {
            List<Dinh> duongdi = new List<Dinh>();
            return duongdi;
        }
    }
}
