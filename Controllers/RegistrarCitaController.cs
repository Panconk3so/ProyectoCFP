using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoCFP.Models;
using ProyectoCFP.Data;

namespace ProyectoCFP.Controllers
{
   
    public class RegistrarCitaController : Controller
    {
        private readonly ILogger<RegistrarCitaController> _logger;
        private readonly ApplicationDbContext _context;

        public RegistrarCitaController(ILogger<RegistrarCitaController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var citas = _context.DataRegistrarCita.ToList();
            return View(citas);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(RegistrarCita registrarcita)
        {
            if (ModelState.IsValid)
            {
                _context.DataRegistrarCita.Add(registrarcita);
                _context.SaveChanges();
                return View("Crear");
            }
            return View(registrarcita);
        }


        

       [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
    }
