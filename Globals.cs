using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Globals
    {
        // PUBLIC GLOBAL VARIABLES THAT CAN BE ACCESSED FROM ANYWHERE
        public static SpriteBatch spriteBatch;
        public static int WIDTH = 640, HEIGHT = 480;
        public static Texture2D pixel;
        public static int player1_score, player2_score;
        public static int win = 3;

        public enum GAME_STATE
        {
            MENU,
            GAME,
            OVER
        }
    }
}
