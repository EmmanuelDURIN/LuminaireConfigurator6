using LuminaireConfigurator6.Server.Repositories;
using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace LuminaireConfigurator6.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class LuminaireConfigurationController : ControllerBase
  {
    private readonly LuminaireRepository luminaireRepository;
    private readonly ILogger<LuminaireConfigurationController> logger;
    public LuminaireConfigurationController(LuminaireRepository luminaireRepository, ILogger<LuminaireConfigurationController> logger)
    {
      this.luminaireRepository = luminaireRepository;
      this.logger = logger;
    }
    [HttpGet]
    public List<LuminaireConfiguration> Get()
    {
      return luminaireRepository.GetAllLuminaires();
    }
    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      LuminaireConfiguration? lumConf = luminaireRepository.GetLuminaireById(id);
      if (lumConf == null)
        return NotFound("No Luminaire with id=" + id);
      return Ok(lumConf);
    }
    [HttpPost]

    public ActionResult PostAsync(LuminaireConfiguration lumConf)
    {
      if (!ModelState.IsValid)
        return ValidationProblem(ModelState);
      luminaireRepository.InsertLuminaire(lumConf);
      return CreatedAtAction(nameof(GetById), routeValues: new { Id = lumConf.Id }, lumConf);
    }
  }
}