using System.Windows;
using System.Windows.Controls;
using AppGreenRoots.ViewModels;

namespace AppGreenRoots.Views;

public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void PbSenha_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm)
            vm.Senha = ((PasswordBox)sender).Password;
    }

    protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }

    private void BtnFechar_Click(object sender, RoutedEventArgs e) => Close();
}