using System;
using System.Collections.Generic;
using System.Text;

namespace Walking_Dogs___Problem_Set
{
    class Entry : Square
    {
        public Square[] adjacent = new Square[2];
        public Entry(int x, int y, int width, int height) : base(x, y, width, height, false)
        {
            

        }
        
        

        public override string ToString()
        {
            return "S";
        }

    }
}
