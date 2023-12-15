using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ManagerQuestions : MonoBehaviour
{
    public static ManagerQuestions sharedInstance;
    
    [SerializeField] private Question[] questions;
    
    //The questions is extracted from chat gpt
    [SerializeField] private string json;
    [SerializeField] private GameObject panelPrefab;
    [SerializeField] private Transform parentQuestions;

    [SerializeField] private int _points;
    
    private Question[] _randomQuestions;

    [SerializeField] private Text textPoints;

    [SerializeField] private GameObject questionsGameObject;

    [SerializeField] private Queue<GameObject> panelsQuestions = new Queue<GameObject>();

    [SerializeField] private GameObject results;
    [SerializeField] private Text resultTextPoints;
    
    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    
    [ContextMenu("init json")]
    private void InitJson()
    {
        QuestionContainer questionContainer = JsonUtility.FromJson<QuestionContainer>(json);
        questions = questionContainer.questions;
    }


    private void Start()
    {
        questionsGameObject.SetActive(false);
        results.SetActive(false);

    }

    public void StartNewGame()
    {
        _points = 0;
        
        questionsGameObject.SetActive(true);

        _randomQuestions = Get10RandomQuestions();

        for (int i = 0; i < _randomQuestions.Length; i++)
        {
            GameObject panelQuestion = Instantiate(panelPrefab, parentQuestions);
            panelQuestion.SetActive(false);
            panelQuestion.GetComponent<PannelQuestion>().question = _randomQuestions[i];
            panelsQuestions.Enqueue(panelQuestion);
            
        }

        panelsQuestions.Dequeue().SetActive(true);


    }

    public Question[] Get10RandomQuestions()
    {

        List<Question> random= new List<Question>();
        
        print(questions[questions.Length-1]);
        
        while (random.Count!=10)
        {
           int posQuestion= Random.Range(0, questions.Length -1);

           if (!random.Contains(questions[posQuestion]))
           {
               random.Add(questions[posQuestion]);
           }
           
        }

        return random.ToArray();
    }

    public void AddPoints(int pointsAdd)
    {
        _points += pointsAdd;
        textPoints.text = $"Points: {_points}";
    }

    public void NextPanelQuestions()
    {
        if (panelsQuestions.Count<=0)
        {
            FinishQuestions();
            return;
        }
        
        panelsQuestions.Dequeue().SetActive(true);
    }

    public void FinishQuestions()
    {
        questionsGameObject.SetActive(false);

        resultTextPoints.text = $"Points : {_points}";
        results.SetActive(true);
        print("finish");
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