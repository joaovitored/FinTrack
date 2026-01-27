using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System;
namespace Monetria.ViewModels.Charts;

public class DateTimeChartViewModel
{
    public ISeries[] Series { get; }
    public Axis[] XAxes { get; }

    public DateTimeChartViewModel()
    {
        Series =
        [
            new ColumnSeries<DateTimePoint>
            {
                Values =
                [
                    new(new DateTime(2026, 1, 1), 3),
                    new(new DateTime(2026, 1, 2), 6),
                    new(new DateTime(2026, 1, 3), 5),
                    new(new DateTime(2026, 1, 4), 3),
                    new(new DateTime(2026, 1, 5), 5),
                    new(new DateTime(2026, 1, 6), 8),
                    new(new DateTime(2026, 1, 7), 6)
                ]
            }
        ];

        XAxes =
        [
            new DateTimeAxis(
                TimeSpan.FromDays(1),
                date => date.ToString("MMMM dd"))
        ];
    }
}