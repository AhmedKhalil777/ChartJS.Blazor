namespace ChartJS.Blazor
{
    public class ChartConfig
    {
        public string Type { get; set; } = ChartJSTypes.Bar;
        public ChartData Data { get; set; }
        public ChartOptions Options { get; set; }

    }
}
