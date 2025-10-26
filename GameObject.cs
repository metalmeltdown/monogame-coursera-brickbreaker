using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BrickBreaker
{
    public class GameObject
    {
        protected string TextureName;
        protected Texture2D Texture;
        protected Vector2 Position;
        protected Game1 game1;

        // constructor
        public GameObject()
        {
            Position = Vector2.Zero;
        }
    }
}


