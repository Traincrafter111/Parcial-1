namespace AppointmentSimulator.Pages;
using AppointmentSimulator.ViewModels;

public partial class AddNewAppointmentPage : ContentPage
{
	private readonly AppointmentViewModel _viewModel = new AppointmentViewModel();
    public AddNewAppointmentPage()
	{
		InitializeComponent();
		_viewModel = new AppointmentViewModel();
		BindingContext = _viewModel;
    }
}