using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrjCinema.Data.Repositories;
using PrjCinema.Domain.Entities;

namespace PrjCinema.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly EnderecoRepository _enderecoRepository;
        public UsuarioController(UsuarioRepository repository, EnderecoRepository enderecoRepository)
        {
            _usuarioRepository = repository;
            _enderecoRepository = enderecoRepository;
        }
        // GET: Usuario
        public ActionResult Index()
        {
           var usuario= _usuarioRepository.GetAll();
            return View(usuario);
        }

        //// GET: Usuario/Details/5
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
        public ActionResult Create(Domain.Entities.Usuario usuario, Domain.Entities.Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                endereco.Bairro = "blablabla";
                endereco.Cep = "94045090";
                endereco.Numero = 18;
                endereco.Rua = "Rua Alguma";
                endereco.Uf = Uf.RS;
                var enderecoModel = endereco;
                _enderecoRepository.Add(enderecoModel);

                DateTime localDate = DateTime.Now;
                usuario.DataCadastro = localDate;
                usuario.Perfil = Perfil.Adminstrador;
                usuario.Genero = Genero.Masc;
                usuario.Endereco = enderecoModel;
                var usuarioModel = usuario;
                _usuarioRepository.Add(usuarioModel);
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
