using System.Net.Http.Json;

var http = new HttpClient { BaseAddress = new Uri("http://localhost:5080/") };
while (true)
{
    Console.WriteLine("\n--- GARAGEM DE VEÍCULOS ---\n1 - Listar\n2 - Buscar por ID\n3 - Cadastrar\n4 - Atualizar\n5 - Excluir\n0 - Sair");
    Console.Write("Opção: ");
    var opcao = Console.ReadLine();
    try
    {
        if (opcao == "1") { var lista = await http.GetFromJsonAsync<List<Veiculo>>("api/veiculos"); foreach (var v in lista ?? new()) Console.WriteLine($"{v.Id} - {v.Marca} {v.Modelo} ({v.Ano}) - {v.Placa}"); }
        else if (opcao == "2") { Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!); var v = await http.GetFromJsonAsync<Veiculo>($"api/veiculos/{id}"); Console.WriteLine(v == null ? "Não encontrado." : $"{v.Id} - {v.Marca} {v.Modelo} ({v.Ano}) - {v.Placa}"); }
        else if (opcao == "3" || opcao == "4") { Console.Write("ID para atualizar (0 se cadastro): "); var id = int.Parse(Console.ReadLine()!); var dto = LerDados(); var resposta = opcao == "3" ? await http.PostAsJsonAsync("api/veiculos", dto) : await http.PutAsJsonAsync($"api/veiculos/{id}", dto); Console.WriteLine(resposta.IsSuccessStatusCode ? "Operação realizada." : "Não foi possível realizar a operação."); }
        else if (opcao == "5") { Console.Write("ID: "); var id = int.Parse(Console.ReadLine()!); var resposta = await http.DeleteAsync($"api/veiculos/{id}"); Console.WriteLine(resposta.IsSuccessStatusCode ? "Excluído." : "Veículo não encontrado."); }
        else if (opcao == "0") break;
        else Console.WriteLine("Opção inválida.");
    }
    catch (Exception e) { Console.WriteLine("Erro: " + e.Message); }
}

static VeiculoDto LerDados() { Console.Write("Marca: "); var marca = Console.ReadLine() ?? ""; Console.Write("Modelo: "); var modelo = Console.ReadLine() ?? ""; Console.Write("Ano: "); var ano = int.Parse(Console.ReadLine()!); Console.Write("Placa: "); var placa = Console.ReadLine() ?? ""; return new VeiculoDto { Marca = marca, Modelo = modelo, Ano = ano, Placa = placa }; }
public class Veiculo { public int Id { get; set; } public string Marca { get; set; } = ""; public string Modelo { get; set; } = ""; public int Ano { get; set; } public string Placa { get; set; } = ""; }
public class VeiculoDto { public string Marca { get; set; } = ""; public string Modelo { get; set; } = ""; public int Ano { get; set; } public string Placa { get; set; } = ""; }
