using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CGaG_Lab09 {
    public class MainThread : Game {
        GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;
        Color BackgroundColor = new Color(30, 30, 30);

        List<Point> Points = new List<Point>( );

        public MainThread( ) {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize( ) {
            Utils.InitGraphicsDevice(GraphicsDevice);

            base.Initialize( );
        }

        protected override void LoadContent( ) {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load game content
        }

        protected override void UnloadContent( ) {
            // TODO: Unload any non ContentManager content
        }

        protected override void Update(GameTime time) {
            Input.Update( );
            if (Input.Keyboard.IsKeyDown(Keys.Escape)) {
                Exit( );
            }

            // TODO: Add update logic
            if (Input.IsMouseLeftButtonPressed( )) {
                Points.Add(Input.Mouse.Position);
            }

            base.Update(time);
        }

        protected override void Draw(GameTime time) {
            GraphicsDevice.Clear(BackgroundColor);

            // TODO: Add drawing code
            SpriteBatch.Begin( );
            foreach (var a in Points) {
                SpriteBatch.Draw(Utils.Simple, a.ToVector2( ), color: Color.Red, scale: new Vector2(5, 5), origin: new Vector2(1, 1));
            }
            for (float x = 0, xp = x, yp = 0; x < Graphics.PreferredBackBufferWidth; xp = x++) {
                float y = LabUtils.L(Points.ToArray( ), x);
                Utils.DrawLine(SpriteBatch, new Vector2(xp, yp), new Vector2(x, y), Color.Blue);
                yp = y;
            }
            Vector2 bp = Vector2.Zero;
            for (float x = 0; x < Points.Count; x += 0.01f) {
                if (x == 0) {
                    bp = LabUtils.CalcBezierCurve(Points.ToArray( ), x);
                } else {
                    Vector2 p = LabUtils.CalcBezierCurve(Points.ToArray( ), x);
                    Utils.DrawLine(SpriteBatch, bp, p, Color.Green);
                    bp = p;
                }
            }

            SpriteBatch.End( );

            base.Draw(time);
        }
    }
}