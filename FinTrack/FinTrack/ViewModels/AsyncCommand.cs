using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinTrack.ViewModels
{
    public class AsyncCommand : ICommand
    {
        private readonly Func<Task> _executeAsync;
        private readonly Func<bool> _canExecute;

        // Construtor
        public AsyncCommand(Func<Task> executeAsync, Func<bool> canExecute = null)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        // Verifica se o comando pode ser executado
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        // Executa o comando
        public async void Execute(object parameter)
        {
            await ExecuteAsync();
        }

        // Método assíncrono
        public async Task ExecuteAsync()
        {
            if (CanExecute(null))
            {
                await _executeAsync();
            }
        }

        // Método para atualizar a verificação de quando o comando pode ser executado
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}