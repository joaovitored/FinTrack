using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FinTrack.ViewModels
{
    public class SignUpCardBase : INotifyPropertyChanged
    {
        // Evento de PropertyChanged para notificar a UI
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método para disparar o evento de alteração de propriedade
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
