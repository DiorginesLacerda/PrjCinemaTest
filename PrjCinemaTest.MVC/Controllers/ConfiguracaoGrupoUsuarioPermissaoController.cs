using System.Web.Mvc;
using PrjCinema.Domain.Interfaces.Repository;

namespace PrjCinema.MVC.Controllers
{
    public class ConfiguracaoGrupoUsuarioPermissaoController : Controller
    {
        private readonly IGrupoAcessoPermissaoRepository _grupoAcessoPermissaoRepository;
        public ConfiguracaoGrupoUsuarioPermissaoController(IGrupoAcessoPermissaoRepository grupoAcessoPermissaoRepository)
        {
            _grupoAcessoPermissaoRepository = grupoAcessoPermissaoRepository;
        }
        // GET: ConfiguracaoGrupoUsuarioPermissao
        public ActionResult PemissoesUsuario()
        {

            _grupoAcessoPermissaoRepository.
            return View();
        }



        //// GET: ConfiguracaoGrupoUsuarioPermissao/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ConfiguracaoGrupoUsuarioPermissao/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ConfiguracaoGrupoUsuarioPermissao/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ConfiguracaoGrupoUsuarioPermissao/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ConfiguracaoGrupoUsuarioPermissao/Edit/5
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

        //// GET: ConfiguracaoGrupoUsuarioPermissao/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ConfiguracaoGrupoUsuarioPermissao/Delete/5
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
