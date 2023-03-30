using Microsoft.AspNetCore.Mvc;
using fullstackbank.Models;
using fullstackbank.Interfaces;
using fullstackbank.Services;
using fullstackbank.Controllers;


namespace fullstackbank.Controllers
{
[Route("transacao")]
public class TransacaoController : Controller
{
    private IClientesServices _clienteService;

    public TransacaoController(IClientesServices clienteServices)
    {
        _clienteService = clienteServices;
    }

    [HttpPost]
    [Route("{idCliente}")]
    public ActionResult AdicionarTransacao([FromBody] Transacao transacao, [FromRoute] int idCliente)
    {
        _clienteService.AdicionarTransacao(transacao, idCliente);
        return Created(Request.Path, transacao);
    }

    [HttpGet]
    [Route("{idCliente}")]
    public ActionResult ListarTransacao([FromRoute] int idCliente)
    {
        return Ok(_clienteService.ListarTransacao(idCliente));
    }
}
}