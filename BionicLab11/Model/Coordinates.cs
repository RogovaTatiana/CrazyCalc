using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BionicLab11.Model
{
    public class Coordinates
    {
        public class Coordinate
        {
            public double Left { get; set; }
            public double Top { get; set; }
            public double Right { get; set; }
            public double Bottom { get; set; }
        }

        public List<Coordinate> Margins { get; set; }

        public Coordinates()
        {

            Margins = new List<Coordinate>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    double start_l = 10+41*i;
                    double start_t = 69+41*j;
                    Margins.Add(new Coordinate { Left = start_l, Top = start_t, Right = 0, Bottom = 0 });
                }
        }
    }
}
