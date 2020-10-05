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
        public bool isCat { get; set; }        
        protected string result;
        public Square(int posX, int posY, int width, int height, bool cat)
        {
            isCat = cat;
            
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;
            result = " ";
        }       


        public void Surrounding(Square surround)
        {
            

        }

        public bool CheckCat()
        {
            return isCat;
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
