﻿using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class VisitorApıController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApıController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:16276/api/Visitor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddVisitor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesage = await client.PostAsync("http://localhost:16276/api/Visitor", content);
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:16276/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:16276/api/Visitor/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=  await responseMessage.Content.ReadAsStringAsync(); 
                var values=JsonConvert.DeserializeObject<VisitorViewModel>(jsonData); 
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel p)
        {
            var client= _httpClientFactory.CreateClient(); 
            var jsonData= JsonConvert.SerializeObject(p);    
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync($"http://localhost:16276/api/Visitor/",content); 
            if (responseMessage.IsSuccessStatusCode)  
            {
                return RedirectToAction("Index"); 

            
            }
            return View();
        }

    }
}
