using Newtonsoft.Json;
using Notepad.Model;
using System;
using System.Net.Http;
using System.Windows;

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
					CreatedOn = DateTime.Now,
				});
				ctxNotes.SaveChanges();
				var resOfAdd = true;

				if (resOfAdd == true)
				{
					MessageBox.Show("Note stored to DB sucesfully");
				}
				else if (resOfAdd == false)
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

		private async void Temperature_Loaded(object sender, RoutedEventArgs e)
		{
			//string jsonWeatherData = String.Empty;

			using (HttpClient client = new HttpClient())
			{

				string weatherApiUrl = "https://api.open-meteo.com/v1/forecast?latitude=51.25&longitude=22.57&hourly=temperature_2m&forecast_days=1";


				try
				{
					HttpResponseMessage response = await client.GetAsync(weatherApiUrl);
					string rawWeatherData = await response.Content.ReadAsStringAsync();

					WeatherData finalData = JsonConvert.DeserializeObject<WeatherData>(rawWeatherData);

					Temperature.Text = finalData.hourly.temperature_2m[0].ToString() + "°C";
				}
				catch (Exception ex)
				{
					Temperature.Text = ex.Message;
				}
			}


		}
	}
}
