using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PannelQuestion : MonoBehaviour
{
    [SerializeField] public Question question;
    [SerializeField] private Text statement;
    [SerializeField] private Text[] optionsTexts;
    [SerializeField] private Button[] optionsButtons;
    [SerializeField] private int selectedOption;

    [SerializeField] private float timer = 10;
    [SerializeField] private Text timerText ;
    
    // Start is called before the first frame update
    void Start()
    {
        InitPanel();
    }

    private void Update()
    {
        if(timer <= -1){return;}
        
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("0");
        }
        else
        {
            selectedOption = -1;
            StartCoroutine(WaitForNextPanelQuestion());
        }

    }


    void InitPanel()
    {
        statement.text = question.Statement;
        
        for (int i = 0; i < question.Options.Length; i++)
        {
            optionsTexts[i].text = question.Options[i];
        }
    }

    public void SelectOption(int option)
    {
        selectedOption = option;
        
        if (option == question.CorrectOption)
        {
            WinThisQuestion();
        }
        else
        {
            FailThisQuestion();
        }

        StartCoroutine(WaitForNextPanelQuestion());

    }

    IEnumerator WaitForNextPanelQuestion()
    {
        timer = -1;
        if (selectedOption >= 0)
        {
            optionsButtons[selectedOption].GetComponent<Image>().color=Color.red;
        }
        optionsButtons[question.CorrectOption].GetComponent<Image>().color= Color.green;
        
        foreach (var button in optionsButtons)
        {
            button.enabled = false;
        }    
        
        
        
        timerText.text = "3";
        yield return new WaitForSeconds(1);
        timerText.text = "2";
        yield return new WaitForSeconds(1);
        timerText.text = "1";
        yield return new WaitForSeconds(1);

        ManagerQuestions.sharedInstance.NextPanelQuestions();
        Destroy(gameObject);


    }
    

    public void WinThisQuestion()
    {
        print("win");

        ManagerQuestions.sharedInstance.AddPoints((int)timer);
    }

    public void FailThisQuestion()
    {
        print("loose");
    }
    
    
}
