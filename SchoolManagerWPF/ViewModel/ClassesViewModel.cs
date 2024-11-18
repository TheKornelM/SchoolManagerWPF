using AutoMapper;
using SchoolManagerModel.Entities;
using SchoolManagerModel.Managers;
using SchoolManagerModel.Persistence;
using SchoolManagerWPF.ViewModel.EntityViewModels;
using System.Collections.ObjectModel;

namespace SchoolManagerWPF.ViewModel
{
    internal class ClassesViewModel : ViewModelBase
    {
        #region Private fields
        private ObservableCollection<ClassViewModel> _classes = [];
        private Mapper _mapper;

        #endregion

        #region Public properties
        public ObservableCollection<ClassViewModel> Classes
        {
            get => _classes;
            set
            {
                SetField(ref _classes, value, nameof(Classes));
            }
        }

        #endregion

        #region Commands
        #endregion

        #region Constructor
        public ClassesViewModel()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Class, ClassViewModel>();
                cfg.CreateMap<ClassViewModel, Class>();
            });
            _mapper = new Mapper(mapperConfiguration);

            GetClassesAsync();
        }

        #endregion

        #region Private methods
        private async void GetClassesAsync()
        {
            var dbContext = new SchoolDbContext();
            var classDatabase = new ClassDatabase(dbContext);
            var classManager = new ClassManager(classDatabase);
            var result = await classManager.GetClassesAsync();

            var mapped = new ObservableCollection<ClassViewModel>();
            foreach (var item in result)
            {
                mapped.Add(_mapper.Map<Class, ClassViewModel>(item));
            }

            _classes = mapped;
            ResetChangedStatus();
        }

        private void ResetChangedStatus()
        {
            foreach (var item in _classes)
            {
                item.IsChanged = false;
            }
        }

        #endregion
    }
}
