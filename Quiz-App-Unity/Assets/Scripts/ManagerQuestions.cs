using UnityEngine;

public class ManagerQuestions : MonoBehaviour
{
    [SerializeField] private Question[] questions;
    
    //The questions is extracted from chat gpt
    [SerializeField] private string json;
    
    [ContextMenu("init json")]
    private void InitJson()
    {
        QuestionContainer questionContainer = JsonUtility.FromJson<QuestionContainer>(json);
        questions = questionContainer.questions;
    }
    
    
    
    
}

[System.Serializable]
public class QuestionContainer
{
    public Question[] questions;
}

[System.Serializable]
public class Question
{
    public string Statement;
    public string[] Options;
    public int CorrectOption;
}