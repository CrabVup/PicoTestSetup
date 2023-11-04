using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanGoal : Quest.QuestGoal
{
    public string Virus;

    public override string GetDescription()
    {
        return $"Scan a {Virus}";
    }

    public override void Initialize()
    {
        base.Initialize();
        EventManager.Instance.AddListener<BuildingGameEvent>(OnScanning);
    }

    private void OnScanning(BuildingGameEvent eventInfo)
    {
        if(eventInfo.BuildingName == Virus)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
