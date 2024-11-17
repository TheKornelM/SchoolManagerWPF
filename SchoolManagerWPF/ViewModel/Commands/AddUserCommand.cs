﻿using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerModel.Utils;
using SchoolManagerModel.Validators;
using System.Diagnostics;
using System.Windows.Input;

namespace SchoolManagerWPF.ViewModel.Commands;

internal class AddUserCommand : ICommand

{
    private AddUserViewModel _addUserViewModel;
    public event EventHandler? CanExecuteChanged;

    public AddUserCommand(AddUserViewModel viewModel)
    {
        _addUserViewModel = viewModel;
    }

    public bool CanExecute(object? parameter)
    {
        var userValidator = new UserValidator(UIResourceFactory.GetNewResource()).Validate(CreateUserFromViewModel());
        Debug.WriteLine(ValidationErrors.GetErrorsFormatted(userValidator));

        var role = _addUserViewModel.SelectedRole;
        bool studentHasClass = role != Role.Student || (role == Role.Student && _addUserViewModel.Class != null);

        return userValidator.IsValid && studentHasClass;
    }

    public async void Execute(object? parameter)
    {
        if (CanExecuteChanged == null)
        {
            return;
        }

        try
        {
            using var dbContext = new SchoolDbContext();
            var userDatabase = new UserDatabase(dbContext);
            var userManager = new UserManager(userDatabase);

            var user = CreateUserFromViewModel();

            await userManager.RegisterUserAsync(user);
            await userManager.AssignRoleAsync(user, _addUserViewModel.SelectedRole);

            switch (_addUserViewModel.SelectedRole)
            {
                case Role.Student:
                    await userManager.AddStudentAsync(new Student() { User = user, Class = _addUserViewModel.Class });
                    break;
                case Role.Teacher:
                    await userManager.AddTeacherAsync(new Teacher() { User = user });
                    break;
                case Role.Administrator:
                    await userManager.AddAdminAsync(new Admin() { User = user });
                    break;
            }
        }
        catch (Exception ex)
        {
            _addUserViewModel.FailedUserAdd?.Invoke();
        }


        _addUserViewModel.SuccessfulUserAdd?.Invoke();
    }

    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    private User CreateUserFromViewModel()
    {
        return new User()
        {
            Username = _addUserViewModel.Username,
            FirstName = _addUserViewModel.FirstName,
            LastName = _addUserViewModel.LastName,
            Password = _addUserViewModel.Password,
            Email = _addUserViewModel.Email,
        };
    }
}