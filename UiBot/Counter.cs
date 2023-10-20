using System;
using System.IO;
using Newtonsoft.Json;

public class Counter
{
    public int AllDeath { get; set; }
    public int SurvivalCount { get; set; }
    public int AllKillCount { get; set; }

    private readonly string jsonFilePath;


    public Counter()
    {
        jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "counter.json");
        AllDeath = GetAllDeathFromJson();
        SurvivalCount = GetSurvivalCountFromJson();
        AllKillCount = GetKillCountFromJson();
    }

    public void IncrementAllDeath()
    {
        AllDeath++;
        SaveCountsToJson();
    }

    public void IncrementSurvivalCount()
    {
        SurvivalCount++;
        SaveCountsToJson();
    }

    public void IncrementKillCount()
    {
        AllKillCount++;
        SaveCountsToJson();
    }

    public void ResetAllDeath()
    {
        AllDeath = 0;
        SaveCountsToJson();
    }

    public void ResetSurvivalCount()
    {
        SurvivalCount = 0;
        SaveCountsToJson();
    }
    public void ResetKillCount()
    {
        AllKillCount = 0;
        SaveCountsToJson();
    }

    private int GetAllDeathFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<CounterData>(json)?.AllDeath ?? 0;
        }
        return 0;
    }

    private int GetSurvivalCountFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<CounterData>(json)?.SurvivalCount ?? 0;
        }
        return 0;
    }
    private int GetKillCountFromJson()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<CounterData>(json)?.AllKillCount ?? 0;
        }
        return 0;
    }

    private void SaveCountsToJson()
    {
        var counterData = new CounterData
        {
            AllDeath = AllDeath,
            SurvivalCount = SurvivalCount,
            AllKillCount = AllKillCount
        };
        string json = JsonConvert.SerializeObject(counterData);
        File.WriteAllText(jsonFilePath, json);
    }

    private class CounterData
    {
        public int AllDeath { get; set; }
        public int SurvivalCount { get; set; }
        public int AllKillCount {  get; set; }
    }

}