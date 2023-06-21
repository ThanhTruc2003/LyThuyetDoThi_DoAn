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
