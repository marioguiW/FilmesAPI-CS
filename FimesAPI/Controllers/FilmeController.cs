using FimesAPI.Modules;
using Microsoft.AspNetCore.Mvc;

namespace FimesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new();

    private static int id = 0;

    [HttpPost]
    public void AdicionaFilme([FromBody] Filme filme)
    {
        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }

    [HttpGet]
    public List<Filme> ExibeFilme()
    {
        return filmes;
    }

    [HttpGet("{id}")]

    public Filme? BuscaFilme(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }
}
