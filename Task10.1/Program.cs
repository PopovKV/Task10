using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите значение градусов угла");
                int gradus = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение минут угла");
                int min = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите значение секунд угла");
                int sec = Convert.ToInt32(Console.ReadLine());
                Angle angle = new Angle(gradus, min, sec);
                angle.Show();
                angle.ToRadians();
                Console.ReadKey();
            }

            catch (FormatException)
            {
                Console.WriteLine("Неверный формат данных");
            }
            Console.ReadKey();
        }
    }
    class Angle
    {
        private int gradus;
        private int min;
        private int sec;

        public int Gradus
        {
            set
            {
                if ((value >= 360) || (value <= -360))
                {
                    gradus = value % 360;
                }
                else
                {
                    gradus = value;
                }
            }
            get
            {
                return gradus;
            }
        }
        public int Min
        {
            set
            {
                if (value >= 60)
                {
                    if (Gradus > 0)
                    {
                        Gradus += value / 60;
                    }
                    else
                    {
                        Gradus-= value / 60;
                    }
                    min = value % 60;
                }
                else
                {
                    if (value >= 0)
                    {
                        min = value;
                    }
                    else
                    {
                        Console.WriteLine("Минуты не могут быть отрицательными");
                    }
                }
            }
            get
            {
                return min;
            }
        }
        public int Sec
        {
            set
            {
                if (value >= 60)
                {
                    Min += value / 60;
                    sec = value % 60;
                }
                else
                {
                    if (value >= 0)
                    {
                        sec = value;
                    }
                    else
                    {
                        Console.WriteLine("Секунды не могут быть отрицательными");
                    }
                }
            }
            get
            {
                return sec;
                
            }
        }

        public Angle(int gradus=0, int min=0, int sec=0)
        {
            Gradus = gradus;
            Min = min;
            Sec = sec;
        }
        public void Show()
        {
            Console.WriteLine("Введенный угол - {0} градусов, {1} ', {2} ",Gradus,Min,Sec);
        }
        public void ToRadians()
        {
            double result = (Gradus + Convert.ToDouble(Min) / 60 + Convert.ToDouble(Sec) / 3600)/180*Math.PI;
            Console.WriteLine("Заданный угол в радианах = {0}",result);
        }
    }
}
