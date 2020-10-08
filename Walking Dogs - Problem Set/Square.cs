using System;
using System.Collections.Generic;
using System.Text;

namespace Walking_Dogs___Problem_Set
{
    class Square
    {
        public int posX;
        public int posY;
        public int width;
        public int height;
        public string Path;
        public bool isCat { get; set; }
        protected string result;
        public Square(int posX, int posY, int width, int height, bool cat)
        {
            isCat = cat;
            Path = "";
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;
            result = " ";
        }


        public bool isNeighbour(Square sq, Square[,] Grid)
        {
            try
            {
                if (Grid[posY - 1, posX] == sq) return true;
            }
            catch { }
            try
            {
                if (Grid[posY + 1, posX] == sq) return true;
            }
            catch { }
            try
            {


                if (Grid[posY, posX + 1] == sq) return true;
            }
            catch { }
            try
            {


                if (Grid[posY, posX - 1] == sq) return true;
            }
            catch { }
            return false;
        }

        public void MakeCat(int num, Square[,] Grid)
        {            
                isCat = true;
                if (num == 0) return;
                num -= 1;
                MakeNeighbourCat(Grid, num);           
        }

        public Queue<Square> CallNeighbours(Queue<Square> myStack, Square[,] Grid, string path)
        {
            try
            {
                myStack.Enqueue(Grid[posY - 1, posX]);
                Grid[posY - 1, posX].Path = path;
            }
            catch { }
            try
            {
                myStack.Enqueue(Grid[posY + 1, posX]);
                Grid[posY + 1, posX].Path = path;
            }
            catch { }
            try
            {
                myStack.Enqueue(Grid[posY, posX + 1]);
                Grid[posY, posX + 1].Path = path;
            }
            catch { }
            try
            {
                myStack.Enqueue(Grid[posY, posX - 1]);
                Grid[posY, posX - 1].Path = path;
            }
            catch { }

            return myStack;
        }

        public void MakeNeighbourCat(Square[,] Grid, int num)
        {
            try
            {
                Grid[posY - 1, posX].MakeCat(num, Grid);
            }
            catch { }
            try
            {                               
                Grid[posY + 1, posX].MakeCat(num, Grid);
            }
            catch { }
            try
            {                           
                Grid[posY, posX + 1].MakeCat(num, Grid);
            }
            catch { }
            try
            {                            
                Grid[posY, posX - 1].MakeCat(num, Grid);
            }
            catch { }

            
        }

        public override string ToString()
        {
            if (isCat)
            {
                return "C";

            }
            else
            {
                return " ";
            }
        }

    }
}
