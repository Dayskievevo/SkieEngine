using System;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong {
    public class Dummy : GameObject {
        public Dummy(string name, Texture2D text) {
            this.name = name;
            _texture = text;
        }
        
        // components
        MouseState _mouseState;
        public string col = "null";

        public override void Start() {
            
        }
        
        public override void Update(GameTime gameTime){
            Box2D = new BoxCollider2D(height, width, position, false);
            Box2D.CheckCollisionDirectional(this);
            
            //col = box2D.isColliding ? "true" : "false";
            _mouseState = Mouse.GetState();
            
            position.X = _mouseState.Position.X - (rect.Width / 2);
            position.Y = _mouseState.Position.Y - (rect.Height / 2);
        }
    }
}