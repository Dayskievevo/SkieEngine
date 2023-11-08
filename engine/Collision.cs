using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong;

namespace Collision {
    public class BoxCollider2D {
        private int height, width;
        private Vector2 position;
        private bool isTrigger;
        public Rectangle collider;

        public BoxCollider2D(int h, int w, Vector2 pos, bool isTrigger) {
            height = h;
            width = w;
            position = pos;
            this.isTrigger = isTrigger;

            collider = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void setTrigger(bool isTrigger) {
            this.isTrigger = isTrigger;
        }

        public bool isColliding(GameObject owner) {
            foreach(GameObject gameObject in GameManager._gameObjects) {
                if(gameObject == owner) { continue; }
                return collider.Intersects(gameObject.rect);
            }
            return false;
        }
    }
}

