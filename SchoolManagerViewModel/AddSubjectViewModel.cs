﻿using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerViewModel.Commands;
using System.Collections.ObjectModel;

namespace SchoolManagerViewModel;

public class AddSubjectViewModel : ViewModelBase
{
    #region Private fields
    private Class? _selectedClass;
    private Teacher? _selectedTeacher;
    private ObservableCollection<Class> _classes = new();
    private ObservableCollection<Teacher> _teachers = new();

    #endregion

    #region Public properties
    public AddSubjectCommand AddSubjectCommand { get; private set; }

    public Class? SelectedClass
    {
        get => _selectedClass;
        set
        {
            if (_selectedClass == value)
            {
                return;
            }

            SetField(ref _selectedClass, value, nameof(SelectedClass));
        }
    }

    public Teacher? SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            if (_selectedTeacher == value)
            {
                return;
            }

            SetField(ref _selectedTeacher, value, nameof(SelectedTeacher));
        }
    }

    public ObservableCollection<Class> Classes
    {
        get => _classes;
        private set => SetField(ref _classes, value, nameof(Classes));
    }

    public ObservableCollection<Teacher> Teachers
    {
        get => _teachers;
        private set => SetField(ref _teachers, value, nameof(Teachers));
    }
    #endregion

    #region Constructors
    public AddSubjectViewModel()
    {
        AddSubjectCommand = new AddSubjectCommand(this);
    }
    #endregion

    #region Private methods
    #endregion

    #region Public methods
    public async Task LoadClasses()
    {
        using var dbContext = new SchoolDbContext();
        var classDatabase = new ClassDatabase(dbContext);
        var classManager = new ClassManager(classDatabase);

        SetField(ref _classes, new ObservableCollection<Class>(await classManager.GetClassesAsync()), nameof(Classes));

        if (_selectedClass == null)
        {
            SelectedClass = _classes.FirstOrDefault();
        }
    }

    public async Task LoadTeachers()
    {
        using var dbContext = new SchoolDbContext();
        var teacherDatabase = new TeacherDatabase(dbContext);
        var teacherManager = new TeacherManager(teacherDatabase);

        SetField(ref _teachers, new ObservableCollection<Teacher>(await teacherManager.GetTeacherUsersAsync()), nameof(Teachers));

        if (_selectedTeacher == null)
        {
            SelectedTeacher = _teachers.FirstOrDefault();
        }
    }

    #endregion
}
