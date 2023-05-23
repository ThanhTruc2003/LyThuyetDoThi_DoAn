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
            // Test ở đây

          
            ApplicationConfiguration.Initialize();
            Application.Run(new main());
        }
    }
}