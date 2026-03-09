using AppGreenRoots.Helpers;
using System.Windows.Input;

namespace AppGreenRoots.ViewModels;

public class TelaInicialViewModel : BaseViewModel
{
    private readonly ShellViewModel shell;

    public string NomeUsuario { get; set; } = "Usuário";

    public ICommand AbrirPassaporteCommand { get; }
    public ICommand LogoutCommand { get; }

    public TelaInicialViewModel(ShellViewModel shell)
    {
        this.shell = shell;

        AbrirPassaporteCommand = new RelayCommand(_ =>
        {
            shell.NavigatePassaporte();
        });

        LogoutCommand = new RelayCommand(_ =>
        {
            shell.NavigateLogin();
        });
    }
}