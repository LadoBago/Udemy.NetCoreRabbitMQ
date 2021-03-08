using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient apiclient;

        public TransferService(HttpClient apiclient)
        {
            this.apiclient = apiclient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), Encoding.UTF8, "application/json");
            var response = await apiclient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
