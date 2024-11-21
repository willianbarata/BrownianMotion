using Microsoft.Maui.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace BrownianMotion.MVVM.ViewModel
{
    public class PrecosDrawable : IDrawable
    {
        private readonly List<double> precos;
        public Color LineColor { get; set; } = Colors.White;
        public PrecosDrawable(double[] precos)
        {
            this.precos = new List<double>(precos);
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (precos == null || precos.Count == 0)
                return;

            canvas.StrokeColor = LineColor;

            float width = dirtyRect.Width;
            float height = dirtyRect.Height;
            float stepX = width / (precos.Count - 1);
            double maxPreco = precos.Max();
            double minPreco = precos.Min();

            if (maxPreco == minPreco) return; 

            for (int i = 0; i < precos.Count - 1; i++)
            {
                float x1 = i * stepX;
                float y1 = height - (float)((precos[i] - minPreco) / (maxPreco - minPreco) * height);
                float x2 = (i + 1) * stepX;
                float y2 = height - (float)((precos[i + 1] - minPreco) / (maxPreco - minPreco) * height);

                y1 = Math.Clamp(y1, 0, height); 
                y2 = Math.Clamp(y2, 0, height);

                canvas.DrawLine(x1, y1, x2, y2);
            }
            
        }
    }
}
