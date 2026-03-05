using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AppGreenRoots.Commands;

namespace AppGreenRoots.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private string _email    = string.Empty;
    private string _senha    = string.Empty;
    private string _nome     = string.Empty;
    private string _mensagem = string.Empty;
    private bool   _isCadastro;

    public string Email    { get => _email;    set { _email    = value; OnPropertyChanged(); } }
    public string Senha    { get => _senha;    set { _senha    = value; OnPropertyChanged(); } }
    public string Nome     { get => _nome;     set { _nome     = value; OnPropertyChanged(); } }
    public string Mensagem { get => _mensagem; set { _mensagem = value; OnPropertyChanged(); } }

    public bool IsCadastro
    {
        get => _isCadastro;
        set { _isCadastro = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsLogin)); Mensagem = ""; }
    }
    public bool IsLogin => !_isCadastro;

    public ICommand LoginCommand        { get; }
    public ICommand CadastrarCommand    { get; }
    public ICommand AlternarModoCommand { get; }

    public LoginViewModel()
    {
        LoginCommand        = new RelayCommand(_ => ExecutarLogin());
        CadastrarCommand    = new RelayCommand(_ => ExecutarCadastro());
        AlternarModoCommand = new RelayCommand(_ => IsCadastro = !IsCadastro);
    }

    private void ExecutarLogin()
    {
        // TODO: ligar ao banco depois
        Mensagem = "Login ainda não implementado.";
    }

    private void ExecutarCadastro()
    {
        // TODO: ligar ao banco depois
        Mensagem = "Cadastro ainda não implementado.";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}