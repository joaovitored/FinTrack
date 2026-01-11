using Avalonia.Controls;
using FinTrack.Service;
using FinTrack.ViewModels;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace FinTrack.Views.Components;

public partial class SignUp : UserControl
{
    private readonly NavegarPaginas? _navegarPaginas;  // Instancia de NavegarPaginas
    public SignUp()
    {
        InitializeComponent();
        
        DataContext = new SignUpViewModel(new CadastrarServico(), new NavegarPaginas(this));
    }
    
    
    private bool _senhaVisivel;
    private void VisualizarSenha(object? sender, RoutedEventArgs e)
    {
        _senhaVisivel = !_senhaVisivel;

        // alterna a senha
        CaixaSenha.PasswordChar = _senhaVisivel ? '\0' : '●';

        // alterna o ícone ao clicar
        var uri = new Uri(
            _senhaVisivel
                ? "avares://FinTrack/Assets/Images/olho_aberto.png"
                : "avares://FinTrack/Assets/Images/olho_fechado.png"
        );

        var assetLoader = AssetLoader.Open(uri);
        SenhaIcon.Source = new Bitmap(assetLoader);
    }

    
    private bool _confirmarVisualizarSenha;
    private void ConfirmarVisualizarSenha(object? sender, RoutedEventArgs e)
    {
        _confirmarVisualizarSenha = !_confirmarVisualizarSenha;

        ConfirmarCaixaSenha.PasswordChar = _confirmarVisualizarSenha ? '\0' : '●';
        
        var uri = new Uri(
            _senhaVisivel
                ? "avares://FinTrack/Assets/Images/olho_aberto.png"
                : "avares://FinTrack/Assets/Images/olho_fechado.png"
        );

        var assetLoader = AssetLoader.Open(uri);
        ConfirmarSenhaIcon.Source = new Bitmap(assetLoader);
    
    }
    
    
    // metodo de navegação para o cadastro
    private void NavegarParaCadastro()
    {
        _navegarPaginas?.NavegarPara(new SignUp()); // navega para a tela de Cadastro
    }
    
}