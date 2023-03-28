using Microsoft.AspNetCore.Mvc;
using fullstackbank.Models;


namespace fullstackbank.Controllers
{

    [Route("Clientes")]
    public class ClienteControllers : Controller
    {

        private IClientesServices _clienteServices;

        public void ClientesController(IClientesServices clienteServices)
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
        [HttpGet]
        [Route("Clientes")]
        public IActionResult ObterTodos()
        {
            var clientes = _clienteServices.ObterTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        [Route("Clientes/{id}")]
        public IActionResult ObterPorId(int id)
        {
            var cliente = _clienteServices.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }


    }
}