using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using FinTrack.Views.Components; 
using FinTrack.Service;
using System;


using System;

namespace FinTrack.Views.Components
{
    public partial class LoginCard : UserControl
    {
        private readonly NavegarPaginas? _navegarPaginas;  // Instancia de NavegarPaginas
        
        // Construtor que recebe o NavegarPaginas
        public LoginCard(NavegarPaginas navegarPaginas) 
        {
            InitializeComponent();
            _navegarPaginas = navegarPaginas;  // Atribui a instância de NavegarPaginas
        }
      
        private bool _senhaVisivel;
        private void VisualizarSenha(object? sender, RoutedEventArgs e)
        {
            _senhaVisivel = !_senhaVisivel;

            // Alterna a senha
            SenhaBox.PasswordChar = _senhaVisivel ? '\0' : '●';

            // Alterna o ícone
            var uri = new Uri(
                _senhaVisivel
                    ? "avares://FinTrack/Assets/Images/olho_aberto.png"
                    : "avares://FinTrack/Assets/Images/olho_fechado.png"
            );

            var assetLoader = AssetLoader.Open(uri);
            SenhaIcon.Source = new Bitmap(assetLoader);
        }
        
       
        // Método de navegação para o cadastro
        private void NavegarParaCadastro()
        {
            _navegarPaginas?.NavegarPara(new SignUp()); // Navega para a tela de SignUp
        }
    }
}