using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BrickBreaker
{
    public class Paddle : GameObject
    {
        
        // constructor
        public Paddle (Game mygame) : base(mygame)
        {
            textureName = "paddle";
        }

    }
}