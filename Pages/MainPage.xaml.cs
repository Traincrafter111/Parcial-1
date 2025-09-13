using AppointmentSimulator.Models;
using System.Threading.Tasks;

namespace AppointmentSimulator.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AppointmentsCollectionView.ItemsSource = GlobalData.Appointments;
        }

        private async void OnAddNewAppointmentClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewAppointmentPage());
        }

    }
}
