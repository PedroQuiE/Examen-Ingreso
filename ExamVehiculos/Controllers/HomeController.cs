using ExamVehiculos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace ExamVehiculos.Controllers
{
    public class HomeController : Controller
    {
        private static List<ModMarca> lstMar = new List<ModMarca>();
        private static List<ModSubmarca> lstSubM = new List<ModSubmarca>();
        private static List<ModModelo> lstMod = new List<ModModelo>();
        private static List<ModDescripcion> lstDesc = new List<ModDescripcion>();
        private static ModCodPos objCodPos = new ModCodPos();
        public ActionResult Index()
        {
            cargarMarca();
            ModCotizacion mod = new ModCotizacion();
            return View(mod);
        }

        [HttpPost]
        public ActionResult Index(ModCotizacion collection)
        {
            cargarMarca();
            if (ModelState.IsValid)
            {
                return Redirect("/Home/Validacion");
            }
            else { return View(collection); }
        }
        public ActionResult Validacion()
        {
            return View();
        }
        public ActionResult Submarca(int id)
        {
            ReqA request = Peticion.getRequest("Submarca", id);
            lstSubM = JsonConvert.DeserializeObject<List<ModSubmarca>>(Peticion.getReqJsonS(JsonConvert.SerializeObject(request)));//PostItem(JsonConvert.SerializeObject(request));
            ModSubmarca predet = new ModSubmarca(0, 0, 0, "Seleccione un Submarca");
            if (lstSubM == null){
                lstSubM = new List<ModSubmarca> { predet };
            }
            else {lstSubM.Insert(0, predet); }
            
            ViewBag.Submarca = new SelectList(lstSubM, "iIdSubMarca", "sSubMarca");
            return PartialView();
        }
        public ActionResult Modelo(int id)
        {
            ReqA request = Peticion.getRequest("Modelo", id);
            lstMod = JsonConvert.DeserializeObject<List<ModModelo>>(Peticion.getReqJsonS(JsonConvert.SerializeObject(request)));//PostItem(JsonConvert.SerializeObject(request));
            ModModelo predet = new ModModelo(0, "Seleccione un Modelo");
            if (lstMod == null){
                lstMod = new List<ModModelo> { predet };
            }
            else { lstMod.Insert(0, predet); }
            
            ViewBag.Modelo = new SelectList(lstMod, "iIdModelo", "sModelo");
            return PartialView();
        }

        public ActionResult CodPos(int id)
        {
            ReqA req = Peticion.getRequest("Sepomex", id);
            string test = Peticion.getReqJsonS(JsonConvert.SerializeObject(req));

            dynamic Sjson = JsonConvert.DeserializeObject(test);


            objCodPos.sUbicacion = Sjson[0]["Ubicacion"][0]["sUbicacion"];
            objCodPos.sEstado = Sjson[0]["Municipio"]["Estado"]["sEstado"];
            objCodPos.sMunicipio = Sjson[0]["Municipio"]["sMunicipio"];


            ViewBag.Edo = objCodPos.sEstado;
            ViewBag.Mun = objCodPos.sMunicipio;
            ViewBag.Col = objCodPos.sUbicacion;

            return PartialView();
        }



        public ActionResult Descripcion(int id)
        {
            ReqA request = Peticion.getRequest("DescripcionModelo", id);
            lstDesc = JsonConvert.DeserializeObject<List<ModDescripcion>>(Peticion.getReqJsonS(JsonConvert.SerializeObject(request)));
            ViewBag.Descripcion = new SelectList(lstDesc, "iIdDescripcionModelo", "sDescripcion");
            return PartialView();
        }

        private void cargarMarca()
        {
            ReqA request = Peticion.getRequest("Marca", 1);
            lstMar = JsonConvert.DeserializeObject<List<ModMarca>>(Peticion.getReqJsonS(JsonConvert.SerializeObject(request)));//PostItem(JsonConvert.SerializeObject(request));
            ModMarca predet = new ModMarca(0, "Seleccione una marca");
            lstMar.Insert(0, predet);
            ViewBag.Marca = new SelectList(lstMar, "iIdMarca", "sMarca");
        }

    }
}