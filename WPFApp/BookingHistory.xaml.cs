using BusinessObjects;
using DataAccessLayer.DTO;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interface;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for BookingHistory.xaml
    /// </summary>
    public partial class BookingHistory : UserControl
    {
        private readonly IBookingHistoryService _service;
        public Customer Customer;
        public BookingHistory()
        {
            InitializeComponent();
            _service = ((App)Application.Current).ServiceProvider.GetRequiredService<IBookingHistoryService>() ?? throw new ArgumentNullException(nameof(BookingHistoryService));
            Loaded += LoadData;
        }

        private async void LoadData(object sender, RoutedEventArgs e)
        {
            List<BookingHistoryDTO> bookingDetails = await _service.GetBookingByCusId(Customer.CustomerId);

            dgBookingHistory.ItemsSource = bookingDetails;
        }
    }
}
