Problemstilling:

Du får en liste med samtaledata (CDRs - Call Detail Records). Hver post inneholder følgende felter:
- Caller: Telefonnummeret som initierer samtalen.
- Reciever: Telefonnummeret som mottar samtalen.
- StartTime: Starttidspunktet for samtalen (ISO 8601-format).
- Duration: Varigheten av samtalen i sekunder.

Du må prosessere disse postene og svare på følgende:
1. Identifiser de 3 mest aktive ringerne (basert på antall samtaler).
2. Totale varigheten av samtaler gjort til det nummeret som har hatt flest samtaler ut.
3. Beregn det totale antallet unike telefonnumre som er involvert i datasettet.

//Eksempel data cdrs.json
[
    { "Caller": "12345678", "Receiver": "09876543", "StartTime": "2024-11-27T10:00:00Z", "Duration": 120 },
    { "Caller": "12345678", "Receiver": "11223344", "StartTime": "2024-11-27T10:05:00Z", "Duration": 60 },
    { "Caller": "09876543", "Receiver": "12345678", "StartTime": "2024-11-27T10:10:00Z", "Duration": 180 },
    { "Caller": "11223344", "Receiver": "12345678", "StartTime": "2024-11-27T10:20:00Z", "Duration": 30 },
    { "Caller": "12345678", "Receiver": "44556677", "StartTime": "2024-11-27T10:30:00Z", "Duration": 90 }
]

Dette skal resultere i:

Top 3 Most Active Callers:
12345678: 3 calls
09876543: 1 calls
11223344: 1 calls
Total Duration of Calls to 12345678: 210 seconds
Total Unique Phone Numbers: 4

Vi ønsker at du legger løsningen opp på github som er kjørbart med en eksempelfil. Det er ønskelig at du sender oss linken senest dagen før intervjuet.

Ta med laptap for å kunne kjøre en demo av løsningen.
