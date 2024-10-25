using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MigracionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoticiaController : ControllerBase
    {
        private static List<Noticia> _noticias = new List<Noticia>
        {
            new Noticia { Id = 1, Titulo = "Noticia 1", Contenido = "Contenido de la noticia 1" },
            new Noticia { Id = 2, Titulo = "Noticia 2", Contenido = "Contenido de la noticia 2" }
        };

        // Obtener todas las noticias
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_noticias);
        }

        // Obtener una noticia por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var noticia = _noticias.Find(n => n.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }
            return Ok(noticia);
        }

        // Crear una nueva noticia
        [HttpPost]
        public IActionResult Create([FromBody] Noticia nuevaNoticia)
        {
            nuevaNoticia.Id = _noticias.Count + 1; // Asigna un ID único
            _noticias.Add(nuevaNoticia);
            return CreatedAtAction(nameof(GetById), new { id = nuevaNoticia.Id }, nuevaNoticia);
        }
    }

    // Modelo de Noticia
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
    }
}
