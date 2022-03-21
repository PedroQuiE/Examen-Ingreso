using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamVehiculos.Models
{
    public class ModMarca
    {
        public int iIdMarca { get; set; }
        public string sMarca { get; set; }
        public ModMarca(int id, string marca) {
            iIdMarca = id;  
            sMarca = marca;
        }
    }
}