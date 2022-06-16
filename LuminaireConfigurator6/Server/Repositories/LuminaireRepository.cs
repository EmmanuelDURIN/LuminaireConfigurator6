using Dapper;
using LuminaireConfigurator6.Shared.Model;
using System.Data;
using System.Data.SqlClient;

namespace LuminaireConfigurator6.Server.Repositories
{
  public class LuminaireRepository : IDisposable
  {
    private string connectionString;
    private IDbConnection? dbConnection;
    public LuminaireRepository(IConfiguration configuration)
    {
      // connectionString comes from appsettings.json or appsettings.Development.json
      // but it could also come from an environment variable o rcomd line parameter as IConfiguration is built to also support those providers
      connectionString = configuration.GetConnectionString("LuminairesConnectionString");
    }
    internal List<LuminaireConfiguration> GetAllLuminaires()
    {
      dbConnection = GetConnection();
      List<LuminaireConfiguration> luminaireConfigurations = GetConnection()
                                      .Query<LuminaireConfiguration>($"SELECT * FROM dbo.Luminaires")
                                      .ToList();
      return luminaireConfigurations;
    }
    internal LuminaireConfiguration? GetLuminaireById(int id)
    {
      LuminaireConfiguration luminaireConfiguration = GetConnection()
                                            .Query<LuminaireConfiguration>($"SELECT * FROM dbo.Luminaires where id={id}").Single();
      return luminaireConfiguration;
    }
    internal void InsertLuminaire(LuminaireConfiguration lumConf)
    {
      string sqlQuery =
@"INSERT INTO dbo.Luminaires (Name, LampFlux, Price, Optic, CreationTime, LampColor) 
VALUES(@Name, @LampFlux,@Price, @Optic,@CreationTime,@LampColor);
SELECT CAST(SCOPE_IDENTITY() as int)";
      int id = GetConnection().QuerySingle<int>(sqlQuery, lumConf);
      lumConf.Id = id;
    }
    private IDbConnection GetConnection()
    {
      if (dbConnection == null)
      {
        dbConnection = new SqlConnection(connectionString);
        dbConnection.Open();
      }
      return dbConnection;
    }
    public void Dispose()
    {
      dbConnection?.Dispose();
    }
  }
}
