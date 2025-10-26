using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BrickBreaker
{
    public abstract class GameObject
    {
        protected string textureName;
        public Texture2D texture;
        public Vector2 position;
        protected Game game;

        // constructor
        public GameObject(Game mygame)
        {
            this.game = mygame;
            position = Vector2.Zero;
        }
        public virtual void LoadContent()
        {
            if (!string.IsNullOrEmpty(textureName))
            {
                texture = game.Content.Load<Texture2D>(textureName);
            }
        }
        public virtual void Update(float deltaTime)
        {
            // Default update logic (if any)
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                Vector2 drawPosition = position;
                drawPosition.X -= texture.Width / 2;
                drawPosition.Y -= texture.Height / 2;
                spriteBatch.Draw(texture, drawPosition, Color.White);
            }
        }
    }
}


