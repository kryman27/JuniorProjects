using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        public string Text { get; set; }
        public string FilePath { get; set; }
        public Saving(string text)
        {
            InitializeComponent();
            Text = text;
        }

        private void Path_GotFocus(object sender, RoutedEventArgs e)
        {
            Path.Clear();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string noteText = Text;
            FilePath = Path.Text;

            File.WriteAllText(FilePath, noteText);

            Close();
        }

        private void btnChooseFir_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = "file";
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt) | *.txt";

            if(dialog.ShowDialog() == true)
            {
                //FilePath = dialog.FileName;
                Path.Text = dialog.FileName;
            }

            //bool? result = dialog.ShowDialog();
            //if (result == true)
            //{
            //    string filename = dialog.FileName;
            //    FilePath = filename;
            //}
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}
