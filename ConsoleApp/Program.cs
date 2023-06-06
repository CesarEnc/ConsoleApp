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
    List<Drink> list = GetDrinks();
    System.Text.StringBuilder csv = new System.Text.StringBuilder();
    csv.AppendLine("header");
    foreach (Drink element in list)
    {
        csv.AppendLine("elemnt");
    }
    File.WriteAllText(@"C:\Temp\csc.txt", csv.ToString());

    Console.WriteLine("End App");
}
catch (IOException e)
{
    Console.Error.WriteLine($"Error-{(int)Errors.InternalError}");
    Console.Error.WriteLine($"Detail: {e.Message}");
    return;
}

List<Drink> GetDrinks()
{
    return new List<Drink>();
}

enum Errors
{
    InternalError,
    InvalidArgument,
    UnaveilableApi
}

class Drink
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Descripcion { get; set; }
}
