using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests
{
    public enum QuestProgress { COMPLETE, DONE }

    public string title; // title for the quests
    public int id; // ID number for the quest
    public QuestProgress progress; // state of the current quest (enum)
    public string description; // string from the quest
    public int nextQuest; // the next quest, if there is any

    public string questObjective; // name of the quest objective 
    public int questObjectiveCount; // current number of quests

}
