using DailyPlanner;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
namespace WpfApp5
{
    public class NoteEditViewModel : BaseViewModel
    {
        private Note note;

        public Note Note
        {
            get => note;
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public NoteEditViewModel(Note note)
        {
            Note = note;
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Save()
        {
            
            (App.Current.MainWindow as NoteEditWindow).DialogResult = true;
        }

        private void Cancel()
        {
            
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            currentWindow?.Close();
        }
    }
}
