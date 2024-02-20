using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfApp5;

namespace DailyPlanner
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DateTime selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                if (selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged();
                    LoadNotesForSelectedDate();
                }
            }
        }

        private ObservableCollection<Note> notes = new ObservableCollection<Note>();
        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set
            {
                if (notes != value)
                {
                    notes = value;
                    OnPropertyChanged();
                }
            }
        }

        private Note selectedNote;
        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                if (selectedNote != value)
                {
                    selectedNote = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddNoteCommand { get; }
        public ICommand EditNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            AddNoteCommand = new RelayCommand(AddNote);
            EditNoteCommand = new RelayCommand(EditNote, CanEditOrDeleteNote);
            DeleteNoteCommand = new RelayCommand(DeleteNote, CanEditOrDeleteNote);

            LoadNotesForSelectedDate();
        }

        private void LoadNotesForSelectedDate()
        {
            try
            {
                string filePath = GetFilePathForSelectedDate();

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);


                    if (!string.IsNullOrEmpty(json))
                    {
                        Notes = JsonConvert.DeserializeObject<ObservableCollection<Note>>(json);
                    }
                    else
                    {
                        Notes = new ObservableCollection<Note>();
                    }
                }
                else
                {
                    Notes = new ObservableCollection<Note>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load notes: {ex.Message}");
            }
        }


        private void AddNote()
        {
            Note newNote = new Note
            {
                Title = "New Note",
                Description = "Description",
                Date = SelectedDate
            };

            Notes.Add(newNote);
            SaveNotesToFile();
        }

        private void EditNote()
        {
            if (SelectedNote != null)
            {
                NoteEditWindow editWindow = new NoteEditWindow(SelectedNote);
                if (editWindow.ShowDialog() == true)
                {
                    int index = Notes.IndexOf(SelectedNote);
                    Notes[index] = editWindow.Note; 
                    SaveNotesToFile(); 
                }
            }
        }




        private void DeleteNote()
        {
            if (SelectedNote != null)
            {
                Notes.Remove(SelectedNote);
                SaveNotesToFile();
            }
        }

        private void SaveNotesToFile()
        {
            try
            {
                string filePath = GetFilePathForSelectedDate();
                string json = JsonConvert.SerializeObject(Notes);
                File.WriteAllText(filePath, json);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save notes: {ex.Message}");
            }
        }

        private string GetFilePathForSelectedDate()
        {
         
            string directoryPath = "NotesDirectory"; 
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string fileName = $"Notes_{SelectedDate.ToString("yyyyMMdd")}.json"; 
            return Path.Combine(directoryPath, fileName);
        }

        private bool CanEditOrDeleteNote()
        {
            return SelectedNote != null;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }

    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
