using FilmesApi_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    public  IActionResult AdicionaFilme([FromBody] Filme filme)
    {
        filme.id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperarFilmePorId), new {id = filme.id},
            filme);
        
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50)    
    {
        return filmes.Skip(skip).Take(take);  
    }
    [HttpGet("{id}")]
    public IActionResult RecuperarFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.id == id);
        if (filme == null) return NotFound();
        return Ok();
    }
}
