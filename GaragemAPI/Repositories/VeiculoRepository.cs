using System.Text.Json;
using GaragemAPI.Models;

namespace GaragemAPI.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly string arquivo = Path.Combine(AppContext.BaseDirectory, "Data", "veiculos.json");
    private List<Veiculo> veiculos;

    public VeiculoRepository()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(arquivo)!);
        if (!File.Exists(arquivo)) File.WriteAllText(arquivo, "[]");
        veiculos = JsonSerializer.Deserialize<List<Veiculo>>(File.ReadAllText(arquivo)) ?? new();
    }

    private void Salvar() => File.WriteAllText(arquivo, JsonSerializer.Serialize(veiculos, new JsonSerializerOptions { WriteIndented = true }));
    public List<Veiculo> Listar() => veiculos;
    public Veiculo? Buscar(int id) => veiculos.FirstOrDefault(v => v.Id == id);
    public Veiculo Adicionar(Veiculo v) { v.Id = veiculos.Count == 0 ? 1 : veiculos.Max(x => x.Id) + 1; veiculos.Add(v); Salvar(); return v; }
    public bool Atualizar(Veiculo v) { var atual = Buscar(v.Id); if (atual == null) return false; atual.Marca = v.Marca; atual.Modelo = v.Modelo; atual.Ano = v.Ano; atual.Placa = v.Placa; Salvar(); return true; }
    public bool Excluir(int id) { var v = Buscar(id); if (v == null) return false; veiculos.Remove(v); Salvar(); return true; }
}
