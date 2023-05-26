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
        public List<Dinh> timDuongDiThuatToanFordBellmanDoThiCoHuongTrongSoAm(DoThi dothi)
        {
            List<Dinh> duongdi = new List<Dinh>();
            System.Diagnostics.Debug.WriteLine("Test");
            return duongdi;
        }
        public List<Dinh> timDuongDiThuatToanFordBellmanDoThiCoHuongTrongSoDuong(DoThi dothi)
        {
            List<Dinh> duongdi = new List<Dinh>();
            return duongdi;
        }
    }
}
