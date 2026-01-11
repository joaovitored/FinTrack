using Avalonia.Controls;
using FinTrack.ViewModels;
using FinTrack.Service;
using FinTrack.Views.Components; // Importa o LoginCard

namespace FinTrack.Views
{
    public partial class MainWindow : Window
    {
        private readonly NavegarPaginas _navegarPaginas;

        public MainWindow()
        {
            InitializeComponent();

            // Cria o serviço de navegação
            _navegarPaginas = new NavegarPaginas(ContentControl);  

            var authService = new AutenticarServico(); // Cria o Service de autenticação

            // Passa o _navegarPaginas para o LoginCardViewModel
            var loginCardViewModel = new LoginCardViewModel(authService, _navegarPaginas);

            // Cria o LoginCard e passa o _navegarPaginas
            var loginCard = new LoginCard(_navegarPaginas); // Passa NavegarPaginas para o LoginCard
            loginCard.DataContext = loginCardViewModel;      // Configura o DataContext para o LoginCardViewModel

            // Altera o conteúdo da janela para o LoginCard
            ContentControl.Content = loginCard;
        }

        public void NavegarParaCadastro()
        {
            var cadastroPage = new SignUp(); // Cria o UserControl SignUp
            ContentControl.Content = cadastroPage; // Altera o conteúdo da janela para o UserControl SignUp
        }
    }
}