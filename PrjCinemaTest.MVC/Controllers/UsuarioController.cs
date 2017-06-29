using System.Web.Mvc;
using PrjCinema.Domain.Entities;
using PrjCinema.Domain.Interfaces.Repository;

using PrjCinema.Service.Service;

namespace PrjCinema.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IEnderecoService _enderecoService;
        public UsuarioController(UsuarioService usuarioService, EnderecoService enderecoService)
        {
            _usuarioService = usuarioService;
            _enderecoService = enderecoService;
        }
        // GET: Usuario
        public ActionResult Index()
        {
           var usuario = _usuarioService.GetAll();
            return View(usuario);
        }

        // GET: Usuario/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario, Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                
                var enderecoModel = endereco;
                _enderecoService.Add(enderecoModel);

               
                var usuarioModel = usuario;
                _usuarioService.Add(usuarioModel);
                return RedirectToAction("Index");
            }
                return View(usuario);
            
        }

        //// GET: Usuario/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Usuario/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Usuario/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Usuario/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
