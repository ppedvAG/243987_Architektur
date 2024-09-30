using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows.Input;

namespace ppedv.CrustControl.UI.Desktop.ViewModels
{
    class PizzaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Pizza> PizzaList { get; set; }

        private Pizza _selectedPizza;

        public Pizza SelectedPizza
        {
            get => _selectedPizza;
            set
            {
                _selectedPizza = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedPizza)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PizzaSpecialPrice)));
            }
        }

        public string PizzaSpecialPrice
        {
            get
            {
                if (SelectedPizza == null)
                    return "---";

                return (SelectedPizza.Price / 2).ToString("C");
            }
        }

        public ICommand SaveCommand { get; set; }

        private readonly IRepository repo;

        public PizzaViewModel(IRepository repo)
        {
            this.repo = repo;
            SaveCommand = new SaveCommand(repo);

            PizzaList = new ObservableCollection<Pizza>(repo.Query<Pizza>());
        }

        //pfusch bis DI Framework da ist
        static string conString = "Server=(localdb)\\mssqllocaldb;Database=CrustControl_TestDb;Trusted_Connection=true";

        public event PropertyChangedEventHandler? PropertyChanged;

        public PizzaViewModel() : this(new Data.Db.EfContextRepositoryAdapter(conString))
        { }
    }

    class SaveCommand : ICommand
    {
        private readonly IRepository repo;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            repo.SaveAll();
        }

        public SaveCommand(IRepository repo)
        {
            this.repo = repo;
        }
    }
}
