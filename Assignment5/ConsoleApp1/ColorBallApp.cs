using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Color
    {
        private int _red;
        private int _green;
        private int _blue;
        private int _alpha;

        // Constructor with all values
        public Color(int red, int green, int blue, int alpha)
        {
            _red = red;
            _green = green;
            _blue = blue;
            _alpha = alpha;
        }

        public Color(int red, int green, int blue)
            : this(red, green, blue, 255) { }

        public int GetRed() { return _red; }
        public int GetGreen() { return _green; }
        public int GetBlue() { return _blue; }
        public int GetAlpha() { return _alpha; }

        public void SetRed(int value) { _red = value; }
        public void SetGreen(int value) { _green = value; }
        public void SetBlue(int value) { _blue = value; }
        public void SetAlpha(int value) { _alpha = value; }
        public int GetGrayscale()
        {
            return (_red + _green + _blue) / 3;
        }
    }

    public class Ball
    {
        private int _size;
        private Color _color;
        private int _throwCount;

        public Ball(int size, Color color)
        {
            _size = size;
            _color = color;
            _throwCount = 0;
        }

        public void Pop()
        {
            _size = 0;
        }

        public void Throw()
        {
            if (_size > 0)
            {
                _throwCount++;
            }
        }

        public int GetThrowCount()
        {
            return _throwCount;
        }
    }

    public class ColorBallApp
    {
        public static void Main(string[] args)
        {
     
            Color redColor = new Color(255, 0, 0);
            Color blueColor = new Color(0, 0, 255);

            Ball redBall = new Ball(10, redColor);
            Ball blueBall = new Ball(15, blueColor);

          
            redBall.Throw();
            redBall.Throw();
            blueBall.Throw();

            Console.WriteLine($"Red ball thrown {redBall.GetThrowCount()} times"); // Should print 2
            Console.WriteLine($"Blue ball thrown {blueBall.GetThrowCount()} times"); // Should print 1

            // Pop the red ball and try to throw it
            redBall.Pop();
            redBall.Throw(); // This throw shouldn't count
            blueBall.Throw();

            Console.WriteLine("\nAfter popping red ball:");
            Console.WriteLine($"Red ball thrown {redBall.GetThrowCount()} times"); // Should still be 2
            Console.WriteLine($"Blue ball thrown {blueBall.GetThrowCount()} times"); // Should be 2
        }
    }
}
