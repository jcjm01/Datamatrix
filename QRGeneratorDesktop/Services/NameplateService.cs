using Newtonsoft.Json;
using QRGeneratorDesktop.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QRGeneratorDesktop.Services
{
    public class NameplateService
    {
        private readonly HttpClient _httpClient;

        public NameplateService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Nameplate>> GetNameplateAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7002/api/nameplates");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Nameplate>>(json);
        }
    }
}
