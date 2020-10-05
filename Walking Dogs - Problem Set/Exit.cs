using System;
using System.Collections.Generic;
using System.Text;

namespace Walking_Dogs___Problem_Set
{
    class Exit : Square
    {
        public Square[] adjacent = new Square[2];
        public Exit(int posX, int posY, int width, int height) :base(posX, posY, width, height, false)
        {
            this.posX = posX;
            this.posX = posY;
        }
       

        public override string ToString()
        {
            return "E";

            
        }


    }
}
