﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
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


        public static void Draw() {
            foreach(GameObject gameObject in _gameObjects) {
                // each gameobject is "drawn" to the scene
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
