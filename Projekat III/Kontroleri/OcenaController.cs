using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OcenaController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] NovaOcenaDTO dto)
    {
        try
        {
            DTOManager.dodeliOcenu(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] IzmenaOceneDTO dto)
    {
        try
        {
            DTOManager.izmeniOcenu(id,dto);

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
            DTOManager.obrisiOcenu(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("tip/{tip}")]
    public ActionResult<List<OcenaDetaljDTO>> PoTipu(TipOcene tip)
    {
        try
        {
            return Ok(DTOManager.vratiOcenePoTipu(tip));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}