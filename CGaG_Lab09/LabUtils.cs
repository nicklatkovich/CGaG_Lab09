using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGaG_Lab09 {
    public static class LabUtils {

        public static float l(Point[ ] points, float x, uint index) {
            float result = 1f;
            for (uint i = 0; i < points.Length; i++) {
                if (i != index) {
                    result *= (x - points[i].X) / (points[index].X - points[i].X);
                }
            }
            return result;
        }

        public static float L(Point[ ] points, float x) {
            float result = 0f;
            for (uint i = 0; i < points.Length; i++) {
                result += points[i].Y * l(points, x, i);
            }
            return result;
        }

        public static Vector2 CalcBezierCurve(Point[ ] pt, float t) {
            int i, c;
            float p;
            Vector2 np;
            Vector2[ ] pts = new Vector2[pt.Length];
            for (uint j = 0; j < pt.Length; j++) {
                pts[j] = pt[j].ToVector2( );
            }
            int n = pts.Length - 1;

            c = 1;
            for (i = 0; i <= n; i++) {
                pts[i].X = pts[i].X * c;
                pts[i].Y = pts[i].Y * c;
                c = (n - i) * c / (i + 1);
            }
            p = 1;
            for (i = 0; i <= n; i++) {
                pts[i].X = pts[i].X * p;
                pts[i].Y = pts[i].Y * p;
                p = p * t;
            }
            p = 1;
            for (i = n; i >= 0; i--) {
                pts[i].X = pts[i].X * p;
                pts[i].Y = pts[i].Y * p;
                p = p * (1 - t);
            }
            np.X = 0;
            np.Y = 0;
            for (i = 0; i <= n; i++) {
                np.X = np.X + pts[i].X;
                np.Y = np.Y + pts[i].Y;
            }
            return np;
        }

    }
}
