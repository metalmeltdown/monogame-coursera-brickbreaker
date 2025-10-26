using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker
{
    public class Paddle : GameObject
    {
        float speed = 500f; // velocidad en pixels por segundo
        // constructor
        public Paddle(Game mygame) : base(mygame)
        {
            textureName = "paddle";
        }

        public override void Update(float deltaTime)
        {
            KeyboardState keystate = Keyboard.GetState();
        // float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (keystate.IsKeyDown(Keys.Right) || keystate.IsKeyDown(Keys.D))
        {
            this.position.X += speed * deltaTime;
        }
        else if (keystate.IsKeyDown(Keys.Left) || keystate.IsKeyDown(Keys.A))
        {
            this.position.X -= speed * deltaTime;
        }
        // evita colisiones con bordes de la pantalla
        this.position.X = MathHelper.Clamp(this.position.X, this.texture.Width / 2, game.GraphicsDevice.Viewport.Width - this.texture.Width / 2);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}