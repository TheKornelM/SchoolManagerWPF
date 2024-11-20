using System.Diagnostics;
using System.Windows.Input;

namespace SchoolManagerWPF.ViewModel.Commands;

public class SelectAllSubjectsCommand : ICommand
{
    AddUserViewModel _viewModel;
    public SelectAllSubjectsCommand(AddUserViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    public event EventHandler? CanExecuteChanged;

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

        Debug.WriteLine("Checked boxes before command: " + _viewModel.Subjects.Count(x => x.IsChecked));

        bool isAllChecked = _viewModel.Subjects.All(x => x.IsChecked);
        _viewModel.AllSubjectsSelected = !isAllChecked;
        foreach (var item in _viewModel.Subjects)
        {
            item.IsChecked = !isAllChecked;
        }

        Debug.WriteLine("Checked boxes after command: " + _viewModel.Subjects.Count(x => x.IsChecked));


    }
}
