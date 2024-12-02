namespace CallDetailRecords;

public sealed record CallDetailRecord(string Caller, string Receiver, DateTimeOffset StartTime, int Duration);