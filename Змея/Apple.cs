using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Змея
{
    public class Apple
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw(Graphics grphics)
        {
            grphics.FillEllipse(Brushes.Red, X, Y, 10, 10);
        }
    }
}
