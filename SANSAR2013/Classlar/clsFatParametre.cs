using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SANSAR2013.Classlar
{
    class clsFatParametre
    {
        SANSAR2013.Classlar.Veritabani DBase = new Veritabani();

        public string SiparisBasKar, SiparisUzun;
        public string SatisIadeBasKar, SatisIadeUzun;
        public string AlisBasKar, AlisUzun;
        public string AlisIadeBasKar, AlisIadeUzun;
        public string ServisBasKar, ServisUzun;
        public clsFatParametre()
        {
            string query = "SELECT * FROM tbl_fat_parametre ORDER BY ID DESC";
            DataRow Par = DBase.SatirCek(query);
            SiparisBasKar = Par["SP_BAS_KAR"].ToString();
            SiparisUzun = Par["SP_UZN"].ToString();
            SatisIadeBasKar = Par["SI_BAS_KAR"].ToString();
            SatisIadeUzun = Par["SI_UZN"].ToString();
            AlisBasKar = Par["AF_BAS_KAR"].ToString();
            AlisUzun = Par["AF_UZN"].ToString();
            AlisIadeBasKar = Par["AI_BAS_KAR"].ToString();
            AlisIadeUzun = Par["AI_UZN"].ToString();
            ServisBasKar = Par["SRV_BAS_BAR"].ToString();
            ServisUzun = Par["SRV_UZN"].ToString();
        }
        public string GetSiparisBasKar()
        {
            return SiparisBasKar;
        }
        public int GetSiparisUzun()
        {
            return Convert.ToInt32(SiparisUzun);
        }
        public string GetSatisIadeBasKar()
        {
            return SatisIadeBasKar;
        }
        public int GetSatisIadeUzun()
        {
            return Convert.ToInt32(SatisIadeUzun);
        }
        public string GetAlisBasKar()
        {
            return AlisBasKar;
        }
        public int GetAlisUzun()
        {
            return Convert.ToInt32(AlisUzun);
        }
        public string GetAlisIadeBasKar()
        {
            return AlisIadeBasKar;
        }
        public int GetAlisIadeUzun()
        {
            return Convert.ToInt32(AlisIadeUzun);
        }
        public string GetServisBasKar()
        {
            return ServisBasKar;
        }
        public int GetServisUzun()
        {
            return Convert.ToInt32(ServisUzun);
        }
    }
}       
        
