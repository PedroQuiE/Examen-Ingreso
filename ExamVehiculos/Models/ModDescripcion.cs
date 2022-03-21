using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamVehiculos.Models
{
    public class ModDescripcion
    {   
        
        public int iIdDescripcionModelo { get; set; }
        public int iIdModeloSubmarca { get; set; }
        public int iIdMostrar { get; set; }
        public string sDescripcion { get; set; }
        public ModDescripcion() { }
        public ModDescripcion(int id1, int id2, int id3, string des)
        {
            iIdDescripcionModelo = id1;
            iIdModeloSubmarca = id2;
            iIdMostrar = id3;
            sDescripcion = des;
        }

    }
}