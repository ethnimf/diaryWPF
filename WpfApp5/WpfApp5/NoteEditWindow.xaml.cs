using DailyPlanner;
using System.Windows;

namespace WpfApp5
{
    public partial class NoteEditWindow : Window
    {
        public Note Note { get; set; }
        public NoteEditWindow(Note note)
        {
            InitializeComponent();
            Note = note;
            DataContext = new NoteEditViewModel(note);
        }
    }
}
