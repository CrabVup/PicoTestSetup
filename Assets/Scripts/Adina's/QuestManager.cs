using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // MANAGEMENT script, fill in all the data
    public static QuestManager questManager;

    public List <Quests> questList = new List <Quests>(); // Master Quest List
    public List <Quests> currentQuestList = new List <Quests>(); // Current Quest List, when we have quests accepted/ completed

    // private vars for our QuestObject

    private void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }
        else if (questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // ACCEPT QUEST
    public void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            currentQuestList.Add(questList[i]);
            questList[i].progress = Quests.QuestProgress.ACCEPTED;
        }
    }

    // GIVE UP 
    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quests.QuestProgress.ACCEPTED)
            {
                questList[i].progress = Quests.QuestProgress.AVAILABLE;
                currentQuestList[i].questObjectiveCount = 0;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

    // COMPLETE QUEST
    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < currentQuestList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progress == Quests.QuestProgress.COMPLETE)
            {
                currentQuestList[i].progress = Quests.QuestProgress.DONE;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }

    // BOOLS
    public bool RequestAcceptedQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quests.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }
        return false;
    }

    public bool RequestCompleteQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quests.QuestProgress.COMPLETE)
            {
                return true;
            }
        }
        return false;
    }
}
