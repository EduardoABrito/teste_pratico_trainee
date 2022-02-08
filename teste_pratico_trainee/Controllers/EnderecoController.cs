using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using teste_pratico_trainee.Models;

namespace teste_pratico_trainee.Controllers
{
    public class EnderecoController : Controller
    {

        public ActionResult Endereco_Listar_ClienteId(int Cliente_id) 
        {
            try
            {
                //int test= Convert.ToInt32(RouteData.Values["id"]);
                return Json(new { Enderecos = Endereco.Selecionar_ClienteId(Cliente_id) });
            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json(new { success = false });
            }           
        }

        public ActionResult Endereco_Listar_id(int id)=> Json(new { Endereco = Endereco.Selecionar_Id(id) });

        public ActionResult Endereco_Editar_id(Endereco Endereco,Cliente Cliente)
        {
            try
            {
                if(Endereco.Id == default)
                {
                    Endereco.Inserir(Endereco, Cliente);
                }
                else
                {
                    Endereco.Editar(Endereco, Cliente);
                }
                Response.StatusCode = StatusCodes.Status200OK;
                return Json(new { success = true });
            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return Json(new { success = false });
            }
        }
        public ActionResult Endereco_Deletar(Endereco Endereco)
        {
            try
            {
                Endereco.Delete(Endereco);
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