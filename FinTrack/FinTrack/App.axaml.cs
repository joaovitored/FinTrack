using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using FinTrack.Service;
using FinTrack.ViewModels;
using FinTrack.Views;

namespace FinTrack
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Criação do MainWindow
                var mainWindow = new MainWindow();

                // Configuração da injeção de dependência
                var serviceProvider = new ServiceCollection()
                    .AddSingleton<CadastrarServico>()
                    .AddSingleton<SignUpViewModel>()
                    .AddSingleton<NavegarPaginas>(sp => new NavegarPaginas(mainWindow.ContentControl))  // Passando ContentControl
                    .BuildServiceProvider();


                // Obter o SignUpViewModel via injeção de dependência
                var signUpViewModel = serviceProvider.GetRequiredService<SignUpViewModel>();

                // Atribuindo o DataContext
                mainWindow.DataContext = signUpViewModel;

                // Define o MainWindow da aplicação
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}