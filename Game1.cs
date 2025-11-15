using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BrickBreaker;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Paddle paddle;
    private Ball ball;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 1024;
        _graphics.PreferredBackBufferHeight = 768;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        paddle = new Paddle(this);
        paddle.LoadContent();
        paddle.position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height - 50);

        ball = new Ball(this);
        ball.LoadContent();
        ball.position = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        paddle.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        ball.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
        ball.CheckPaddleCollision(paddle);
        ball.CheckWallCollision();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Green);
        _spriteBatch.Begin();
        paddle.Draw(_spriteBatch);
        ball.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }


}
