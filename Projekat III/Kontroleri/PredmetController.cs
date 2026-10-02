using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PredmetController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<PredmetDTO>> GetAll([FromQuery] string? skolskaGodina)
    {
        try
        {
            return Ok(DTOManager.vratiPredmete(skolskaGodina));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<PredmetDTO> Get(int id)
    {
        try
        {
            PredmetDTO? p = DTOManager.vratiPredmet(id);

            if (p is null)
                return NotFound();

            return Ok(p);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/ucenici")]
    public ActionResult<List<UcenikDTO>> Ucenici(int id)
    {
        try
        {
            return Ok(DTOManager.vratiUcenikeKojiSlusajuPredmet(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{idPredmet}/ucenici/{idUcenik}/ocene")]
    public ActionResult<List<OcenaDetaljDTO>> Ocene(int idPredmet, int idUcenik)
    {
        try
        {
            return Ok(DTOManager.vratiOceneUcenikaNaPredmetu(idUcenik, idPredmet));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{idPredmet}/ucenici/{idUcenik}/izostanci")]
    public ActionResult<List<IzostanakDTO>> Izostanci(int idPredmet, int idUcenik)
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
}