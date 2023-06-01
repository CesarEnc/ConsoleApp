try
{
    Console.WriteLine("Start App");
    CancellationTokenSource cancellationToken = new();
    Console.CancelKeyPress += (_, e) =>
    {
        Console.WriteLine("Canceling...");
        e.Cancel = true;
        cancellationToken.Cancel();
    };

    //Do Somthing ...

    Console.WriteLine("End App");
}
catch (IOException e)
{
    Console.Error.WriteLine($"Error-{(int)Errors.InternalError}");
    Console.Error.WriteLine($"Detail: {e.Message}");
    return;
}

enum Errors
{
    InternalError,
    InvalidArgument,
    UnaveilableApi
}