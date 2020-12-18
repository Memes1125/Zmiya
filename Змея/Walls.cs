using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Змея
{
    class Walls
    {
        private char ch;
        private List<SnakeSector> wall = new List<SnakeSector>();

        public Walls(int x, int y, char ch)
        {
            this.ch = ch;
            DrawHorizontal(x, 0);
            DrawHorizontal(x, y);
            DrawVertical(0, y);
            DrawVertical(x, y);

        }

        private void DrawVertical(int x, int y)
        {
            for(int i = 0; i < x; i++)
            {
                snakeSector SnakeSector = (i, y, ch);

            }

        }

        private void DrawHorizontal(int x, int v)
        {


        }
    }
}
