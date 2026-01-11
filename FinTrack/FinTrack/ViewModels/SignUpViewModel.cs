using FinTrack.Models;
using FinTrack.Service;
using Avalonia.Threading;
using System;
using System.Threading.Tasks;  // Alterado para usar Task
using System.Windows.Input;
using FinTrack.Views.Components;

namespace FinTrack.ViewModels
{
    public class SignUpViewModel : SignUpCardBase
    {
        private readonly CadastrarServico _cadastrarServico;
        private readonly NavegarPaginas _navegarPaginas;

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }

        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { _senha = value; OnPropertyChanged(); }
        }

        private string _confirmarSenha;
        public string ConfirmarSenha
        {
            get { return _confirmarSenha; }
            set { _confirmarSenha = value; OnPropertyChanged(); }
        }

        private string _mensagemStatusCadastro;
        public string MensagemStatusCadastro
        {
            get { return _mensagemStatusCadastro; }
            set { _mensagemStatusCadastro = value; OnPropertyChanged(); }
        }

        private string _mensagemStatusCor = "Red";
        public string MensagemStatusCor
        {
            get { return _mensagemStatusCor; }
            set { _mensagemStatusCor = value; OnPropertyChanged(); }
        }

        private bool _senhaVisivel;
        public bool SenhaVisivel
        {
            get => _senhaVisivel;
            set { _senhaVisivel = value; OnPropertyChanged(); }
        }

        private DispatcherTimer _tempoCadastro;

        // Comando para navegar para o Login
        public ICommand NavegarParaLogin { get; }

        // Comando para realizar o cadastro
        public ICommand CadastroCommand { get; }

        public SignUpViewModel(CadastrarServico cadastrarServico, NavegarPaginas navegarPaginas)
        {
            _cadastrarServico = cadastrarServico;
            _navegarPaginas = navegarPaginas;

            // Inicializar o comando para navegação para o Login
            NavegarParaLogin = new Command(NavegarParaLoginTela);

            // Inicializar o comando para realizar o cadastro de forma assíncrona
            CadastroCommand = new Command(async () => await CadastroAsync());  // Torne a execução assíncrona

            // Inicializar o timer para mensagens de status
            _tempoCadastro = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            _tempoCadastro.Tick += (sender, args) => MensagemStatusCadastro = "";
        }

        private bool PodeExecutarCadastro()
        {
            return !string.IsNullOrWhiteSpace(Nome) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   !string.IsNullOrWhiteSpace(Senha) &&
                   !string.IsNullOrWhiteSpace(ConfirmarSenha) &&
                   Senha == ConfirmarSenha;
        }

        private async Task CadastroAsync()  // Torne o método assíncrono
        {
            if (!PodeExecutarCadastro())
            {
                MensagemStatusCadastro = "Preencha todos os campos corretamente.";
                MensagemStatusCor = "Red";
                IniciarTimerCadastro();
                return;
            }

            if (Senha != ConfirmarSenha)
            {
                MensagemStatusCadastro = "Senhas diferentes.";
                MensagemStatusCor = "Red";
                IniciarTimerCadastro();
                return;
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                MensagemStatusCadastro = "O email não pode estar vazio.";
                MensagemStatusCor = "Red";
                IniciarTimerCadastro();
                return;
            }

            if (!EmailValido(Email))
            {
                MensagemStatusCadastro = "Insira um email válido.";
                MensagemStatusCor = "Red";
                IniciarTimerCadastro();
                return;
            }

            var usuario = new Usuario
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha
            };

            bool cadastroEfetivado = await _cadastrarServico.CadastroAsync(usuario);  // Agora é assíncrono

            if (cadastroEfetivado)
            {
                MensagemStatusCadastro = "Cadastro realizado com sucesso!";
                MensagemStatusCor = "Green";
                IniciarTimerCadastro();
                _navegarPaginas.NavegarPara(new LoginCard(_navegarPaginas)); // Navegação para Login
            }
            else
            {
                MensagemStatusCadastro = "Erro ao cadastrar, revise suas credenciais.";
                MensagemStatusCor = "Red";
                IniciarTimerCadastro();
            }
        }

        private bool EmailValido(string email)
        {
            var dominiosValidos = new[] { "@gmail.com", "@hotmail.com", "@outlook.com", "@yahoo.com", "@empresa.com" };
            foreach (var dominio in dominiosValidos)
            {
                if (email.EndsWith(dominio, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void NavegarParaLoginTela()
        {
            _navegarPaginas.NavegarPara(new LoginCard(_navegarPaginas));  // Navega para a tela de Login
        }

        private void IniciarTimerCadastro()
        {
            _tempoCadastro.Start();
        }

        // Comando simples
        public class Command : ICommand
        {
            private readonly Action _execute;
            public Command(Action execute) => _execute = execute;

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) => true;

            public void Execute(object parameter) => _execute();
        }
    }
}
