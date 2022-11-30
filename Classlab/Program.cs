namespace Classlab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            while (runProgram)
            {
                int myAnswer;

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.Clear();

                Console.WriteLine("╔═══════════════════════╗");
                Console.WriteLine("║Välj geometrikalkylator║");
                Console.WriteLine("╚═══════════════════════╝");
                Console.WriteLine("1: Cirkel");
                Console.WriteLine("2: Rätviklig triangel");
                Console.WriteLine("");
                Console.WriteLine("0: Avsluta");
                Console.Write("val --> ");
                try { 
                    myAnswer = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ange korrekt siffra");
                    Console.ReadLine();
                    continue;
                }

                switch (myAnswer)
                {
                    case 1:
                        calcCircle();
                        break;
                    case 2:
                        calcRightTriangle();
                        break;
                    case 0:
                        runProgram = false;
                        continue;
                    default:
                        Console.WriteLine("Ange korrekt siffra");
                        Console.ReadLine();
                        break;
                }

            }

            static void calcCircle() {
                Console.Clear();

                int radAnswer;
                bool res;

                Console.Write("Ange cirkelns radie --> ");

                string? myRadius = Console.ReadLine();
                res = int.TryParse(myRadius, out radAnswer);

                if (!res)
                {
                    Console.WriteLine("Nu blev det fel");
                    Console.ReadLine();
                    return;
                }

                Circle myCircle = new Circle(radAnswer);

                Console.WriteLine("╔═══════════╗");
                Console.WriteLine("║Area cirkel║");
                Console.WriteLine("╚═══════════╝");
                Console.WriteLine($"Cirkel med radien {myCircle.Radius}cm har en area på {myCircle.getArea()}cm");
                Console.WriteLine(" ");
                Console.WriteLine("╔══════════════╗");
                Console.WriteLine("║Omkrets cirkel║");
                Console.WriteLine("╚══════════════╝");
                Console.WriteLine($"Cirkel med radien {myCircle.Radius}cm har en omkrets på {myCircle.getCirc()}cm");
                Console.ReadLine();
                return;
                
            }

            static void calcRightTriangle() {
                

                printTriangle();

                Console.Write("Ange katet A --> ");

                int legA;
                int legB;
                bool res;

                

                

                string? stringA = Console.ReadLine();
                res = int.TryParse(stringA, out legA);
                if (!res)
                {
                    Console.WriteLine("Nu blev det fel");
                    Console.ReadLine();
                    calcRightTriangle();
                }

                printTriangle();

                Console.Write("Ange katet B --> ");


                string? stringB = Console.ReadLine();
                res = int.TryParse(stringB, out legB);
                if (!res)
                {
                    Console.WriteLine("Nu blev det fel");
                    Console.ReadLine();
                    calcRightTriangle();
                }

                Triangle tri1 = new Triangle(legA, legB);
                printTriangle(stringA, stringB, tri1.getHypo());
                Console.WriteLine(" ");
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║Hypotenusan (rätsidig triangel)║");
                Console.WriteLine("╚═══════════════════════════════╝");
                Console.WriteLine($"En rätvinklig triangel med katet A {tri1.Opposite}cm och katet B {tri1.Adjacent}cm har en hypotenusa på {tri1.getHypo()}cm");
                Console.ReadLine();

                static void printTriangle(string a = "A", string b = "B", double tril = 0)
                {
                    Console.Clear();
                    Console.WriteLine("");

                    decimal objSize = 15;
                    decimal halfSize = Math.Floor(objSize / 2);

                    for (int i = 0; i < objSize; i++)
                    {
                        if (i != halfSize)
                        {
                            Console.Write("║");
                        }
                        else
                        {
                            Console.Write(b);
                        }



                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write(" *");
                        }
                        if (i == halfSize && b != "B")
                        {
                            Console.Write($"  {tril}");
                        }

                        Console.WriteLine();
                    }

                    Console.Write("╚");
                    for (int j = 0; j < objSize; j++)
                    {
                        if (j != halfSize)
                        {
                            Console.Write("══");
                        }
                        else
                        {
                            Console.Write(a);
                        }

                    }
                    Console.WriteLine();
                }

            }
            Console.Clear();
            Console.Write("Programmet kommer nu stänkas ner");
            Thread.Sleep(1000);


        }

        
    }

    public class Circle
    {
        float _pi = 3.141f;
        int _Radius;
        int _Diameter;

        public Circle(int radius)
        {
            _Radius = radius;
            _Diameter = radius * 2;

        }

        public float Pi
        {
            get { return _pi; }
        }

        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value; }
        }
        public int Diameter
        {
            get { return _Diameter; }
            set { _Diameter = value; }
        }

        public double getArea()
        {
            return Math.Round(_Radius * _Radius * _pi);
        }

        public double getCirc()
        {
            return Math.Round(_Diameter * _pi);
        } 

    }

    public class Triangle
    {
        
        int _a; //Opposite
        int _b; //Adjacent

        public Triangle(int a , int b)
        {
            _a = a;
            _b = b;
        }


        public int Opposite
        {
            get { return _a; }
            set { _a = value; }
        }

        public int Adjacent
        {
            get { return _b; }
            set { _b = value; }
        }

        public double getHypo()
        {
            double ab = (_a * _a) + (_b * _b);
            double c = Math.Sqrt(ab);
            
            return Math.Round(c, 2);
        }
    }



}


