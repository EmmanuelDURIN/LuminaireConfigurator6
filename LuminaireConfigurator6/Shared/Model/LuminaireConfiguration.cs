namespace LuminaireConfigurator6.Shared.Model
{
  public class LuminaireConfiguration : IEquatable<LuminaireConfiguration?>
  {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double LampFlux { get; set; }
    public decimal Price { get; set; }
    public string Optic { get; set; } = "";
    public DateTime CreationTime { get; set; }
    public int LampColor { get; set; }
    public override bool Equals(object? obj)
    {
      return Equals(obj as LuminaireConfiguration);
    }

    public bool Equals(LuminaireConfiguration? other)
    {
      return other != null &&
             Id == other.Id;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Id);
    }

    public static bool operator ==(LuminaireConfiguration? left, LuminaireConfiguration? right)
    {
      return EqualityComparer<LuminaireConfiguration>.Default.Equals(left, right);
    }

    public static bool operator !=(LuminaireConfiguration? left, LuminaireConfiguration? right)
    {
      return !(left == right);
    }
  }
}
