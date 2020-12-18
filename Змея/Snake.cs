using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Змея
{
    class Snake
    {
        Graphics e;
        Direction direction;
        List<SnakeSector> snakeSectors = new List<SnakeSector>();

        public Snake(Graphics graphics, int x, int y)
        {
            e = graphics;
            SnakeSector head = new SnakeSector
            {
                X = x,
                Y = y,
                Color = Brushes.Blue,
                Width = 10

            };
            snakeSectors.Add(head);
            DrawHead();

        }

        void DrawHead()
        {
            e.FillEllipse(snakeSectors[0].Color,
                snakeSectors[0].X, snakeSectors[0].Y,
                snakeSectors[0].Width, snakeSectors[0].Width);
            if (snakeSectors.Count > 2)
                e.FillEllipse(snakeSectors[1].Color,
                snakeSectors[1].X, snakeSectors[1].Y,
                snakeSectors[1].Width, snakeSectors[1].Width);

        }

        void CleanTail()
        {
            int indexTail = snakeSectors.Count - 1;
            e.FillEllipse(Brushes.White,
                snakeSectors[indexTail].X,
                snakeSectors[indexTail].Y,
                snakeSectors[indexTail].Width,
                snakeSectors[indexTail].Width);
        }
        public void MoveDraw()
        {
            CleanTail();
            MoveNexPosition();
            DrawHead();
        }

        private void MoveNexPosition()
        {
            for(int index = snakeSectors.Count - 1; index > 0; index--)
            {
                snakeSectors[index].X = snakeSectors[index - 1].X;
                snakeSectors[index].Y = snakeSectors[index - 1].Y;
            }
            int width = snakeSectors[0].Width;
            switch (direction)
            {
                case Direction.Left: snakeSectors[0].X -= width; break;
                case Direction.Right: snakeSectors[0].X += width; break;
                case Direction.Up: snakeSectors[0].Y -= width; break;
                case Direction.Down: snakeSectors[0].Y += width; break;
            }
        }

        internal bool CheckApple(Apple apple)
        {
            if(snakeSectors[0].X == apple.X && snakeSectors[0].Y == apple.Y)
            {
                AddSelectorTail();
                return true;
            }
            return false;
        }

        public void AddSelectorTail()
        {
            int tail = snakeSectors.Count - 1;
            snakeSectors.Add(new SnakeSector
            {
                X = snakeSectors[tail].X,
                Y = snakeSectors[tail].Y,
                Color = Brushes.Blue,
                Width = snakeSectors[tail].Width
            });
        }
        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }


    }
}
