﻿using Notepad.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string text = NoteText.Text;
            Saving formB = new Saving(text);
            formB.Show();
        }

        private void NoteText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NoteText.Text == "Enter your thoughts here...")
            {
                NoteText.Clear();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            NoteText.Clear();
        }

        private void btnSaveToDatabase_Click(object sender, RoutedEventArgs e)
        {
            using (var ctxNotes = new NotesContext())
            {
                ctxNotes.Notes.Add(new Model.Note
                {
                    Note1 = NoteText.Text,
                    CreatedOn= DateTime.Now,
                });
                ctxNotes.SaveChanges();
                var resOfAdd = true;
                
                if(resOfAdd == true)
                {
                    MessageBox.Show("Note stored to DB sucesfully");
                }
                else if(resOfAdd == false)
                {
                    MessageBox.Show("Somethin wrong happened! Note was not stored!");
                }
                NoteText.Clear();
            }

        }

        private void ShowNotes_Click(object sender, RoutedEventArgs e)
        {
            NotesList listOfNotes = new NotesList();
            listOfNotes.Show();
        }
    }
}
