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
            Console.WriteLine("Where are the cats in x,y");
            Console.WriteLine("Type X when finished");

            //Sleeping Cats
            Console.Write("Cat Location(x,y): ");
            string[] CatLoc = Console.ReadLine().Split(',');
            while (CatLoc[0] != "X")
            {
                CatLocations.Add(CatLoc);
                Console.Write("Cat Location(x,y): ");
                CatLoc = Console.ReadLine().Split(',');

            }//dequeues and adds to a list


            //Creates Grids
            var Draw = new string[y * 2 + 1, x * 4 + 1];
            var Grid = new Square[y, x];

            var myStack = new Queue<Square>();//For breadth first, just change to Queue
            var visited = new HashSet<Square>();
            int inc = 0;

            CreateGrid();
            Display();

            while (PathFinder())
            {
                inc++;

                visited.Clear();
                Console.WriteLine("New Best Path: " + Grid[y - 1, x - 1].Path);
                foreach (var item in Grid)
                {
                    item.Path = "";
                }
                foreach (var a in CatLocations)
                {
                    Grid[int.Parse(a[1]) - 1, int.Parse(a[0]) - 1].MakeCat(inc, Grid);
                }
            }

            Console.WriteLine("With " + inc + " squares away from the cats, the way is blocked.");

            //End


            //
            //Functions
            //

            bool PathFinder()
            {


                myStack.Enqueue(Grid[0, 0]);
                var harReached = false;
                while (myStack.Count > 0 && !harReached)
                {
                    harReached = FindPath();
                }
                return harReached;
            }



            /*
            string MakePath()
            {
                string NewPath = "";
                var PathSplit = Path.Split();

                for (int i = 0; i < PathSplit.Length; i++)
                {
                    PathSplit[i] = PathSplit[i].Replace("(", "");
                    PathSplit[i] = PathSplit[i].Replace(")", "");
                }

                for (int b = PathSplit.Length - 1; b > 0; b-= 1)
                {
                    var temporary = PathSplit[b].Split(",");
                    var comparison = PathSplit[b - 1].Split(",");
                    if (int.Parse(temporary[1]) == 0 && int.Parse(temporary[0]) == 0)
                    {
                        NewPath = "0,0 " + NewPath;
                    }                    
                    else if (Grid[int.Parse(temporary[1]), int.Parse(temporary[0])].isNeighbour(Grid[int.Parse(comparison[1]), int.Parse(comparison[0])], Grid))
                    {
                        NewPath = Grid[int.Parse(comparison[1]), int.Parse(comparison[0])].posX.ToString + "," + Grid[int.Parse(comparison[1]), int.Parse(comparison[0])].posY + " " + NewPath;
                    }
                    
                }
                return NewPath;
            }
            */
            bool FindPath()
            {
                var temp = myStack.Dequeue();
                if (temp.ToString() == "E")
                {
                    temp.Path += "(" + temp.posX + "," + temp.posY + ")";



                    myStack.Clear();
                    return true;
                }

                if (temp.isCat)
                {
                    return false;
                }
                else
                {
                    if (visited.Contains(temp))
                    {
                        return false;
                    }
                    else
                    {
                        string newPath = temp.Path + "(" + temp.posX + "," + temp.posY + ") ";

                        visited.Add(temp);
                        myStack = temp.CallNeighbours(myStack, Grid, newPath);
                    }
                }
                return false;

            }

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
                        if ((xdir % 4 == 0 && ydir % 2 == 0))
                        {
                            Draw[ydir, xdir] = "+";
                        }//decides which string/class should be in each slot
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
                            }//if not where the letter for cat would display, it is a space
                            else if (count == 2)
                            {
                                count = 0;

                                //finds if the slot is the Entry, the Exit or just a normal block

                                //
                                //xvalue is (xdir-2)/4, because each repeat is 4 long, 
                                //but the "|" which only has 1 per square is -2 from the xdir's location. This will convert to the 0-based Grid index
                                //
                                if ((xdir - 2) / 4 == 0 && (ydir - 1) / 2 == 0)
                                {
                                    Grid[0, 0] = new Entry(0, 0, x, y);
                                }
                                else if ((xdir - 2) / 4 == x - 1 && (ydir - 1) / 2 == y - 1)
                                {
                                    Grid[y - 1, x - 1] = new Exit(x - 1, y - 1, x, y);
                                }
                                else//if not an exit, or an entry, will be a normal square.
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
                foreach (string[] s in CatLocations)
                {
                    if (int.Parse(s[0]) - 1 == (xdir - 2) / 4 && int.Parse(s[1]) - 1 == (ydir - 1) / 2)
                    {
                        return true;
                    }
                }//maintains the original Cat list, and rotates through each array of points

                return false;

            }//finds if an item is a cat. and sets it to one

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


            }//displays the grid in console.

        }
    }
}
