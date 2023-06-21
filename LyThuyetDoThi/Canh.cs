using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyThuyetDoThi
{
    public class Canh
    {
        int trongso = 0;
        Dinh dinhdau = new Dinh();
        Dinh dinhcuoi = new Dinh();

        public Canh()
        {
        }

        public Canh(int Trongso, Dinh Dinhdau, Dinh Dinhcuoi)
        {
            this.trongso = Trongso;
            this.dinhdau = Dinhdau;
            this.dinhcuoi = Dinhcuoi;
        }

        public int Trongso { get; set; }
        public Dinh Dinhdau { get; set; }
        public Dinh Dinhcuoi { get; set; }
        //public List<Canh> DanhSachCanh { get; set; }
    }
}
