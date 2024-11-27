﻿using SchoolManagerModel.DTOs;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using System.Collections.ObjectModel;

namespace SchoolManagerViewModel;
public class FilterUsersViewModel : ViewModelBase
{
    #region Private fields
    private ObservableCollection<UserDto> _users = [];
    private string _usernameFilter = string.Empty;
    private string _firstNameFilter = string.Empty;
    private string _lastNameFilter = string.Empty;
    private string _emailFilter = string.Empty;
    #endregion

    #region Public properties
    public ObservableCollection<UserDto> Users
    {
        get => _users;
        set => SetField(ref _users, value, nameof(Users));
    }

    public string UsernameFilter
    {
        get => _usernameFilter;
        set => SetField(ref _usernameFilter, value, nameof(UsernameFilter));
    }

    public string FirstNameFilter
    {
        get => _firstNameFilter;
        set => SetField(ref _firstNameFilter, value, nameof(FirstNameFilter));
    }

    public string LastNameFilter
    {
        get => _lastNameFilter;
        set => SetField(ref _lastNameFilter, value, nameof(LastNameFilter));
    }

    public string EmailFilter
    {
        get => _emailFilter;
        set => SetField(ref _emailFilter, value, nameof(EmailFilter));
    }

    #endregion

    public async Task LoadAllUser()
    {
        using var dbContext = new SchoolDbContext();
        var userDatabase = new UserDatabase(dbContext);
        var userManager = new UserManager(userDatabase);

        var users = await userManager.GetUsersAsync();
        SetField(ref _users, new ObservableCollection<UserDto>(users), nameof(Users));
    }
}