using System;

namespace SuperSplashCurl
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        public static Random Random = new Random(DateTime.Now.GetHashCode());

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
