using ETS.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace ETS.UI.Controllers
{
    public class PersonelController : Controller
    {
        // GET: PersonelController1
        public ActionResult Index()
        {
            var data = GetPersonelList();

            if (data == null)
                return RedirectToAction("Error");

            return View(data);
        }

        // GET: PersonelController1/Details/5
        public ActionResult Details(int id)
        {
            var data = GetPersonel(id);

            if (data == null)
                return RedirectToAction("Error");

            return View(data);
        }

        // GET: PersonelController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonelController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            var data = new PersonelViewModel()
            {
                Id = 0,
                Name = collection["Name"],
                Surname = collection["Surname"],
                PhoneNumber = collection["PhoneNumber"],
                IsMale = collection["Sex"] == "Erkek" ? true : false,
                BirthDate = DateTime.Parse(collection["SBirthDate"])
            };

            var response = CreatePersonel(data);

            if (response == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        // GET: PersonelController1/Edit/5
        public ActionResult Edit(int id)
        {
            var data = GetPersonel(id);

            if (data == null)
                return RedirectToAction("Error");

            return View(data);
        }

        // POST: PersonelController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            var data = new PersonelViewModel
            {
                Id = 0,
                Name = collection["Data.Name"],
                Surname = collection["Data.Surname"],
                PhoneNumber = collection["Data.PhoneNumber"],
                IsMale = collection["Data.Sex"] == "Erkek" ? true : false,
                BirthDate = DateTime.Parse(collection["Data.SBirthDate"]),
            };

            var response = UpdatePersonel(id, data);

            if (response == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        // GET: PersonelController1/Delete/5
        public ActionResult Delete(int id)
        {
            var data = GetPersonel(id);

            if (data == null)
                return RedirectToAction("Error");

            return View(data);
        }

        // POST: PersonelController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var response = DeletePersonel(id);

            if (response == null)
                return RedirectToAction("Error");

            return RedirectToAction("Index");
        }

        private PersonelListResponseModel GetPersonelList()
        {
            var response = new PersonelListResponseModel();

            var result = WebRequest.WebApiGetRequest(SystemConstants.WebApiDomainAddress, "api/Personel/Get");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonelListResponseModel>(resultString);
            }
            else
                return null;

            return response;
        }

        private PersonelResponseModel GetPersonel(int id)
        {
            var response = new PersonelResponseModel();
            var result = WebRequest.WebApiGetRequest(SystemConstants.WebApiDomainAddress, $"api/Personel/Get/{id}");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<PersonelResponseModel>(resultString);
            }
            else
                return null;

            return response;
        }

        private BaseResponseModel UpdatePersonel(int id, PersonelViewModel data)
        {
            var response = new BaseResponseModel();
            var result = WebRequest.WebApiPostRequest(SystemConstants.WebApiDomainAddress, $"api/Personel/Update/{id}", data);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseModel>(resultString);
            }
            else
                return null;

            return response;
        }

        private BaseResponseModel DeletePersonel(int id)
        {
            var response = new BaseResponseModel();
            var result = WebRequest.WebApiDeleteRequest(SystemConstants.WebApiDomainAddress, $"api/Personel/Delete/{id}");

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseModel>(resultString);
            }
            else
                return null;

            return response;
        }

        private BaseResponseModel CreatePersonel(PersonelViewModel data)
        {
            var response = new BaseResponseModel();
            var result = WebRequest.WebApiPutRequest(SystemConstants.WebApiDomainAddress, $"api/Personel/Create", data);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultString = result.Content.ReadAsStringAsync().Result;
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseModel>(resultString);
            }
            else
                return null;

            return response;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
