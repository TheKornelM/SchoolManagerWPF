using System.Diagnostics;
using System.Windows.Input;

namespace SchoolManagerViewModel.Commands;

public class AddSubjectCommand : ICommand
{
    public event EventHandler? CanExecuteChanged;
    private AddSubjectViewModel _addSubjectViewModel;

    public bool CanExecute(object? parameter)
    {
        return _addSubjectViewModel.SelectedClass != null && _addSubjectViewModel.SelectedTeacher != null;
    }

    public void Execute(object? parameter)
    {
        Debug.WriteLine("ok");
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public AddSubjectCommand(AddSubjectViewModel addSubjectViewModel)
    {
        _addSubjectViewModel = addSubjectViewModel;
    }
}
