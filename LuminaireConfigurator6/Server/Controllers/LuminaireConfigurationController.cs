using LuminaireConfigurator6.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace LuminaireConfigurator6.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class LuminaireConfigurationController : ControllerBase
  {
    public static List<LuminaireConfiguration> LuminaireConfigurations { get; } = new List<LuminaireConfiguration>()
            {
              new LuminaireConfiguration
              {
                Id=1,
                CreationTime = new DateTime(2020,11,8),
                LampColor = 5400,
                LampFlux = 2000,
                Optic = "OM10",
                Name="Luminaires Nanterre"
              },
              new LuminaireConfiguration
              {
                Id=2,
                CreationTime = new DateTime(2020,12,9),
                LampColor = 5700,
                LampFlux = 3000,
                Optic = "OM11",
                Name="Luminaires Courbevoie"
              },
              new LuminaireConfiguration
              {
                Id=3,
                CreationTime = new DateTime(2021,1,4),
                LampColor = 5700,
                LampFlux = 10000,
                Optic = "OM12",
                Name="Luminaires Puteaux"
              },
            };

    private readonly ILogger<LuminaireConfigurationController> _logger;
    public LuminaireConfigurationController(ILogger<LuminaireConfigurationController> logger)
    {
      _logger = logger;
    }
    [HttpGet]
    public List<LuminaireConfiguration> Get()
    {
      return LuminaireConfigurations;
    }
    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
      LuminaireConfiguration? lumConf = LuminaireConfigurations
                                         .FirstOrDefault(l => l.Id == id);
      if (lumConf == null)
        return NotFound("No Luminaire with id=" + id);
      return Ok(lumConf);
    }
    [HttpPost]
    public ActionResult PostAsync(LuminaireConfiguration lumConf)
    {
      if (!ModelState.IsValid)
        return ValidationProblem(ModelState);
      int maxId = LuminaireConfigurations.Max(l => l.Id);
      lumConf.Id = maxId +1;
      LuminaireConfigurations.Add(lumConf);
      return CreatedAtAction(nameof(GetById), routeValues: new { Id = lumConf.Id }, lumConf);
    }
    const int totalLuminaires = 500_000;
    [HttpGet("count")]
    public int GetCount()
    {
      return totalLuminaires;
    }
    [HttpGet("range")]
    public IEnumerable<LuminaireConfiguration> GetRange(int startIndex, int numConfigurations)
    {
      return Enumerable.Range(startIndex, numConfigurations).Select(i => new LuminaireConfiguration
      {
        Id = i,
        Name = "Luminaire" + i,
        CreationTime = DateTime.Now,
        LampColor = 3000 + (i % 2000),
        Optic = "OM" + (i % 10),
        LampFlux = 1000,
      })
      .ToArray();
    }
  }
}