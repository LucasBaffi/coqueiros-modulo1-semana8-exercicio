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

        [HttpPut("{id}")]
        [Route("Clientes/pessoaFisica/{id}")]
        public IActionResult AtualizarPessoaFisica( [FromBody] PessoaFisica pessoaFisica, int id)

        {
            var clienteExistente = _clienteServices.ObterPorId(id);

            if (clienteExistente == null)
            {
                return NotFound();
            }

            clienteExistente.Nome = pessoaFisica.Nome;
            clienteExistente.Endereco = pessoaFisica.Endereco;
            clienteExistente.Telefone = pessoaFisica.Telefone;
            clienteExistente.Cpf = pessoaFisica.CPF;

            _clienteServices.Atualizar(clienteExistente);

            return Ok();
        }
        
        [HttpPut("{id}")]
        [Route("Clientes/pessoaJuridica/{id}")]
        public IActionResult AtualizarPessoaJuridica(int id, [FromBody] PessoaJuridica pessoaJuridica)
        {
            var clienteExistente = _clienteServices.ObterPorId(id);
            if (clienteExistente == null){
                return NotFound();
            }
            clienteExistente.NomeFantasia = pessoaJuridica.NomeFantasia;
            clienteExistente.Endereco = pessoaJuridica.Endereco;
            clienteExistente.Telefone = pessoaJuridica.Telefone;
            clienteExistente.CNPJ = pessoaJuridica.CNPJ;

            _clienteServices.Atualizar(clienteExistente);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("Clientes/{id}")]
        public IActionResult Delete(int id)
        {
           var clienteExistente = _clienteServices.ObterPorId(id);

            if (clienteExistente == null)
        {
            return NotFound(); // retorna 404 caso o cliente não exista
        }
            if (clienteExistente.Saldo != 0){
                return BadRequest("Nao foi possivel Excluir o cliente");
            }
            _clienteServices.ExcluirCliente(clienteExistente);

            return NoContent();
        }

    }
}