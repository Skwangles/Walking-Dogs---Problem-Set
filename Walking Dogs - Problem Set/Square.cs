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
        private bool isCat;
        private string cat;
        private string[,] result;
        public Square(int posX, int posY, int width, int height)
        {
            isCat = false;
            cat = "";
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;
            result = new string[2, 4]{
                {"|","",cat,""},
                {"+","-","-","-" }
                };
        }       


        public void Surrounding(Square surround)
        {
            

        }

        public void Cat(bool isCats)
        {
            if (isCats)
            {
                isCat = isCats;
                cat = "C";

            }
            else
            {
                cat = "";
            }
        }

        public bool CheckCat()
        {
            if (isCat)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public virtual string[,] Result()
        {

            /*
              for (int i = 0; i < x*y; i++){
              for(int k = 0; k < x*y; k++){
              if (i% x == 0 || k % x == 0){
                       string c = "-";
                      }
                       else{
                       string c = " ";
                      }
                      console.write(c);
                      }
             }
             }
             */
            return result;
        }

    }
}
