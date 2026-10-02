using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UcenikController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<UcenikDTO>> GetAll()
    {
        try
        {
            return Ok(DTOManager.vratiUcenike());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<UcenikDTO> Get(int id)
    {
        try
        {
            UcenikDTO? u = DTOManager.vratiUcenika(id);

            if (u is null)
                return NotFound();

            return Ok(u);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/predmeti")]
    public ActionResult<List<PredmetiDTO>> Predmeti(int id)
    {
        try
        {
            return Ok(DTOManager.vratiPredmeteUcenika(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/razred")]
    public ActionResult<string> Razred(int id)
    {
        try
        {
            return Ok(DTOManager.vratiRazred(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{idUcenik}/predmeti/{idPredmet}")]
    public IActionResult DodeliPredmet(int idUcenik, int idPredmet)
    {
        try
        {
            DTOManager.dodeliPredmetUceniku(idUcenik, idPredmet);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{idUcenik}/predmeti/{idPredmet}")]
    public IActionResult IzbaciSaPredmeta(int idUcenik, int idPredmet)
    {
        try
        {
            DTOManager.izbaciUcenikaSaPredmeta(idUcenik, idPredmet);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}