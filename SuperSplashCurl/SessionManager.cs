using Microsoft.Xna.Framework;
using SuperSplashCurl.Boards;
using SuperSplashCurl.Curls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSplashCurl
{
    public static class SessionManager
    {
        public static Dictionary<GamePlayer, int> Players { get; private set; } = new Dictionary<GamePlayer, int>();
        public static Dictionary<GamePlayer, Queue<GameCurl>> NextCurls { get; private set; } = new Dictionary<GamePlayer, Queue<GameCurl>>();
        public static int WinningScore { get; private set; } = 0;
        public static GameBoard Board { get; private set; }
        

        public static void InitializePlayer(string name, int faceIndex, Color color)
        {
            GamePlayer player = new GamePlayer(Players.Keys.Count, name, faceIndex, color);
            Players[player] = 0;
            NextCurls[player] = new Queue<GameCurl>(3);
            for (int i = 0; i < 3; i++)
            {
                QueueNextCurl(player);
            }
        }

        internal static void InitializeBoard()
        {
            Board = GameBoard.Create<BoardRenderer>(10, 10);
        }

        public static void Reset()
        {
            Players.Clear();
            NextCurls.Clear();
            WinningScore = -1;
        }

        public static void QueueNextCurl(GamePlayer player)
        {
            if (NextCurls[player].Count == 3)
                return;
            NextCurls[player].Enqueue(GameCurl.CreateRandom());
        }
    }
}
