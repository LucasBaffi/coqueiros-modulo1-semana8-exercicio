using Microsoft.AspNetCore.Mvc;
using fullstackbank.Models;
using fullstackbank.Interfaces;
using fullstackbank.Services;



namespace fullstackbank.Controllers
{

    [Route("Clientes")]
    public class ClienteControllers : Controller
    {

        private IClienteServices _clienteServices;

        public  ClientesController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost]
        [Route("pessoafisica")]
        public ActionResult PostPessoaFisica([FromBody] PessoaFisica pessoaFisica)
        {
            _clienteServices.CriarConta(pessoaFisica);
            return Created(Request.Path, pessoaFisica);
        }

        [HttpPost]
        [Route("pessoajuridica")]
        public ActionResult PostPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
        {
            _clienteServices.CriarConta(pessoaJuridica);
            return Created(Request.Path, pessoaJuridica);
        }
        [HttpGet]
        [Route("pessoafisica")]
        public IActionResult ExibirPessoaFisica()
        {
            var clientes = _clienteServices.ExibirClientesPF();
            return Ok(clientes);
        }

        [HttpGet]
        [Route("pessoajuridica")]
        public IActionResult ExibirPessoasJuridicas()
        {
            var cliente = _clienteServices.ExibirClientesPJ();
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarCliente(int id)
        {
            var cliente = _clienteServices.BuscarCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPut]
        [Route("pessoaFisica/{id}")]
        public IActionResult AtualizarPessoaFisica([FromBody] PessoaFisica pessoaFisica, int id)

        {
            var clienteExistente = _clienteServices.AtualizarPessoaFisica(pessoaFisica, id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [Route("Clientes/pessoaJuridica/{id}")]
        public IActionResult AtualizarPessoaJuridica(int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            var clienteExistente = _clienteServices.AtualizarPessoaJuridica(pessoaJuridica, id);
            if (clienteExistente == null)
            {
                return NotFound();
            }         

            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            var clienteExistente = _clienteServices.BuscarCliente(id);

            if (clienteExistente == null)
            {
                return NotFound(); // retorna 404 caso o cliente não exista
            }
            if (clienteExistente.Saldo != 0)
            {
                return BadRequest("Nao foi possivel Excluir o cliente");
            }
            _clienteServices.DeletarCliente(id);

            return NoContent();
        }

    }
}