namespace LyThuyetDoThi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HoTro hoTro = new HoTro();

            DoThi dothi = new DoThi();
            Dinh dinhA = new Dinh("A",1,1);
            Dinh dinhB = new Dinh("B",2,2);
            Dinh dinhC = new Dinh("C",3,3);

            Canh canhAB = new Canh(3,dinhA,dinhB);
            Canh canhAC = new Canh(3, dinhA, dinhC);

            dothi.Dinh.Add(dinhA);
            dothi.Dinh.Add(dinhB);
            dothi.Dinh.Add(dinhC);

            dothi.Canh.Add(canhAB);
            dothi.Canh.Add(canhAC);


            // Test ở đây

            //VD test timDuongDiThuatToanFordBellmanDoThiCoHuongTrongSoAm()
            List<Dinh> duongdi = hoTro.timDuongDiThuatToanPrime(dothi);
            foreach (Dinh giatridinh in duongdi)
            {
                // xử lý thuật toán 
                System.Diagnostics.Debug.WriteLine(giatridinh.Ten);
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new main());
        }
    }
}