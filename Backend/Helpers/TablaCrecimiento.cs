using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Helpers
{
    public class TablaCrecimiento
    {
        public int Peso(int id)
        {
            if (id == 0)
            {
                
            }
            return 0;


        }

        public double Altura(int id)
        {
            switch (id)
            {
                case 0:
                    return 55;
                case 1:
                    return 56;
                case 2:
                    return 57.9;
                case 3:
                    return 61.7;
            }

            return 63;
        }

        public double Altura2(int id)
        {
            switch (id)
            {
                case 0:
                    return 48.6;
                case 1:
                    return 50;
                case 2:
                    return 52;
                case 3:
                    return 53;
            }

            return 60;
        }
    }
}