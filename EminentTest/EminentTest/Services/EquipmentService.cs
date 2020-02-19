 using EminentTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Newtonsoft.Json.JsonConvert;

namespace EminentTest.Services
{
    public class EquipmentService
    {
        const string GetAll = "http://etestapi.test.eminenttechnology.com/api/Equipment";

        public async Task<List<Equipment>> GetEquipment()
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(GetAll);
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return null;

                return DeserializeObject<List<Equipment>>(json);
            }

        }





        public async Task CreateEquipment(Equipment item)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(string.Format(GetAll, string.Empty));

                var json = JsonConvert.SerializeObject(item);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                //var content = new StringContent(json, Encoding.UTF8, "application/json");

                //HttpResponseMessage response = null;
                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {

                }
            }

        }




        public async Task DeleteEquipment(Equipment item)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(string.Format($"{GetAll}/{item.Id}", string.Empty));
                var response = await client.DeleteAsync(uri);

            }

        }




        public async Task UpdateEquipment( Equipment item)
        {
            using (var client = new HttpClient())
            {
                var uri = new Uri(string.Format($"{GetAll}/{item.Id}", string.Empty));
                var json = JsonConvert.SerializeObject(item);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync(uri, content);

            }
        }
    }



}
