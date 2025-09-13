
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppointmentSimulator.Models;

namespace AppointmentSimulator.ViewModels
{
    public partial class AppointmentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;
        [ObservableProperty]
        private string _subject = string.Empty;
        [ObservableProperty]
        private DateTime _appointmentDate = DateTime.Now;
        [ObservableProperty]
        private TimeSpan _startingTime = TimeSpan.Zero;
        [ObservableProperty]
        private TimeSpan _endingTime = TimeSpan.Zero;

        [RelayCommand]
        public async Task AddNewAppointment()
        {
            if(string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Subject))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Rellene todos los campos.", "OK");
                return;
            }
            if(EndingTime <= StartingTime)
            {
                await App.Current.MainPage.DisplayAlert("Error", "La hora de finalización debe ser posterior a la hora de inicio.", "OK");
                return;
            }
            var newAppointment = new Appointment
            {
                Name = Name.Trim(),
                Subject = Subject.Trim(),
                AppointmentDate = DateOnly.FromDateTime(AppointmentDate),
                StartingTime = StartingTime,
                EndingTime = EndingTime
            };
            GlobalData.Appointments.Add(newAppointment);

            await Shell.Current.DisplayAlert("Éxito", "Cita agregada correctamente.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task CancelAppointment()
        {
            bool confirm = await App.Current.MainPage.DisplayAlert("Confirmar", "¿Seguro que desea cancelar?", "Si", "No");
            if (confirm)
            {
                await Shell.Current.GoToAsync("..");
            }

        }
    }
}
