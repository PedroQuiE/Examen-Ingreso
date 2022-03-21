using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamVehiculos.Models
{
    public class ModSubmarca
    {
        public int iIdSubMarca { get; set; }
        public int iIdMarcaSubramo { get; set; }
        public int iIdMostrar { get; set; }
        public string sSubMarca { get; set; }
        public ModSubmarca() { }
        public ModSubmarca(int id1, int id2, int id3, string mar) {
            iIdSubMarca = id1;
            iIdMarcaSubramo = id2;  
            iIdMostrar = id3;
            sSubMarca = mar;
        }

    }
}