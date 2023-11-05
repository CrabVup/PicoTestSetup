using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestWindow : MonoBehaviour
{
    // fields for all the elements
    [SerializeField] private TextMeshPro titleText;
    [SerializeField] private TextMeshPro descriptionText;
    [SerializeField] private GameObject goalPrefab;
    [SerializeField] private Transform goalContent;

    public void OnServerInitialized(Quest quest)
    {
        titleText.text = quest.Information.Name;
        descriptionText.text = quest.Information.Description;

        foreach (var goal in quest.Goals)
        {
            GameObject goalObj = Instantiate(goalPrefab, goalContent);
            goalObj.transform.Find("Text").GetComponent<Text>().text = goal.GetDescription();

            GameObject countObj = goalObj.transform.Find("Count").gameObject;
            
            if (goal.Completed)
            {
                countObj.SetActive(false);
                goalObj.transform.Find("Done").gameObject.SetActive(true);
            } else
            {
                countObj.GetComponent<Text>().text = goal.CurrentAmount + "/" + goal.RequiredAmount;
            }
        }
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);

        for (int i = 0; i < goalContent.childCount; i++)
        {
            Destroy(goalContent.GetChild(i).gameObject);
        }
    }
}
