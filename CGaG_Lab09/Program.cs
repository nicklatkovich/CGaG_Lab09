using System;

namespace CGaG_Lab09 {
#if WINDOWS || LINUX
    public static class Program {
        [STAThread]
        static void Main( ) {
            using (var game = new MainThread( ))
                game.Run( );
        }
    }
#endif
}
