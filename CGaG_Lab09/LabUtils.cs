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

    }
}
