using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoCFP.Models;
using ProyectoCFP.Data;
using Microsoft.AspNetCore.Identity;

namespace ProyectoCFP.Controllers
{
    public class RegistrarCitaController : Controller
    {
        private readonly ILogger<RegistrarCitaController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegistrarCitaController(ILogger<RegistrarCitaController> logger,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public IActionResult Index()
        {
            var citas = _context.DataRegistrarCita.ToList();
            return View(citas);
        }

        public IActionResult Cliente()
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
    if (User.Identity.IsAuthenticated)
    {
        // Calcula el precio basado en la especialidad seleccionada
        if (!string.IsNullOrEmpty(registrarcita.Especialidad))
        {
            decimal precioBase = 0; // Define el precio base
            switch (registrarcita.Especialidad)
            {
                case "Trastorno":
                    precioBase = 100; // Precio para Trastorno
                    break;
                case "Estres":
                    precioBase = 80; // Precio para Estrés
                    break;
                case "Terapia":
                    precioBase = 120; // Precio para Terapia
                    break;
                // Agrega más casos según tus especialidades
            }

            // Asigna el precio calculado
            registrarcita.Precio = precioBase;
        }

        if (ModelState.IsValid)
        {
            // Asegura que la fecha de nacimiento esté en formato UTC
            if (registrarcita.FechaNacimiento.Kind != DateTimeKind.Utc)
            {
                registrarcita.FechaNacimiento = registrarcita.FechaNacimiento.ToUniversalTime();
            }

            _context.DataRegistrarCita.Add(registrarcita);
            _context.SaveChanges();
            return RedirectToAction("Crear");
        }
        return View(registrarcita);
    }
    else
    {
        // El usuario no está autenticado, muestra una notificación
        TempData["Message"] = "Debe iniciar sesión para registrar una cita.";
        return RedirectToAction("Crear");
    }
}
    }}




