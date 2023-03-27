using Microsoft.AspNetCore.Mvc;
using fullstackbank.Models;


namespace fullstackbank.Controllers
{

    [Route("Clientes")]
    public class ClienteControllers : Controller
    {

        private IClientesServices _clienteServices;

        public ClientesController(IClientesServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost]
        [Route("pessoafisica")]
        public ActionResult CriarPessoaFisica([FromBody] PessoaFisica pessoaFisica)
        {
            _clienteServices.Inserir(pessoaFisica);
            return Created(Request.Path, pessoaFisica);
        }

        [HttpPost]
        [Route("pessoajuridica")]
        public ActionResult CriarPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
        {
            _clienteServices.Inserir(pessoaJuridica);
            return Created(Request.Path, pessoaJuridica);
        }

    }
}