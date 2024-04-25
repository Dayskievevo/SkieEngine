using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace Pong
{
    class Manager
    {
        // PUBLIC GLOBAL VARIABLES THAT CAN BE ACCESSED FROM ANYWHERE
        public static bool DEBUGINFO = false;
        public static SpriteBatch spriteBatch;
        public static int WIDTH = 1280, HEIGHT = 960;
        public static int RESOLUTION_MODIFIER = 2;
        public static Texture2D pixel;
        public static List<GameObject> _gameObjects = new List<GameObject>();


        // what actually allows the gameobjects to be shown on screen
        // all gameobjects are stored in a big list so its easy to add
        // or remove them at runtime

        public static void Draw() {
            foreach(GameObject gameObject in _gameObjects) {
                gameObject.Draw(spriteBatch);
            }
        }
        
        public static string getGameObjects() {
            string temp = $"Total GameObjects = {_gameObjects.Count}\n Gameobjects: \n";
            foreach(var gameObject in _gameObjects)
            {
                temp += gameObject.getGameObject() + ": " +  gameObject.getGameObjectPos() + "\n";
            }

            return temp;
        }

        public static void DeleteGameObject(string gameObjectName) {
            foreach(var gameObject in _gameObjects) {
                if(gameObject.name.Equals(gameObjectName)) {
                    _gameObjects.Remove(gameObject);
                    return;
                }
            }
        }
    }
}
