using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    public List <Quests> questList = new List <Quests>();
    public List <Quests> currentQuestList = new List <Quests>(); // Curent Quest List

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
