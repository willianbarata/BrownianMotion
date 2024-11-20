using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotion.Models
{
    public class GraphicsDrawable : IDrawable
    {
        public Color LineColor { get; set; } = Colors.Red;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = LineColor;
            canvas.StrokeSize = 4;
            //canvas.StrokeDashPattern = new float[] { 2, 2 };
            canvas.DrawLine(10, 150, 20, 180);  // De dia 1 (preço 150) até dia 2 (preço 180)
            canvas.DrawLine(20, 180, 30, 70);  // De dia 2 (preço 180) até dia 3 (preço 170)
            canvas.DrawLine(30, 70, 40, 200);  // De dia 3 (preço 170) até dia 4 (preço 200)
            canvas.DrawLine(40, 200, 50, 08);  // De dia 4 (preço 200) até dia 5 (preço 190)
            canvas.DrawLine(50, 08, 60, 220);  // De dia 5 (preço 190) até dia 6 (preço 220)

            /* var centerX = dirtyRect.Center.X;
             var centerY = dirtyRect.Center.Y;

             var startX = centerX - 100;
             var startY = centerY - 100;
             var endX = centerX + 100;
             var endY = centerY + 100;

             canvas.DrawLine(startX, startY, endX, endY);   */

        }
    }
}
