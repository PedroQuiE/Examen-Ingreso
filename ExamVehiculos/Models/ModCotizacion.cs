using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using ExamVehiculos.Controllers;
using Newtonsoft.Json;
using System.Globalization;

namespace ExamVehiculos.Models
{
    public class ModCotizacion
    {
        [Key]
        [MarcaExist(ErrorMessage = "Selecciona una Marca")]
        public string Marca { get; set; }
        [SubmarcaExist(ErrorMessage = "Selecciona una Submarca")]
        public string Submarca { get; set; }
        [ModeloExist(ErrorMessage ="Selecciona un Modelo")]
        public string Modelo { get; set; }
        public string Descripcion { get; set; }

        [Range(10000,99999,ErrorMessage ="Formato Erroneo")]
        //[RegularExpression(@"[0-9]",ErrorMessage ="Formato Invalido")]
        public int CodPos { get; set; }
        public string Edo { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        [Range(typeof(DateTime), "01/01/1900", "01/01/2004", ErrorMessage = "Debe ser mayor de edad")]

        public DateTime DateNac { get; set; }
        [SexoExist(ErrorMessage = "Ingrese un sexo")]
        public string Sexo { get; set; }

    }

    public class MarcaExistAttribute : ValidationAttribute
    {
        public static int marca;
        List<ModMarca> lstMar = JsonConvert.DeserializeObject<List<ModMarca>>(Peticion.getReqJsonS(JsonConvert.SerializeObject(Peticion.getRequest("Marca", 1))));
        public override bool IsValid(object value)
        {
            if (lstMar.Any(x => x.iIdMarca == Convert.ToInt32(value)))
            {
                marca = Convert.ToInt32(value); return true;
            }
            else { return false; }
        }
    }
    public class SubmarcaExistAttribute : ValidationAttribute
    {
        public static int submarca;
        public override bool IsValid(object value)
        {
                if (Convert.ToInt32(value) != 0)
                {
                    submarca = Convert.ToInt32(value); return true;
                }
                else { return false; }
        }
    }
    public class ModeloExistAttribute : ValidationAttribute
    {
        public static int modelo;
        public override bool IsValid(object value)
        { 
                if (Convert.ToInt32(value) != 0)
                {
                    modelo = Convert.ToInt32(value); return true;
                }
                else { return false; }
        }
    }

    public class SexoExistAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == 2 || Convert.ToInt32(value) == 1)
            {
               return true;
            }
            else { return false; }
        }
    }
}