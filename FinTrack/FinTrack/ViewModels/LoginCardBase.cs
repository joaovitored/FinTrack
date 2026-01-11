using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinTrack.ViewModels;

public class LoginCardBase : INotifyPropertyChanged
{
    // Nullability compatível com INotifyPropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    // OnPropertyChanged compatível
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}