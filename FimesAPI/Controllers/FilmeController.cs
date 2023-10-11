using AutoMapper;
using FimesAPI.Data;
using FimesAPI.Modules;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FimesAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

   
    [HttpPost]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDtos filmeDto)
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscaFilmePorId),
            new { id = filme.Id },
            filme);
    }

    [HttpGet]
    public IEnumerable<Filme> ExibeFilme()
    {
        return _context.Filmes;
    }

    [HttpGet("{id}")]

    public IActionResult BuscaFilmePorId(int id)
    {
        var filme = _context.Filmes.
            FirstOrDefault(filme => filme.Id == id);
        if(filme == null) return NotFound();
        return Ok(filme);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDtos filmeDto)
    {
        var filme = _context.Filmes.
            FirstOrDefault(filme => filme.Id == id);

        if(filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]

    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDtos> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
           filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDtos>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState); 
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }
}
