using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyThuyetDoThi
{
    public class Dinh
    {
        string ten = "";
        int toadoX = 0;
        int toadoY = 0;

        public Dinh()
        {
        }

        public Dinh(string ten, int toadoX, int toadoY)
        {
            this.Ten = ten;
            this.ToadoX = toadoX;
            this.ToadoY = toadoY;
        }

        public string Ten { get; set; }
        public int ToadoX { get; set; }
        public int ToadoY { get; set; }
    }
}
