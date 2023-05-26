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
            DoThi doThi = new DoThi();
            return doThi;
        }
        public bool xetLienThong(DoThi doThi)
        {
            bool ketqua = true;
            return ketqua;
        }
        public List<Dinh> timDuongDiThuatToanPrime(DoThi dothi)
        {
            List<Dinh> duongdi = new List<Dinh>();
            foreach (Dinh giatridinh in dothi.Dinh)
            {
                // xử lý thuật toán 
                System.Diagnostics.Debug.WriteLine(giatridinh.Ten);
                duongdi.Add(giatridinh);
            }
            foreach (Canh giatricanh in dothi.Canh)
            {
                // xử lý thuật toán 
                string xemcanh = giatricanh.Dinhdau.Ten + " -> " + giatricanh.Dinhcuoi.Ten + ":" + giatricanh.Trongso.ToString();
                System.Diagnostics.Debug.WriteLine(xemcanh);
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
