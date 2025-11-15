using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker
{
    public class Ball : GameObject
    {
        public Vector2 velocity;
        private float speed = 300f;
        private float radius => texture.Width / 2f;
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

            position += velocity * deltaTime;

            base.Update(deltaTime);
        }
        public void CheckWallCollision()
        {
            // tamanio de pantalla
            int screenWidth = game.GraphicsDevice.Viewport.Width;
            int screenHeight = game.GraphicsDevice.Viewport.Height;

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
                ResetBall();
            }
        }
        public void CheckPaddleCollision(Paddle paddle)
        {
            // colision con paddle
            Rectangle paddleRect = new Rectangle(
                (int) (paddle.position.X - paddle.texture.Width / 2),  // centro X - mitad del ancho = esquina izquierda
                (int) (paddle.position.Y - paddle.texture.Height / 2), // centro Y - mitad del alto = esquina superior
                paddle.texture.Width,   // ancho del paddle
                paddle.texture.Height   // alto del paddle
            );
            Rectangle ballRect = new Rectangle(
                (int)(position.X - radius),
                (int)(position.Y - radius),
                (int)(radius * 2),
                (int)(radius * 2)
            );

            if (ballRect.Intersects(paddleRect))
            {
                velocity.Y *= -1;
                position.Y = paddleRect.Top - radius;
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