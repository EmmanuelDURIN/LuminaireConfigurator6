using LuminaireConfigurator6.Shared.Model;
using System.ComponentModel;

namespace LuminaireConfigurator6.Client.Pages
{
  public interface ISelectionProvider : INotifyPropertyChanged
  {
    LuminaireConfiguration? SelectedConfiguration { get; set; }
  }
}