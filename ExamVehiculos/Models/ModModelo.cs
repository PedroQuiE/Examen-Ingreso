using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamVehiculos.Models
{
    public class ModModelo
    {
        public int iIdModelo { get; set; }
        public string sModelo { get; set; }

        public ModModelo() { }
        public ModModelo(int id, string mod) {
            iIdModelo = id;
            sModelo = mod;
        }
    } 
}