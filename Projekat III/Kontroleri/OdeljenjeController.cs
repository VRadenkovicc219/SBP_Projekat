using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OdeljenjeController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<OdeljenjeDTO>> GetAll(
        [FromQuery] string? oznaka,
        [FromQuery] string? skolskaGodina,
        [FromQuery] int razred = 0)
    {
        try
        {
            return Ok(DTOManager.vratiOdeljenja(oznaka, skolskaGodina, razred));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<OdeljenjeDTO> Get(int id)
    {
        try
        {
            OdeljenjeDTO? o = DTOManager.vratiOdeljenje(id);

            if (o is null)
                return NotFound();

            return Ok(o);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("bez-razrednog")]
    public ActionResult<List<OdeljenjeDTO>> BezRazrednog()
    {
        try
        {
            return Ok(DTOManager.vratiOdeljenjaBezRazrednog());
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
            return Ok(DTOManager.vratiUcenikeKojiNisuUOdeljenju(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{idOdeljenje}/ucenici/{idUcenik}")]
    public IActionResult DodajUcenika(int idOdeljenje, int idUcenik)
    {
        try
        {
            DTOManager.dodajUcenikaUOdeljenje(idOdeljenje, idUcenik);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            DTOManager.obrisiOdeljenje(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/nastava-za-dodavanje")]
    public ActionResult<List<NastavaDTO>> NastavaZaDodavanje(int id)
    {
        try
        {
            return Ok(DTOManager.vratiNastavuZaDodavanjeOdeljenju(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/nastava")]
    public IActionResult DodeliNastavu(int id, [FromBody] List<NastavaDTO> nastave)
    {
        try
        {
            DTOManager.dodeliNastavuOdeljenju(id, nastave);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}