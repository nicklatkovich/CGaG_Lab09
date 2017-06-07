using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGaG_Lab09 {
    public static class Utils {

        public static KeyboardState GetKeyboardState( ) {
            return Keyboard.GetState( );
        }

        public static MouseState GetMouseState( ) {
            return Mouse.GetState( );
        }

        public static void InitGraphicsDevice(GraphicsDevice gd) {
            Simple = new Texture2D(gd, 2, 2);
            Simple.SetData(new Color[ ] {
                Color.White,
                Color.White,
                Color.White,
                Color.White,
            });
        }

        public static Texture2D Simple {
            get; private set;
        }

        public static void DrawLine(SpriteBatch sb, Vector2 start, Vector2 end, Color color, float width = 1) {
            Vector2 edge = end - start;
            float angle = (float)Math.Atan2(edge.Y, edge.X);
            sb.Draw(Simple, new Rectangle(
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length( ), 1), null, color, angle, new Vector2(0, 0), SpriteEffects.None, 0);

        }

    }
}
