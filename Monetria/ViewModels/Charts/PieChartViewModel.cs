using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Linq;

namespace Monetria.ViewModels.Charts;

public class PieData(string name, double value)
{
    public string Name { get; set; } = name;
    public double[] Values { get; set; } = [value];
}

public class ViewModel
{
    // mantém seus dados
    public PieData[] Data { get; } =
    [
        new("Mary", 10),
        new("John", 20),
        new("Alice", 30),
        new("Bob", 40),
        new("Charlie", 50)
    ];

    public ISeries[] Series { get; }

    public ViewModel()
    {
        Series = Data
            .Select(d => new PieSeries<double>
            {
                Name = d.Name,
                Values = d.Values
            })
            .ToArray();
    }
}