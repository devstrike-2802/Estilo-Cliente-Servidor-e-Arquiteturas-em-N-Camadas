using GaragemAPI.Models;

namespace GaragemAPI.Repositories;

public interface IVeiculoRepository
{
    List<Veiculo> Listar();
    Veiculo? Buscar(int id);
    Veiculo Adicionar(Veiculo veiculo);
    bool Atualizar(Veiculo veiculo);
    bool Excluir(int id);
}
