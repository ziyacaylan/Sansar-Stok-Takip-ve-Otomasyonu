using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.EskiProgramModulu
{
    class clsSatisCek
    {
        SANSAR2013.Classlar.Veritabani Dbase = new Classlar.Veritabani();

        private void SatisOKU()
        {
            string saveuser,savedate ,tarih, tipi, turu, siparisNO, fisNO, faturaNO, musteriKODU, firmaADI, siparisVEREN, siparisGIREN, stokONAY, satisONAY, sipariskalemADET, vergiD, vergiNO, kurTARIH;
            string query = "SELECT * FROM satislar";
            DataTable Tablo = Dbase.TabloCek(query);

            for (int i = 0; i < Tablo.Rows.Count; i++)
            {
                tarih = Liste.Rows[i]["TURU"].ToString();
                tipi = Liste.Rows[i]["TURU"].ToString();
                siparisNO = Liste.Rows[i]["TURU"].ToString();
                fisNO = Liste.Rows[i]["TURU"].ToString();
                faturaNO = Liste.Rows[i]["STOK_KODU"].ToString();
                musteriKODU = Liste.Rows[i]["MODEL_NO"].ToString();
                firmaADI = Convert.ToInt32(Liste.Rows[i]["MIKTAR"].ToString());
                siparisVEREN = Liste.Rows[i]["STOK_BIRIMI"].ToString();
                siparisGIREN = Liste.Rows[i]["ACIKLAMA"].ToString();
                stokONAY = Liste.Rows[i]["TURU"].ToString();
                satisONAY = Liste.Rows[i]["TURU"].ToString();
                kurTARIH = Liste.Rows[i]["TURU"].ToString();
                sipariskalemADET = Liste.Rows[i]["TURU"].ToString();
                saveuser = Liste.Rows[i]["TURU"].ToString();
                savedate = Liste.Rows[i]["TURU"].ToString();
            }
        }
    }
}
