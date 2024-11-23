﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagerViewModel.EntityViewModels;
public class ClassViewModel : ViewModelBase, IDataErrorInfo
{
    private int _id;
    private string _name = string.Empty;
    private bool _isChanged = false;

    public string this[string columnName]
    {
        get
        {
            string error = string.Empty;

            switch (columnName)
            {
                case nameof(Name):
                    if (string.IsNullOrWhiteSpace(Name))
                        error = "First name cannot be empty.";
                    if (Name?.Length > 4)
                        error = "The name must be less than 50 characters.";
                    break;
            }

            return error;
        }
    }

    [Key]
    public int Id
    {
        get => _id;
        set
        {
            if (_id == value)
            {
                return;
            }

            _id = value;
            SetField(ref _id, value, nameof(Id));
            IsChanged = true;

        }
    }

    [Required]
    public string Name
    {
        get => _name;
        set
        {
            if (_name == value)
            {
                return;
            }

            _name = value;
            SetField(ref _name, value, nameof(Name));
            IsChanged = true;
        }
    }

    public bool IsChanged
    {
        get => _isChanged;
        set
        {
            if (_isChanged == value)
            {
                return;
            }

            _isChanged = value;
            SetField(ref _isChanged, value, nameof(IsChanged));

        }
    }

    public string Error { get; set; }
}