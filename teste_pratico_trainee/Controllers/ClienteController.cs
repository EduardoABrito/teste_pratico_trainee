using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teste_pratico_trainee.Models;

namespace teste_pratico_trainee.Controllers 
{
    public class ClienteController : Controller
    {
        public ActionResult Cadastrar()=> View();
        public ActionResult Cliente_Cadastrar(Cliente Cliente, Endereco Endereco) {
            try
            {
                int Client_id =Cliente.Inserir(Cliente);
                Cliente.Id = Client_id;
                Endereco.Inserir(Endereco, Cliente);
                Response.StatusCode = StatusCodes.Status201Created;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json(new { success = false });
            }        
        }
        public ActionResult Editar() 
        {
            Cliente Cliente = new Cliente();
            if (RouteData.Values["id"] != default) {
                Cliente = Cliente.Selecionar(Convert.ToInt32(RouteData.Values["id"]));
                if(Cliente.Id == default) Response.Redirect(Url.Action("Index", "Home"));
            }
            else
            {
                Response.Redirect(Url.Action("Index", "Home"));
            }
            return View(Cliente);
        }


        public ActionResult Cliente_Editar(Cliente Cliente)
        {
            try
            {
                Cliente.Editar(Cliente);
                Response.StatusCode = StatusCodes.Status200OK;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json(new { success = false });
            }
        }
        public ActionResult Cliente_Listar() => Json(new { Clientes = Cliente.Selecionar() });

        public ActionResult Cliente_Filtro(Cliente Cliente) => Json(new { Clientes = Cliente.Filtro(Cliente) });

        public ActionResult Cliente_Deletar(Cliente Cliente)
        {
            try
            {
                Cliente.Delete(Cliente);
                Response.StatusCode = StatusCodes.Status200OK;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json(new { success = false });
            }
        }
    }
}