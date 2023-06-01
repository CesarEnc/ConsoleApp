try
{
    Console.WriteLine("Start App");
    CancellationTokenSource cancellationToken = new();
    Console.CancelKeyPress += (_, e) =>
    {
        e.Cancel = true; // prevent the process from terminating.
        cancellationToken.Cancel();
    };
}
catch (IOException e)
{
    TextWriter errorWriter = Console.Error;
    errorWriter.WriteLine($"Error: {e.Message}");
    return;
}