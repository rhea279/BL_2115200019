using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string jsonInputPath = "BeforeCensorShip.json";
        string csvInputPath = "BeforeCensorShip.csv";
        string jsonOutputPath = "ipl_censored.json";
        string csvOutputPath = "ipl_censored.csv";

        // Process JSON
        List<MatchData> matches = ReadJson(jsonInputPath);
        ApplyCensorship(matches);
        WriteJson(jsonOutputPath, matches);

        // Process CSV
        List<MatchData> matchesCsv = ReadCsv(csvInputPath);
        ApplyCensorship(matchesCsv);
        WriteCsv(csvOutputPath, matchesCsv);

        Console.WriteLine("Censorship Applied. Processed files saved.");
    }

    static List<MatchData> ReadJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<MatchData>>(jsonString);
    }

    static void WriteJson(string filePath, List<MatchData> matches)
    {
        string jsonOutput = JsonConvert.SerializeObject(matches, Formatting.Indented);
        File.WriteAllText(filePath, jsonOutput);
    }

    static List<MatchData> ReadCsv(string filePath)
    {
        var matches = new List<MatchData>();
        string[] lines = File.ReadAllLines(filePath);
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            matches.Add(new MatchData
            {
                MatchId = int.Parse(values[0]),
                Team1 = values[1],
                Team2 = values[2],
                Score = new Dictionary<string, int>
                {
                    { values[1], int.Parse(values[3]) },
                    { values[2], int.Parse(values[4]) }
                },
                Winner = values[5],
                PlayerOfMatch = values[6]
            });
        }
        return matches;
    }

    static void WriteCsv(string filePath, List<MatchData> matches)
    {
        var lines = new List<string> { "match_id,team1,team2,score_team1,score_team2,winner,player_of_match" };
        foreach (var match in matches)
        {
            lines.Add($"{match.MatchId},{match.Team1},{match.Team2},{match.Score[match.Team1]},{match.Score[match.Team2]},{match.Winner},REDACTED");
        }
        File.WriteAllLines(filePath, lines);
    }

    static void ApplyCensorship(List<MatchData> matches)
    {
        foreach (var match in matches)
        {
            match.Team1 = MaskTeamName(match.Team1);
            match.Team2 = MaskTeamName(match.Team2);
            match.Winner = MaskTeamName(match.Winner);
            match.PlayerOfMatch = "REDACTED";
            match.Score = match.Score.ToDictionary(kvp => MaskTeamName(kvp.Key), kvp => kvp.Value);
        }
    }

    static string MaskTeamName(string teamName)
    {
        string[] words = teamName.Split(' ');
        if (words.Length > 1)
        {
            words[1] = "***";
            return string.Join(" ", words);
        }
        return teamName;
    }
}

class MatchData
{
    public int MatchId { get; set; }
    public string Team1 { get; set; }
    public string Team2 { get; set; }
    public Dictionary<string, int> Score { get; set; }
    public string Winner { get; set; }
    public string PlayerOfMatch { get; set; }
}
