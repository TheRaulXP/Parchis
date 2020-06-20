using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parchis
{
    class Ficha
    {

        public PictureBox img;
        public int pos;
        public int team;

        public Ficha(PictureBox img, int team)
        {
            this.img = img;
            this.pos = -2; // Not initialized (-1 = At home, -3 = Won)
            this.team = team;

        }

        public bool atHome()
        {
            return (this.pos >= 100);
        }

    }

}
