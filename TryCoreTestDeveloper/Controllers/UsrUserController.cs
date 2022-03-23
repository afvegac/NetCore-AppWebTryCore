using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TryCoreTestDeveloper.Common.Dto;
using TryCoreTestDeveloper.Models;
using TryCoreTestDeveloper.Services.Service;

namespace TryCoreTestDeveloper.Controllers
{
    public class UsrUserController : Controller
    {
        private readonly IUsrUsuarioService _usrUsuarioService;
        public UsrUserController(IUsrUsuarioService usrUsuarioService)
        {
            _usrUsuarioService = usrUsuarioService;
        }
        public IActionResult Index()
        {
            var dtos = _usrUsuarioService.GetAll();

            return View(dtos.Select(x => new UsrUsuarioModel()
            {
                Codigo = x.Codigo,
                Descripcion = x.Descripcion,
                Direccion = x.Direccion,
                Identificacion = x.Identificacion,
                MonedaId = x.MonedaId
            }));
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsrUsuarioModel model)
        {
            if(ModelState.IsValid)
            {
                var dto = new UsrUsuarioDto()
                {
                    Codigo = model.Codigo,
                    Descripcion = model.Descripcion,
                    Direccion = model.Direccion,    
                    Identificacion = model.Identificacion,
                    MonedaId = model.MonedaId
                };

                _usrUsuarioService.Add(dto);

                TempData[mensaje] = "Registro creado exitosamente";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
