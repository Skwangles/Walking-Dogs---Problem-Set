using System;

namespace Walking_Dogs___Problem_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many colums(x)");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("How many Rows(y)");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("");


            var Draw = new char[y * 2 + 1, x * 4 + 1];


            //need to create class casting, and awareness of surrounding classes. 

            //var Grid = new Square[y, x];   //creates replica grid, but with the corrosponding class instances
            CreateGrid();
            Display();

            void CreateGrid()
            {
                //
                // Creates Console Grid
                //

                for (int ydir = 0; ydir < y * 2 + 1; ydir++)
                {
                    for (int xdir = 0; xdir < x * 4 + 1; xdir++)
                    {
                        if ((xdir % 4 == 0 && ydir % 2 == 0))//|| (xdir == x * 4 && ydir % 2 == 0) || (ydir == y * 2 && xdir % 4 == 0) individual end calcs
                        {
                            Draw[ydir, xdir] = '+';
                        }
                        else if (ydir % 2 != 0 && xdir % 4 == 0)
                        {
                            Draw[ydir, xdir] = '|';
                        }
                        else if ((xdir % 4 != 0 && ydir % 2 == 0))
                        {
                            Draw[ydir, xdir] = '-';
                        }
                        else
                        {
                            Draw[ydir, xdir] = ' ';
                        }
                    }
                }

                //Below should make classes grid
                /*
                for (int vert = 0; vert < y; vert++)
                {
                    for (int hori = 0; hori < x; hori++)
                    {
                        if (vert == 0 && hori == 0)
                        {
                            Grid[vert, hori] = new Entry(hori, vert, x, y);
                        }
                        else if (vert == y - 1 && hori == x - 1)
                        {
                            Grid[vert, hori] = new Exit(hori, vert, x, y);
                        }
                        else
                        {
                            Grid[vert, hori] = new Square(hori, vert, x, y);
                        }
                    }
                }
                */
            }        //Creates the char grid    

            void Display()
            {
                
                for (int a = 0; a < y * 2 + 1; a++)
                {
                    for (int b = 0; b < x * 4 + 1; b++)
                    {
                        if (b == x * 4)//next line
                        {
                            Console.WriteLine(Draw[a, b].ToString());

                        }
                        else
                        {
                            Console.Write(Draw[a, b].ToString());
                        }


                    }
                }


            }//displays the char grid
        }
    }
}
