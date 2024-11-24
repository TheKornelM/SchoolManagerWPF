﻿using SchoolManagerModel.Entities;
using SchoolManagerModel.Entities.UserModel;
using SchoolManagerViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class MarkViewModel : ViewModelBase
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Grade { get; set; }
    public required Student Student { get; set; }
    public required Subject Subject { get; set; }

    public required DateTime SubmitDate { get; set; }
    public string Notes { get; set; } = string.Empty;

}