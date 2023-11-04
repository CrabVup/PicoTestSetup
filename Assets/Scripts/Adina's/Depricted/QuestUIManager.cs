using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIManager : MonoBehaviour
{
    public static QuestUIManager uiManager;

    // BOOLS 
    public bool questAvailable = true;
    public bool questRunning = false;
    private bool questPanelActive = false;
    private bool questLogPanelActive = false;

    // PANELS 
    public GameObject questPanel;
    public GameObject questLogPanel;

    // QUESTOBJECT
    private QuestObject currentQuestObject;

    // QUESTLISTS
    public List <Quests> availableQuests = new List <Quests>();
    public List <Quests> activeQuests = new List <Quests>();

    // BUTTONS
    public GameObject qButton; // quests
    public GameObject qLogButton; // which quests are running/ are available 
    private List<GameObject> qButtons = new List <GameObject>();

    private GameObject acceptButton;
    private GameObject giveUpButton;

    // SPACER 
    public Transform qButtonSpacer1; // spacer for qButton available
    public Transform qButtonSpacer2; // running qButton
    public Transform qLogButtonSpacer; // running in qLog

    // Quests INFOS
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;

    // Quests LOG INFOS
    public TextMeshProUGUI questLogTitle;
    public TextMeshProUGUI questLogDescription;

    private void Awake()
    {
        if (uiManager == null)
        {
            uiManager = this;
        } else if (uiManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        HideQuestPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questLogPanelActive = !questLogPanelActive;
            //showQuestLogPanel
        }
    }

    // ACTIVE QUESTS

    // ACCEPT QUESTS

    // SHOW PANEL 
    public void ShowQuestPanel()
    {
        questPanelActive = true;
        questPanel.SetActive(questPanelActive);
        // FILL IN DATA
        FillQuestButtons();
    }

    // quest Log

    // HIDE QUEST PANEL
    public void HideQuestPanel()
    {
        questPanelActive = false;
        questAvailable = false;
        questRunning = false;

        // CLEAR TEXT
        questTitle.text = "";
        questDescription.text = "";

        // CLEAR LISTS
        availableQuests.Clear();
        activeQuests.Clear();

        // CLEAR BUTTON LIST
        for (int i = 0; i < qButtons.Count; i++)
        {
            Destroy(qButtons[i]);
        }
        qButtons.Clear();

        // HIDE PANEL
        questPanel.SetActive(questPanelActive);
    }

    // FILL BUTTONS FOR QUEST PANEL
    void FillQuestButtons()
    {
        foreach (Quests availableQuest in availableQuests)
        {
            GameObject questButton = Instantiate(qButton); // the quests data inside
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = availableQuest.id;
            qBScript.questTitle = availableQuest.title;

            questButton.transform.SetParent(qButtonSpacer1, false);
            qButtons.Add(questButton);
        }

        foreach (Quests activeQuest in activeQuests)
        {
            GameObject questButton = Instantiate(qButton); // the quests data inside
            QButtonScript qBScript = questButton.GetComponent<QButtonScript>();

            qBScript.questID = activeQuest.id;
            qBScript.questTitle = activeQuest.title;

            questButton.transform.SetParent(qButtonSpacer2, false);
            qButtons.Add(questButton);
        }
    }
}
