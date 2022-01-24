using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SANSAR2013.Classlar
{
    class ResimFormat
    {
        public Bitmap ResimBoyutlandir(Bitmap resim, int genislik, int yukseklik)
        {
            Bitmap Donus = resim;
            using (Bitmap Orjinal = resim)
            {
                Size yenidegerler = new Size(genislik, yukseklik);
                Bitmap yeniresim = new Bitmap(Orjinal, yenidegerler);
                Donus = yeniresim;
            }
            return Donus;

        }
    }
}
