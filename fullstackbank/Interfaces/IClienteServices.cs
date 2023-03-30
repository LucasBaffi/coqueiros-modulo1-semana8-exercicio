
using fullstackbank.Models;



namespace fullstackbank.Interfaces
{
    public interface IClienteServices
    {
        
    void CriarConta(Cliente cliente);
    List<PessoaFisica> ExibirClientesPF();
    List<PessoaJuridica> ExibirClientesPJ();
    Cliente BuscarCliente(int id);
    Cliente AtualizarPessoaFisica(PessoaFisica pessoaFisica, int id);
    Cliente AtualizarPessoaJuridica(PessoaJuridica pessoaJuridica, int id);
    void DeletarCliente(int id);
    void AdicionarTransacao(Transacao transacao, int idCliente);
    List<Transacao> ListarTransacao(int idCliente);
    }
}