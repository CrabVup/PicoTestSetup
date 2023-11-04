using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable] // work with it in the Inspector
public class Quests
{
    // INFO is passed in 
    public enum QuestProgress { ACCEPTED, AVAILABLE, COMPLETE, DONE }

    public TextMeshProUGUI title; // title for the quests
    public int id; // ID number for the quest
    public QuestProgress progress; // state of the current quest (enum)
    public string description; // string from the quest giver/ receiver
    public string congratulation; // string from the quest giver/ receiver
    public int nextQuest; // the next quest, if there is any

    public string questObjective; // name of the quest objective 
    public int questObjectiveCount; // current number of quests
    public int questObjectiveRequirment; // required amount of quest objectives
}
