using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.web.Models.HomeViewModels;
using app.domain;

namespace app.web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Dog> _dogRepository;

        public HomeController(IRepository<Dog> dogRepository)
        {
            _dogRepository = dogRepository;
        }


        public IActionResult Index()
        {
            IQueryable<Dog> dogList;

            var checkBd = _dogRepository.GetAll().LastOrDefault();

            if (checkBd == null)
            {
                dogList = CreateAndAddNewDogsToDatabase().AsQueryable();
            }
            else
            {
                dogList = _dogRepository.GetAll();
            }

            ViewData["Name"] = "Charles";
            
            return View(dogList);
        }


        private List<Dog> CreateAndAddNewDogsToDatabase()
        {
            List<String> nameList = new List<String>()
            {
                "Doby",
                "Jake",
                "Rocky",
                "Murphy",
            };

            List<Dog> dogList = new List<Dog>();

            foreach (string name in nameList)
            {
                var dog = new Dog(){ Name = name };
                dogList.Add(dog);

                 _dogRepository.Add(dog);
            }

            return dogList;    
        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
