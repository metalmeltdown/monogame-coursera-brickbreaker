using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker
{
    public class Ball : GameObject
    {
        public Vector2 velocity;
        private float speed = 30f;

        public Ball(Game mygame) : base(mygame)
        {
            textureName = "ball";
            Vector2 direction = new Vector2(0.7f, -0.7f);
            direction.Normalize(); // ← Importante: normalizar a longitud 1
            velocity = direction * speed;
        }
        public override void Update(float deltaTime)
        {
            // Física: posición += velocidad × tiempo

            position += velocity * speed * deltaTime;

            checkCollision();

            base.Update(deltaTime);
        }
        protected void checkCollision()
        {
            // tamanio de pantalla
            int screenWidth = game.GraphicsDevice.Viewport.Width;
            int screenHeight = game.GraphicsDevice.Viewport.Height;

            float radius = texture.Width / 2f;

            // colision con paredes
            if (position.X < radius)
            {
                position.X = radius;
                velocity.X *= -1;
            }
            else if (position.X > screenWidth - radius)
            {
                position.X = screenWidth - radius;
                velocity.X *= -1;
            }

            if (position.Y < radius)
            {
                position.Y = radius;
                velocity.Y *= -1;
            }
            else if (position.Y > screenHeight - radius)
            {
                // position.Y = screenHeight - radius;
                // velocity.Y *= -1;
                ResetBall();
            }
        }
        protected void ResetBall()
        {
            position = new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2);
            Vector2 direction = new Vector2(0.7f, -0.7f);
            direction.Normalize();
            velocity = direction * speed;
        }   
    }
}