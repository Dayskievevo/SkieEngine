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
        public bool isColliding;
        public bool isTouchingLeft, isTouchingRight, isTouhcingTop, IsTouchingBottom, boundsBottom, boundsTop;
        // checking screen collisions

        public bool isColLeft, isColRight;

        public bool isCollidingBounds;
        public Rectangle collider;

        // TODO: RESTRUCTRE SO THERE CAN BE DIFFERENT SHAPES OF COLLISION 
        // IMPLEMENT TRIGGER SO IT GETS ACTIVATED BUT THINGS PASS THROUGH IT
        // FIX WEIRD COLLISION BUG WITH MOVING OBJECTS
        // FIGURE OUT HOW TO GET DIRECTIONAL DETECTION?
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

        public void CheckCollisionDirectional(GameObject owner) {
            foreach(GameObject gameObject in GameManager._gameObjects) {
                if(gameObject == owner) {continue;}

                isTouchingRight = owner.rect.Left < gameObject.rect.Right && 
                                 owner.rect.Right > gameObject.rect.Right && 
                                 owner.rect.Bottom > gameObject.rect.Top && 
                                 owner.rect.Top < gameObject.rect.Bottom;

                isTouchingLeft = owner.rect.Right > gameObject.rect.Left && 
                                 owner.rect.Left < gameObject.rect.Left && 
                                 owner.rect.Bottom > gameObject.rect.Top && 
                                 owner.rect.Top < gameObject.rect.Bottom;

                isTouhcingTop = owner.rect.Bottom > gameObject.rect.Top &&
                                owner.rect.Top < gameObject.rect.Top &&
                                owner.rect.Right > gameObject.rect.Left &&
                                owner.rect.Left < gameObject.rect.Right;

                
                IsTouchingBottom = owner.rect.Top < gameObject.rect.Bottom &&
                                owner.rect.Bottom > gameObject.rect.Bottom &&
                                owner.rect.Right > gameObject.rect.Left &&
                                owner.rect.Left < gameObject.rect.Right;
                
                if(isTouchingLeft | isTouchingRight | isTouhcingTop || IsTouchingBottom) {
                    break;
                }
            }

            // WINDOW BOUNDS COLLISION


            // it would make sense for the is touching top to be the y position plus screen height
            // but monogames orgini is the top left corner so to go down you add values lolllll
            if(owner.position.Y + owner.rect.Height > GameManager.HEIGHT) {
                boundsBottom = true;
            }
            if(owner.position.Y < 0 ) {
                boundsTop = true;
            }
        }

        public void CheckCollisionSimple(GameObject owner) {

            // box2d
            // foreach(GameObject gameObject in GameManager._gameObjects) {
            //     if(gameObject == owner) { continue; }

            //     if(owner.rect.Right >= gameObject.rect.Left && owner.rect.Left <= gameObject.rect.Right && 
            //     owner.rect.Bottom >= gameObject.rect.Top && owner.rect.Top <= gameObject.rect.Bottom)
            //     {
            //        isColliding = true;
            //     }
            //     if(isColliding) {
            //         break;
            //     }
            // }

            // screen bounds checking
            if(owner.position.Y < 0 || owner.position.Y + owner.rect.Height > GameManager.HEIGHT) {
                isCollidingBounds = true;
            }
        }

    }
}

