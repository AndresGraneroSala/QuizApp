using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class SaveData : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SendData());
    }

    IEnumerator SendData()
    {
        string url = "https://tu-app.vercel.app/api/saveData";
        string jsonData = "{ \"data\": \"tus_datos_a_guardar\" }";

        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, jsonData))
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log("Datos guardados correctamente");
            }
        }
    }
}