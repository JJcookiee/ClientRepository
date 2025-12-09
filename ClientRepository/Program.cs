namespace ClientRepository
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            CreateDB.CreateDatabase();
            Application.Run(new Form1());
        }
    }
}