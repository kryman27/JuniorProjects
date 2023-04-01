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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for Saving.xaml
    /// </summary>
    public partial class Saving : Window
    {
        public string Text { get; set; }
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
            string filePath = Path.Text;

            File.WriteAllText(filePath, noteText);

            Close();
        }
    }
}
