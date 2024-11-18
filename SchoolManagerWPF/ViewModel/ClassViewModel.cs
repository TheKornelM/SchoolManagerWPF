using System.ComponentModel.DataAnnotations;

namespace SchoolManagerWPF.ViewModel;
public class ClassViewModel : ViewModelBase
{
    private int _id;
    private string _name = string.Empty;

    [Key]
    public int Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                SetField(ref _id, value, nameof(Id));
            }
        }
    }

    [Required]
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                SetField(ref _name, value, nameof(Name));
            }
        }
    }

}