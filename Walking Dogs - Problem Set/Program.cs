using System;
using System.Collections.Generic;

namespace Walking_Dogs___Problem_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            var CatLocations = new List<string[]>();


            //
            //Starting Operations
            // 
            Console.WriteLine("How many colums(x)");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("How many Rows(y)");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Where are the cats in x,y.");
            Console.WriteLine("Type X when finished");


            Console.Write("Cat Location(x,y): ");
            string[] CatLoc = Console.ReadLine().Split(',');
            while (CatLoc[0] != "X")
            {
                CatLocations.Add(CatLoc);
                Console.Write("Cat Location(x,y): ");
                CatLoc = Console.ReadLine().Split(',');
                
            }
            //
            // End of information setup. 
            //


            var Draw = new string[y * 2 + 1, x * 4 + 1];
            var Grid = new Square[y, x];

            //
            //creates replica grid, but with the corrosponding class instances
            //
            CreateGrid();
            Display();

            void CreateGrid()
            {
                //
                // Creates Console Grid
                //
                int count = 1;
                for (int ydir = 0; ydir < y * 2 + 1; ydir++)
                {
                    for (int xdir = 0; xdir < x * 4 + 1; xdir++)
                    {
                        if ((xdir % 4 == 0 && ydir % 2 == 0))//|| (xdir == x * 4 && ydir % 2 == 0) || (ydir == y * 2 && xdir % 4 == 0) individual end calcs
                        {
                            Draw[ydir, xdir] = "+";
                        }
                        else if (ydir % 2 != 0 && xdir % 4 == 0)
                        {
                            Draw[ydir, xdir] = "|";

                        }
                        else if ((xdir % 4 != 0 && ydir % 2 == 0))
                        {
                            Draw[ydir, xdir] = "-";
                        }                       
                        else
                        {
                            if (count != 2)
                            {
                                Draw[ydir, xdir] = " ";
                                count++;
                            }
                            else if (count == 2)
                            {
                                count = 0;

                                //finds if the slot is the Entry, the Exit or just a normal block
                                if ((xdir - 2) / 4 == 0 && (ydir - 1) / 2 == 0)
                                {
                                    Grid[0, 0] = new Entry(0, 0, x, y);
                                }
                                else if ((xdir - 2) / 4 == x - 1 && (ydir - 1) / 2 == y - 1)
                                {
                                    Grid[y - 1, x - 1] = new Exit(x - 1, y - 1, x, y);
                                }
                                else
                                {
                                    // will find if it is a cat, after has been defined as a normal square

                                    Grid[(ydir - 1) / 2, (xdir - 2) / 4] = new Square((xdir - 2) / 4, (ydir - 1) / 2, x, y, SleepCat(ydir, xdir));
                                }
                                Draw[ydir, xdir] = Grid[(ydir - 1) / 2, (xdir - 2) / 4].ToString();//Displays the letter associated with it

                            }

                        }
                    }
                }


            }  
            
            bool SleepCat(int ydir, int xdir)
            {
                

               foreach(string[] s in CatLocations)
                {
                    if(int.Parse(s[0])-1 == (xdir - 2) / 4 && int.Parse(s[1])-1 == (ydir - 1) / 2)
                    {
                        return true;
                    }
                }

                return false;

            }
            
            //Creates the char grid    
            
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
