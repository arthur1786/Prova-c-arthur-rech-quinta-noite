using System.Collections.Generic;
using System.Linq;
using API_Folhas.Models;
using API_Folhas.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Folhas.Controllers{
    [ApiController]
    [Route ("api/folha")]

    public class FolhaController : ControllerBase{
        
        private readonly DataContext _context;

        public FolhaController(DataContext context) => 
        _context = context;

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] FolhaPagamento folha)
        {

            Calculos calculos = new Calculos();
            folha.SalarioBruto = Calculos.CalcularSalarioBruto(folha.QuantidadeHoras, folha.ValorHora);

            folha.ImpostoRenda = 
                Calculos.CalcularImpostoRenda(folha.SalarioBruto);

            folha.ImpostoInss = 
                Calculos.CalcularImpostoInss(folha.SalarioBruto);

            folha.ImpostoFgts = 
                Calculos.CalcularFgts(folha.SalarioBruto);

            folha.SalarioLiquido = 
                Calculos.CalculaSalarioLiquido
                (
                    folha.SalarioBruto,
                    folha.ImpostoRenda,
                    folha.ImpostoInss
                );

            _context.Folhas.Add(folha);
            _context.SaveChanges();
            return Created("", folha);
        }
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar(){
            List<FolhaPagamento> folhas = _context.Folhas.Include(f => f.Funcionario).ToList();
            return folhas.Count != 0 ? Ok(folhas) : NotFound();

        }

        [HttpGet]
        [Route("Buscar/{cpf}/{mes}/{ano}")]
        public IActionResult Buscar(string cpf, int mes, int ano)=>
        Ok(_context.Folhas.Include(f => f.Funcionario)
        .Where(
            f=>
            f.CriadoEm.Month == mes &&
            f.CriadoEm.Year == ano));
        
    }
}