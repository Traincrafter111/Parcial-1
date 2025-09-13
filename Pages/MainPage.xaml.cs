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

        private async void OnDeleteSelectedAppointmentClicked(object sender, EventArgs e)
        {
            var selectedAppointment = AppointmentsCollectionView.SelectedItem as AppointmentSimulator.Models.Appointment;
            if (selectedAppointment != null)
            {
                bool confirm = await DisplayAlert("Confirmar", "¿Seguro que desea eliminar la cita seleccionada?", "Sí", "No");
                if (confirm)
                {
                    GlobalData.Appointments.Remove(selectedAppointment);
                    AppointmentsCollectionView.SelectedItem = null;
                }
            }
        }
    }
}
