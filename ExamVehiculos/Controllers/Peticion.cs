using ExamVehiculos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ExamVehiculos.Controllers
{
    public class Peticion
    {
        public static ReqA getRequest(string type, int id)
        {
            ReqA request = new ReqA()
            {
                NombreCatalogo = type,
                Filtro = id.ToString(),
                IdAplication = 1
            };
            return request;
        }
        public static string getReqJsonS(string data)
        {
            dynamic json = JsonConvert.DeserializeObject(data);
            int check = json["Filtro"];
            if (check == 0) return "";
            string listMarca = "";
            var url = $"https://apitestcotizamatico.azurewebsites.net/api/catalogos";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ResA responseApi = JsonConvert.DeserializeObject<ResA>(responseBody);
                            listMarca = responseApi.CatalogoJsonString;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listMarca;
        }


    }
}