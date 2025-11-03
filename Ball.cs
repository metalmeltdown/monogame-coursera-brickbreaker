using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker
{
    public class Ball : GameObject 
    {
        public Ball(Game mygame) : base(mygame)
        {
            textureName = "ball";
        }
    }
}