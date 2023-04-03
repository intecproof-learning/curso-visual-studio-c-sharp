namespace Finanzas.CursoVisualStudio.Forms.Demo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            String session = Guid.NewGuid().ToString();
            Application.Run(new Finanzas(session));
        }
    }
}