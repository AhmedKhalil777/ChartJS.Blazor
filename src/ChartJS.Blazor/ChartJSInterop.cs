using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace ChartJS.Blazor
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    public class ChartJSInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public ChartJSInterop(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/ChartJS.Blazor/chartJSBlazor.js").AsTask());
        }

        public async ValueTask CreateChart(string id, ChartConfig configs)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("createChart", id, configs);
        }

        public async ValueTask DisposeAsync()
        {
            if (_moduleTask.IsValueCreated)
            {
                var module = await _moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
