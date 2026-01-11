using System;
using System.Windows.Input;
using FinTrack.Service;
using FinTrack.Views.Components;
using Avalonia.Threading;
using System.Text.RegularExpressions;

namespace FinTrack.ViewModels
{
    public class LoginCardViewModel : LoginCardBase
    {
        private readonly AutenticarServico _autenticarServico;
        private readonly NavegarPaginas _navegarPaginas;  // Adiciona o NavegarPaginas para navegação

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set { _senha = value; OnPropertyChanged(); }
        }

        private string _mensagemStatusLogin;
        public string MensagemStatusLogin
        {
            get => _mensagemStatusLogin;
            set { _mensagemStatusLogin = value; OnPropertyChanged(); }
        }

        private DispatcherTimer _tempoLogin;
        public ICommand LoginCommand { get; }
        public ICommand NavegarParaSignUp { get; }  // Comando para navegação para o SignUp

        public LoginCardViewModel(AutenticarServico autenticarServico, NavegarPaginas navegarPaginas)
        {
            _autenticarServico = autenticarServico;
            _navegarPaginas = navegarPaginas;  // Inicializa o NavegarPaginas

            LoginCommand = new Command(Login);
            NavegarParaSignUp = new Command(NavegarParaCadastro);  // Inicializa o comando de navegação
            _tempoLogin = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            _tempoLogin.Tick += (sender, args) =>
            {
                MensagemStatusLogin = "";
            };
        }

        private void Login()
        {
            const string EMAIL_TESTE = "marceline@gmail.com";
            const string SENHA_TESTE = "password123";

            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha))
            {
                MensagemStatusLogin = "Por favor insira o email e a senha corretamente."; 
                MensagemStatusCorLogin = "Red";
                IniciarTimerLogin();
                return;
            }

            // Verifica se o email é válido (não considerando o email teste)
            if (!EmailValido(Email) && !Email.Equals(EMAIL_TESTE, StringComparison.OrdinalIgnoreCase))
            {
                MensagemStatusLogin = "Por favor insira um email válido.";
                MensagemStatusCorLogin = "Red";
                IniciarTimerLogin();
                return;
            }

            // Verifica se é o email de teste e senha
            if (Email.Equals(EMAIL_TESTE, StringComparison.OrdinalIgnoreCase) && Senha == SENHA_TESTE)
            {
                MensagemStatusLogin = "Login sucedido!";
                MensagemStatusCorLogin = "Green";
                IniciarTimerLogin();
            }
            else if (EmailValido(Email) && Senha == SENHA_TESTE)
            {
                MensagemStatusLogin = "Login sucedido com email válido!";
                MensagemStatusCorLogin = "Green";
                IniciarTimerLogin();
            }
            else
            {
                MensagemStatusLogin = "Email ou senha inválidos.";
                MensagemStatusCorLogin = "Red";
                IniciarTimerLogin();
            }
        }

        // Método de navegação para a página de cadastro
        private void NavegarParaCadastro()
        {
            _navegarPaginas.NavegarPara(new SignUp());
        }

        private void IniciarTimerLogin()
        {
            _tempoLogin.Stop();
            _tempoLogin.Start();
        }

        private string _mensagemStatusCorLogin = "Red";

        public string MensagemStatusCorLogin
        {
            get { return _mensagemStatusCorLogin; }
            set { _mensagemStatusCorLogin = value; OnPropertyChanged(); }
        }

        // Método para validar se o email tem um formato válido
        private bool EmailValido(string email)
        {
            // Regex para verificar se o email tem formato válido
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
    }

    // ICommand simples
    public class Command : ICommand
    {
        private readonly Action _execute;
        public Command(Action execute) => _execute = execute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute();
    }
}
