using Monetria.ViewModels.Charts;

namespace Monetria.ViewModels;

public class DashboardPageViewModel : ViewModelBase
{
    public ViewModel PieData { get; } = new();
    public DateTimeChartViewModel DateTimeChart { get; } = new();
    
}