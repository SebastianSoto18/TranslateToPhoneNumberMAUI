namespace aplicacionPrueba;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	
	string translatedNumber;

	private void OnTranslate(object sender, EventArgs e)
	{
		string enteredNumber = PhoneNumberText.Text;
		translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

		if (!string.IsNullOrEmpty(translatedNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = "Llamar " + translatedNumber;
		}
		else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Llamar";
		}
	}

	async void OnCall(object sender, EventArgs e)
	{
		if(await this.DisplayAlert("Dail a Number", "Would you like to call "+ translatedNumber + " ?", "Yes", "No"))
		{
			try
			{
				if (PhoneDialer.Default.IsSupported) 
				{ 
					PhoneDialer.Default.Open(translatedNumber);
				}
			}
			catch(ArgumentNullException ex)
			{
				await DisplayAlert("Error", "No se pudo llamar, numero invalido", "OK");
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", "No se pudo llamar", "OK");
			}
		}
	}

}

