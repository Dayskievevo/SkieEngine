using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Pong
{
    class GameManager
    {
        // PUBLIC GLOBAL VARIABLES THAT CAN BE ACCESSED FROM ANYWHERE
        public static SpriteBatch spriteBatch;
        public static int WIDTH = 1280, HEIGHT = 960;
        public static int RESOLUTION_MODIFIER = 2;
        public static Texture2D pixel;
        public static List<GameObject> _gameObjects = new List<GameObject>();

        public enum GAME_STATE
        {
            MENU,
            GAME,
            OVER
        }

        public static void Draw() {
            foreach(GameObject gameObject in _gameObjects) {
                gameObject.Draw(spriteBatch);
            }
        }
        
        public static string getGameObjects() {
            string temp = "Gameobjects: \n";
            foreach(var gameObject in _gameObjects)
            {
                temp += gameObject.getGameObject() + ": " +  gameObject.getGameObjectPos() + "\n";
            }

            return temp;
        }
    }
}
