using System.Threading.Tasks;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Monetria.ViewModels;

public partial class ConfiguracoesPageViewModel : ViewModelBase
{
    private int _clickCount = 0;

    [ObservableProperty]
    private string message = "Clique ou pressione o botão";

    [ObservableProperty]
    private IBrush messageColor = Brushes.Gray;

    [RelayCommand]
    private async Task ResetarDados()
    {
        _clickCount++;

        if (_clickCount < 3)
        {
            Message = $"Clique {_clickCount}/3 para resetar os dados";
            MessageColor = Brushes.Gray;
            return;
        }

        ExecutarResetDosDados();

        Message = "Dados resetados com sucesso!";
        MessageColor = Brushes.Green;

        _clickCount = 0;

        await Task.Delay(500);

        Message = "Ready...";
        MessageColor = Brushes.Gray;
    }

    private void ExecutarResetDosDados()
    {
        //depois colocar o resto dos codigos aqui para realmente resetar
        
    }
}