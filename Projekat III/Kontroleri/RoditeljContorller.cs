using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoditeljController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<RoditeljDTO>> GetAll()
    {
        try
        {
            return Ok(DTOManager.vratiRoditelje());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<RoditeljDTO> Get(int id)
    {
        try
        {
            RoditeljDTO? r = DTOManager.vratiRoditelja(id);

            if (r is null)
                return NotFound();

            return Ok(r);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/deca")]
    public ActionResult<List<UcenikDTO>> Deca(int id)
    {
        try
        {
            return Ok(DTOManager.vratiDecuRoditelja(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/ucenici-za-dodavanje")]
    public ActionResult<List<UcenikDTO>> UceniciZaDodavanje(int id)
    {
        try
        {
            return Ok(DTOManager.vratiUcenikeKojiNisuDeteRoditelja(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{idRoditelj}/deca/{idUcenik}")]
    public IActionResult DodajDete(int idRoditelj, int idUcenik)
    {
        try
        {
            DTOManager.dodajVezuRoditeljUcenik(idRoditelj, idUcenik);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{idRoditelj}/deca/{idUcenik}")]
    public IActionResult UkloniDete(int idRoditelj, int idUcenik)
    {
        try
        {
            DTOManager.raskiniVezuRoditeljUcenik(idRoditelj, idUcenik);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}