using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGaG_Lab09 {
    public static class Input {

        public static KeyboardState Keyboard {
            get;
            private set;
        } = Utils.GetKeyboardState( );
        public static KeyboardState KeyboardPrevious {
            get;
            private set;
        }

        public static MouseState Mouse {
            get;
            private set;
        } = Utils.GetMouseState( );
        public static MouseState MousePrevious {
            get;
            private set;
        }

        public static void Update( ) {
            KeyboardPrevious = Keyboard;
            Keyboard = Utils.GetKeyboardState( );

            MousePrevious = Mouse;
            Mouse = Utils.GetMouseState( );
        }

        public static bool IsMouseLeftButtonPressed( ) {
            return (Mouse.LeftButton == ButtonState.Pressed && MousePrevious.LeftButton == ButtonState.Released);
        }

    }
}
