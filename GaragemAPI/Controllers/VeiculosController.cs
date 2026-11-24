using GaragemAPI.DTOs;
using GaragemAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GaragemAPI.Controllers;

[ApiController]
[Route("api/veiculos")]
public class VeiculosController : ControllerBase
{
    private readonly VeiculoService servico;
    public VeiculosController(VeiculoService servico) => this.servico = servico;
    [HttpGet] public IActionResult Listar() => Ok(servico.Listar());
    [HttpGet("{id:int}")] public IActionResult Buscar(int id) { var v = servico.Buscar(id); return v == null ? NotFound() : Ok(v); }
    [HttpPost] public IActionResult Adicionar(VeiculoDto dto) { var v = servico.Adicionar(dto); return v == null ? BadRequest("Dados inválidos.") : CreatedAtAction(nameof(Buscar), new { id = v.Id }, v); }
    [HttpPut("{id:int}")] public IActionResult Atualizar(int id, VeiculoDto dto) => servico.Atualizar(id, dto) ? NoContent() : BadRequest("Veículo inexistente ou dados inválidos.");
    [HttpDelete("{id:int}")] public IActionResult Excluir(int id) => servico.Excluir(id) ? NoContent() : NotFound();
}
