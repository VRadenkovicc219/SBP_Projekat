using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NastavnikController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<NastavnikDTO>> GetAll()
    {
        try
        {
            return Ok(DTOManager.vratiNastavnike());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<NastavnikDTO> Get(int id)
    {
        try
        {
            NastavnikDTO? n = DTOManager.vratiNastavnika(id);

            if (n is null)
                return NotFound();

            return Ok(n);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/predmeti")]
    public ActionResult<List<PredmetiDTO>> Predmeti(int id, [FromQuery] string? skolskaGodina)
    {
        try
        {
            return Ok(DTOManager.vratiPredmeteNastavnika(id, skolskaGodina));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{idNastavnik}/predmeti/{idPredmet}/odeljenja/{idOdeljenje}/ucenici")]
    public ActionResult<List<UcenikDTO>> Ucenici(int idNastavnik, int idPredmet, int idOdeljenje)
    {
        try
        {
            return Ok(DTOManager.vratiUcenikeZaPredmet(idOdeljenje, idPredmet, idNastavnik));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/razredni-staresina")]
    public IActionResult DodeliRazrednog(int id, [FromBody] RazredniStaresinaUnosDTO dto)
    {
        try
        {
            DTOManager.dodeliRazrednogStaresinu(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/rukovodeca-funkcija")]
    public IActionResult DodeliRukovodecu(int id, [FromBody] RukovodecaFunkcijaUnosDTO dto)
    {
        try
        {
            DTOManager.dodeliRukovodecuFunkciju(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id}/strucni-saradnik")]
    public IActionResult DodeliStrucnog(int id, [FromBody] StrucniSaradnikUnosDTO dto)
    {
        try
        {
            DTOManager.dodeliStrucnogSaradnika(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}/dodatna-uloga")]
    public IActionResult UkiniUlogu(int id)
    {
        try
        {
            DTOManager.ukiniDodatnuUlogu(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("razredne-staresine")]
    public ActionResult<List<RazredniStaresinaDTO>> SveRazredne()
    {
        try
        {
            return Ok(DTOManager.vratiSveRazredneStaresine());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("rukovodece-osoblje")]
    public ActionResult<List<RukovodeceOsobljeDTO>> SveRukovodece()
    {
        try
        {
            return Ok(DTOManager.vratiRukovodeceOsoblje());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("strucni-saradnici")]
    public ActionResult<List<StrucniSaradnikDTO>> SviStrucni()
    {
        try
        {
            return Ok(DTOManager.vratiStrucneSaradnike());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}