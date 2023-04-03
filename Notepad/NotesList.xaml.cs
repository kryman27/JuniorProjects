using Notepad.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for NotesList.xaml
    /// </summary>
    public partial class NotesList : Window
    {
        public NotesList()
        {
            InitializeComponent();
        }

        private void btnCloseList_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //dgNotesList
            using (var ctxNotes = new NotesContext())
            {
                List<Note> notes = new List<Note>();
                notes.AddRange(ctxNotes.Notes.Select(n => n).OrderBy(n => n.Id));
                
                dgNotesList.ItemsSource = notes;
            }
        }
    }
}
