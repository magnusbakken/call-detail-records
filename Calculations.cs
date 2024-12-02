using System.Text.Json;

namespace CallDetailRecords;

public static class Calculations
{
    public static async Task RunCalculations(string fileName)
    {
        using var reader = new StreamReader(fileName);
        var records = await JsonSerializer.DeserializeAsync<IList<CallDetailRecord>>(reader.BaseStream);
        if (records is null)
        {
            Console.Error.WriteLine("Failed to deserialize input.");
            return;
        }

        CalculateTopThreeCallers(records);
        CalculateTopReceiverDuration(records);
        CalculateUniqueNumberCount(records);
    }

    private static void CalculateTopThreeCallers(IList<CallDetailRecord> records)
    {
        var groupedByCaller = records
            .GroupBy(r => r.Caller)
            .Select(g => new { Caller = g.Key, Count = g.Count() })
            .OrderByDescending(r => r.Count)
            .Take(3)
            .ToList();

        Console.WriteLine("Top 3 Most Active Callers:");
        foreach (var caller in groupedByCaller)
        {
            Console.WriteLine($"{caller.Caller}: {caller.Count} calls");
        }
    }

    private static void CalculateTopReceiverDuration(IList<CallDetailRecord> records)
    {
        // In the example we know the input list isn't empty, so we know there will be a non-null answer here.
        var topReceiver = records
            .GroupBy(r => r.Receiver)
            .Select(g => new { Receiver = g.Key, TotalDuration = g.Sum(r => r.Duration) })
            .MaxBy(r => r.TotalDuration)!;

        Console.WriteLine($"Total Duration of Calls to {topReceiver.Receiver}: {topReceiver.TotalDuration} seconds");
    }

    private static void CalculateUniqueNumberCount(IList<CallDetailRecord> records)
    {
        var uniqueNumbers = new HashSet<string>();
        foreach (var record in records)
        {
            uniqueNumbers.Add(record.Caller);
            uniqueNumbers.Add(record.Receiver);
        }

        Console.WriteLine($"Total Unique Phone Numbers: {uniqueNumbers.Count}");
    }
}