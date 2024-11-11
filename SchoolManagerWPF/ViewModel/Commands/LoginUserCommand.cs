namespace SchoolManagerWPF.ViewModel.Commands;

internal class LoginUserCommand
{
    private LoginViewModel _viewModel;
    public event EventHandler? CanExecuteChanged;

    internal LoginUserCommand(LoginViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        if (CanExecuteChanged == null)
        {
            return;
        }


        /*if (_viewModel.SuccessfulLogin != null)
        {
            _viewModel.SuccessfulLogin();
        }*/
    }
}