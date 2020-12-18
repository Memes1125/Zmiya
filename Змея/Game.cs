using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Змея
{
    class Game
    {
        Apple apple;
        Snake snake;
        Form field;
        Graphics graphics;
        Random random = new Random();
        bool running = true;
        Thread thread;

        public Game(Form field)
        {
            this.field = field;
            graphics = Graphics.FromHwnd(field.Handle);
            graphics.FillRectangle(Brushes.White, 0, 0, 300, 300);
            snake = new Snake(graphics,
                random.Next(1, 30) * 10,
                random.Next(1, 30) * 10);
            GenerateApple();
            thread = new Thread(RunGame);
            thread.Start();
        }

        internal void Stop()
        {
            thread?.Abort();
            running = false;
        }

        internal void Sendkey(Keys keyCode)
        {
            Direction direction;
            switch (keyCode)
            {
                case Keys.W:
                    direction = Direction.Up;
                    break;
                case Keys.A:
                    direction = Direction.Left;
                    break;
                case Keys.S:
                    direction = Direction.Down;
                    break;
                case Keys.D:
                    direction = Direction.Right;
                    break;
                default:return;
            }
            snake.ChangeDirection(direction);
        }

        void RunGame(object p)
        {
            while (running)
            {
                Thread.Sleep(500);
                snake.MoveDraw();
                if (snake.CheckApple(apple))
                    GenerateApple();
               
                        
            }
        }

        private void GenerateApple()
        {
            apple = new Apple
            {
                X = random.Next(1, 30) * 10,
                Y = random.Next(1, 30) * 10,
            };
            apple.Draw(graphics);
        }
    }
}
