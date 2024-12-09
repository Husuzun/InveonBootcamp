using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class DataProcessor
{
    private static readonly HttpClient httpClient = new();

    public string ProcessDataSynchronously()
    {
        Console.WriteLine("Starting synchronous data processing...");
        var response = httpClient.GetStringAsync("https://www.example.com").Result;

        return response;
    }

    public async Task<object> ProcessDataAsynchronously()
    {
        Console.WriteLine("Starting asynchronous data processing...");
        return await httpClient.GetStringAsync("https://www.example.com");
    }

    public async Task<string> FetchDataWithErrorHandlingAsync(string url)
    {
        try
        {
            Console.WriteLine($"Fetching data from {url}...");
            var response = await httpClient.GetStringAsync(url);
            Console.WriteLine("Data fetched successfully.");
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            return "Error fetching data.";
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
            return "Unexpected error occurred.";
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        var processor = new DataProcessor();

        // Test synchronous method
        var stopwatch = Stopwatch.StartNew();
        var response = processor.ProcessDataSynchronously();
        Console.WriteLine("Data processed synchronously. Length of data: " + response.Length);
        stopwatch.Stop();
        Console.WriteLine($"Synchronous processing took: {stopwatch.ElapsedMilliseconds} ms");

        // Test asynchronous method
        stopwatch.Restart();
        var response2 = await processor.ProcessDataAsynchronously();
        Console.WriteLine("Data processed asynchronously. Length of data: " + response2.ToString().Length);
        stopwatch.Stop();
        Console.WriteLine($"Asynchronous processing took: {stopwatch.ElapsedMilliseconds} ms");

        // Task.Run example
        await Task.Run(() => {
            Console.WriteLine("Running a CPU-bound operation in the background.");
        });

        // Task.Delay example
        await Task.Delay(2000);
        Console.WriteLine("Waited for 2 seconds.");

        // Task.WhenAll example
        var task1 = Task.Delay(1000);
        var task2 = Task.Delay(2000);
        stopwatch.Restart();
        await Task.WhenAll(task1, task2);
        stopwatch.Stop();
        Console.WriteLine($"Both tasks completed in: {stopwatch.ElapsedMilliseconds} ms");

        // Task.WhenAny example
        var task3 = Task.Delay(1000);
        var task4 = Task.Delay(2000);
        stopwatch.Restart();
        await Task.WhenAny(task3, task4);
        stopwatch.Stop();
        Console.WriteLine($"One of the tasks completed in: {stopwatch.ElapsedMilliseconds} ms");

        // Task.CompletedTask example
        Task completedTask = Task.CompletedTask;
        Console.WriteLine("CompletedTask is already completed.");

        // Task.FromResult example
        Task<int> fromResultTask = Task.FromResult(42);
        Console.WriteLine($"FromResult task completed with result: {fromResultTask.Result}");

        // Task.FromException example
        Task<int> fromExceptionTask = Task.FromException<int>(new InvalidOperationException("An error occurred"));
        try
        {
            int result = fromExceptionTask.Result;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"FromException task threw an exception: {ex.InnerException.Message}");
        }

        // Task.FromCanceled example
        var cts = new CancellationTokenSource();
        cts.Cancel();
        Task<int> fromCanceledTask = Task.FromCanceled<int>(cts.Token);
        try
        {
            int result = fromCanceledTask.Result;
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"FromCanceled task was canceled: {ex.InnerException.Message}");
        }

        // Task.Factory.StartNew example
        Task factoryTask = Task.Factory.StartNew(() => {
            Console.WriteLine("Task started with Task.Factory.StartNew");
        });
        await factoryTask;

        // Task.ContinueWith example
        Task<int> initialTask = Task.Run(() => {
            Console.WriteLine("Running initial task...");
            Task.Delay(2000).Wait();
            return 42;
        });

        Task continuation = initialTask.ContinueWith(t => {
            Console.WriteLine($"Continuation task running. Result from initial task: {t.Result}");
        });

        await continuation;

        Console.WriteLine("\nTesting FetchDataWithErrorHandlingAsync with a valid URL:");
        string validResponse = await processor.FetchDataWithErrorHandlingAsync("https://www.example.com");
        Console.WriteLine($"Response length: {validResponse.Length}");

        Console.WriteLine("\nTesting FetchDataWithErrorHandlingAsync with an invalid URL:");
        string invalidResponse = await processor.FetchDataWithErrorHandlingAsync("http://www.googleddddd.com");
        Console.WriteLine($"Response: {invalidResponse}");
    }
}