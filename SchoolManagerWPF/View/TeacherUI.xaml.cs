﻿using SchoolManagerModel.Entities.UserModel;
using System.Windows;

namespace SchoolManagerWPF.View
{
    /// <summary>
    /// Interaction logic for TeacherUI.xaml
    /// </summary>
    public partial class TeacherUI : Window
    {
        public TeacherUI(Teacher teacher)
        {
            InitializeComponent();
            MessageBox.Show(teacher.User.Username);

        }
    }
}
