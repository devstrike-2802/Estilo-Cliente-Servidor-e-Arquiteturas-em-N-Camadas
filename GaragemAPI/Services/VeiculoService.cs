using GaragemAPI.DTOs;
using GaragemAPI.Models;
using GaragemAPI.Repositories;

namespace GaragemAPI.Services;

public class VeiculoService
{
    private readonly IVeiculoRepository repositorio;
    public VeiculoService(IVeiculoRepository repositorio) => this.repositorio = repositorio;
    public List<Veiculo> Listar() => repositorio.Listar();
    public Veiculo? Buscar(int id) => repositorio.Buscar(id);
    public Veiculo? Adicionar(VeiculoDto dto)
    {
        if (!Validar(dto)) return null;
        return repositorio.Adicionar(new Veiculo { Marca = dto.Marca.Trim(), Modelo = dto.Modelo.Trim(), Ano = dto.Ano, Placa = dto.Placa.Trim().ToUpper() });
    }
    public bool Atualizar(int id, VeiculoDto dto)
    {
        if (!Validar(dto) || repositorio.Buscar(id) == null) return false;
        return repositorio.Atualizar(new Veiculo { Id = id, Marca = dto.Marca.Trim(), Modelo = dto.Modelo.Trim(), Ano = dto.Ano, Placa = dto.Placa.Trim().ToUpper() });
    }
    public bool Excluir(int id) => repositorio.Excluir(id);
    private bool Validar(VeiculoDto d) => !string.IsNullOrWhiteSpace(d.Marca) && !string.IsNullOrWhiteSpace(d.Modelo) && d.Ano >= 1900 && d.Ano <= DateTime.Now.Year + 1 && !string.IsNullOrWhiteSpace(d.Placa);
}
