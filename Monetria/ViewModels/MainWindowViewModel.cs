using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Monetria.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen = true;

    [RelayCommand]
    private void OpenPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
}