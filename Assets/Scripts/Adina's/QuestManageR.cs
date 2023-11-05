using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManageR : MonoBehaviour
{
    [SerializeField] private GameObject questPrefab;
    [SerializeField] private Transform questsContent;
    [SerializeField] private GameObject questHolder;

    public List<Quest> CurrentQuests;

    public void Awake()
    {
        foreach (var quest in CurrentQuests)
        {
            quest.Initialize();
            quest.QuestCompleted.AddListener(OnQuestCompleted);

            GameObject questObj = Instantiate(questPrefab, questsContent);
            questObj.transform.Find("Icon").GetComponent<Image>().sprite = quest.Information.Icon;

            questObj.GetComponent<Button>().onClick.AddListener(delegate
            {
                questHolder.GetComponent<QuestWindow>().OnServerInitialized(quest);
                questHolder.SetActive(true);
            });
        }
    }

    public void Build(string buildingName)
    {
        EventManager.Instance.QueueEvent(new BuildingGameEvent(buildingName));
    }

    private void OnQuestCompleted(Quest quest)
    {
        questsContent.GetChild(CurrentQuests.IndexOf(quest)).Find("Checkmark").gameObject.SetActive(true);
    }
}
