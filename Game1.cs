using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tree;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public Texture2D texture;
    Grid grid;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        _graphics.PreferredBackBufferWidth = 600;
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.ApplyChanges();
    }

    protected override void Initialize()
    {


        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        texture = new Texture2D(GraphicsDevice, 1, 1);
        texture.SetData(new[] { Color.White });
        grid = new Grid(100, 100);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        KeyboardState keyboard = Keyboard.GetState();
        grid.Update();
        if (keyboard.IsKeyDown(Keys.Space))
        {
            grid = new Grid(100, 100);
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        for (int x = 0; x < grid.width; x++)
            for (int y = 0; y < grid.width; y++)
                if (!grid.cells[grid.convertToIndex(x, y)].empty)
                    _spriteBatch.Draw(texture, new Rectangle(x * 6, y * 6, 6, 6), grid.cells[grid.convertToIndex(x, y)].color);
        _spriteBatch.End();


        base.Draw(gameTime);
    }
}
