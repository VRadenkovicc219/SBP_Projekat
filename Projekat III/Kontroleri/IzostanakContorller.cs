using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class IzostanakController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] NoviIzostanakDTO dto)
    {
        try
        {
            DTOManager.dodajIzostanak(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ucenik/{idUcenik}/predmet/{idPredmet}")]
    public ActionResult<List<IzostanakDTO>> Get(int idUcenik, int idPredmet)
    {
        try
        {
            return Ok(DTOManager.vratiIzostankeUcenikaNaPredmetu(idUcenik, idPredmet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("ucenik/{idUcenik}")]
    public ActionResult<List<IzostanakDTO>> Svi(int idUcenik)
    {
        try
        {
            return Ok(DTOManager.vratiSveIzostankeUcenika(idUcenik));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}