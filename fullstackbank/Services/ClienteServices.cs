using Microsoft.AspNetCore.Mvc;
using fullstackbank.Models;
using fullstackbank.Interfaces;
using fullstackbank.Services;

namespace fullstackbank.Services
{
   
   public class ClienteServices : IClienteServices
{
    static List<Cliente> _clientes = new();

    public void CriarConta(Cliente cliente)
    {
        _clientes.Add(cliente);
    }
    public List<PessoaFisica> ExibirClientesPF()
    {
        List<PessoaFisica> clientesPF = _clientes.OfType<PessoaFisica>().ToList();
        return clientesPF;
    }
    public List<PessoaJuridica> ExibirClientesPJ()
    {
        List<PessoaJuridica> clientesPJ = _clientes.OfType<PessoaJuridica>().ToList();
        return clientesPJ;
    }

    public Cliente BuscarCliente(int id)
    {
        return _clientes.Find(x => x.NumeroConta == id);
    }

    public void DeletarCliente(int id)
    {
        _clientes.Remove(BuscarCliente(id));
    }

    public Cliente AtualizarPessoaFisica(PessoaFisica pessoaFisica, int id)
    {
        PessoaFisica newPessoaFisica = BuscarCliente(id) ;

        if (pessoaFisica != null)
        {
            newPessoaFisica.Email = pessoaFisica.Email;
            newPessoaFisica.Telefone = pessoaFisica.Telefone;
            newPessoaFisica.Endereco = pessoaFisica.Endereco;
            newPessoaFisica.Nome = pessoaFisica.Nome;
            newPessoaFisica.CPF = pessoaFisica.CPF;
            newPessoaFisica.DataNascimento = pessoaFisica.DataNascimento;
        }

        return newPessoaFisica;
    }

    public Cliente AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica, int id)
    {
        PessoaJuridica newPessoaJuridica = BuscarCliente(id) as PessoaJuridica;

        if (newPessoaJuridica != null)
        {
            newPessoaJuridica.Email = pessoaJuridica.Email;
            newPessoaJuridica.Telefone = pessoaJuridica.Telefone;
            newPessoaJuridica.Endereco = pessoaJuridica.Endereco;
            newPessoaJuridica.RazaoSocial = pessoaJuridica.RazaoSocial;
            newPessoaJuridica.NomeFantasia = pessoaJuridica.NomeFantasia;
            newPessoaJuridica.CNPJ = pessoaJuridica.CNPJ;
            newPessoaJuridica.DataAbertura = pessoaJuridica.DataAbertura;
        }

        return newPessoaJuridica;
    }

    public void AdicionarTransacao(Transacao transacao, int idCliente)
    {
        Cliente cliente = BuscarCliente(idCliente);

        cliente.Extrato.Add(transacao);
    }

    public List<Transacao> ListarTransacao(int idCliente)
    {
        Cliente cliente = BuscarCliente(idCliente);

        return cliente.Extrato;
    }
}
}
