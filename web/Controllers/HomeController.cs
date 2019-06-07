﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UetDictionaryWeb.Models;

namespace UetDictionaryWeb.Controllers
{
    public class HomeController : Controller
    {
        private DictionaryContext _context;
        public HomeController()
        {
            _context = new DictionaryContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetDictionary()
        {
            return new JsonResult(_context.Units);
        }

        [HttpPost]
        public IActionResult InsertUnit()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string jsonString = reader.ReadToEnd();

                Unit jsonObject = JsonConvert.DeserializeObject<Unit>(jsonString);
                Unit item = new Unit(jsonObject.Word, jsonObject.Content);

                _context.Units.Add(item);

                _context.SaveChanges();
                return CreatedAtAction(nameof(InsertUnit), item);
            }
        }

        [HttpPut]
        public IActionResult EditUnit()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                string jsonString = reader.ReadToEnd();

                Unit jsonObject = JsonConvert.DeserializeObject<Unit>(jsonString);

                Unit item = _context.Units.FirstOrDefault(Unit => Unit.Id == jsonObject.Id);
                if (item != null)
                {
                    item.Word = jsonObject.Word;
                    item.Content = jsonObject.Content;
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
        }

        [HttpDelete]
        public IActionResult RemoveUnit()
        {
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                int id = int.Parse(reader.ReadToEnd());
                Unit itemWillBeRemoved = _context.Units.Where(Unit => Unit.Id == id).FirstOrDefault();
                _context.Units.Remove(itemWillBeRemoved);

                return Ok();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
