using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpens
{
    class Food
    {
        public Point point;
        public Boolean eaten;
        public Food(int _x, int _y)
        {
            point = new Point(_x, _y);
            eaten = false;
        }
    }
}
