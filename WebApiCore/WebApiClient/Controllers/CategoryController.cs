using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApiClient.Models;

namespace WebApiClient.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5041/api/");

                HttpResponseMessage response = client.GetAsync("Category").Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    //categories = JsonSerializer.Deserialize<List<Category>>(json);
                    categories = JsonConvert.DeserializeObject<List<Category>>(json);
                }
            }

            return View(categories);
        }

        public IActionResult Details(int id)
        {
            Category cat = new Category();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5041/api/");
                HttpResponseMessage response = client.GetAsync($"Category/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string res = response.Content.ReadAsStringAsync().Result;
                    cat = JsonConvert.DeserializeObject<Category>(res);
                }

            }
            return View(cat);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5041/api/");
                    string json = JsonConvert.SerializeObject(category);
                    StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync("Category", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }

                }

            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category) 
        {
            if (ModelState.IsValid) 
            {
                HttpClient client = new HttpClient();
                
                    client.BaseAddress = new Uri("http://localhost:5041/api/");
                    string content = JsonConvert.SerializeObject(category);
                    StringContent jsonContent = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync($"Category/{category.Id}",jsonContent).Result;
                    if (response.IsSuccessStatusCode) 
                    {
                        return RedirectToAction("Index");
                    }
                
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult Delete(int id) 
        {
            Category category = GetCategory(id);
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Post(int id) 
        {
           if(id > 0)
            {
                Category category = GetCategory(id);
                using (HttpClient client = new HttpClient()) 
                {
                    client.BaseAddress = new Uri("http://localhost:5041/api/");
                    string content = JsonConvert.SerializeObject(category);
                    StringContent json = new StringContent(content,System.Text.Encoding.UTF8,"application/json");
                    HttpResponseMessage response = client.DeleteAsync($"Category/{id}").Result;
                    if (response.IsSuccessStatusCode) 
                    {
                        return RedirectToAction("Index");
                    }
                }


            }
           return View();
        }

        [NonAction]
        public Category GetCategory(int id) 
        {
            Category cat = new Category();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5041/api/");
                HttpResponseMessage response = client.GetAsync($"Category/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string res = response.Content.ReadAsStringAsync().Result;
                    cat = JsonConvert.DeserializeObject<Category>(res);
                }

            }
            return cat;
        }
    }
}
