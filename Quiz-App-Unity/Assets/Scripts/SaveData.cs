using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    /*[SerializeField]*/ private List<string> topPoints= new List<string>();

    [SerializeField] private GameObject punctuationsObject;
    [SerializeField] private Text textPunctuations;

    private void Start()
    {
        LoadTheList();
    }

    public void AddPunctuation(string punctuation)
    {
        topPoints.Add(punctuation);
        topPoints.Sort();
        topPoints.Reverse();
    }

    public void SeeBestPunctuations()
    {
        List<string> listaDeStrings = new List<string>();

        
        topPoints.Sort((a, b) =>
        {
            int numberA = GetNumber(a);
            int numberB = GetNumber(b);

            
            return numberB.CompareTo(numberA);
        });
        


        punctuationsObject.SetActive(true);
        textPunctuations.text = "";

        if (topPoints.Count==0)
        {
            textPunctuations.text = "sin puntuaciones";
            return;

        }
        
        for (int i = 0; i < topPoints.Count; i++)
        {
            if (i >= 10)
            {
                return;
            }
            textPunctuations.text += $"{topPoints[i]} \n";
        }
    }

    private int GetNumber(string punctuationComplete)
    {
        string[] divided = punctuationComplete.Split(':');
        if (divided.Length > 1)
        {
            int numberResult;
            if (int.TryParse(divided[0], out numberResult))
            {
                return numberResult;
            }
        }

        return 0;
    }
    
    public void SaveTheList()
    {
        topPoints.Sort();
        topPoints.Reverse();

        for (int i = 0; i < topPoints.Count; i++)
        {
            if (i >= 10)
            {
                return;
            }
            PlayerPrefs.SetString(i.ToString(),topPoints[i]);
        }
    }

    public void LoadTheList()
    {
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.GetString(i.ToString()).Length>0)
            {
                topPoints.Add(PlayerPrefs.GetString(i.ToString()));

            }
        }
    }
    
    
    
    
}