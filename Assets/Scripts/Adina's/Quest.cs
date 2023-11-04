using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Quest : ScriptableObject
{
    [System.Serializable]
    public struct Info
    {
        public string name;
        public Sprite icon;
        public string description;
    }

    [Header("Info")] public Info Information;
    
    public bool Completed { get; protected set; }
    public QuestCompletedEvent QuestCompleted;

    public abstract class QuestGoal : ScriptableObject
    {
        protected string description;
        public int CurrentAmount { get; protected set; }
        public int RequiredAmount = 1;

        public bool Completed { get; protected set; }
        [HideInInspector] public UnityEvent GoalCompleted;

        public virtual string GetDescription()
        {
            return description;
        }

        public virtual void Initialize()
        {
            Completed = false;
            GoalCompleted = new UnityEvent();
        }

        protected void Evaluate()
        {
            if (CurrentAmount >= RequiredAmount)
            {
                Complete();
            }
        }

        private void Complete()
        {
            Completed = true;
            GoalCompleted.Invoke();
            GoalCompleted.RemoveAllListeners();
        }
    }

    public List <QuestGoal> Goals;

    public void Initialize()
    {
        Completed = false;
        QuestCompleted = new QuestCompletedEvent();

        foreach (var goal in Goals)
        {
            goal.Initialize();
            goal.GoalCompleted.AddListener(delegate { CheckGoals(); });
        }
    }

    private void CheckGoals()
    {
        Completed = Goals.TrueForAll(g => g.Completed);
        if(Completed)
        {
            QuestCompleted.Invoke(this);
            QuestCompleted.RemoveAllListeners();
        }
    }
}

public class QuestCompletedEvent : UnityEvent<Quest> { }
/*
#if UNITY_EDITOR
[CustomEditor(typeof(Quest))]
public class QuestEditor : AssemblyIsEditorAssembly
{
    SerializedProperty m_QuestInfoProperty;
    SerializedProperty m_QuestStatProperty;

    List<string> m_QuestGoalType;
    Serializedproperty m_QuestGoalListProperty;
}

#endif*/