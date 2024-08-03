using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    const string privateCode = "PtSv0wkB2UyxHiY0_K6ooALSXV1YZs9ESEdegy4EG0tA";  //Key to Upload New Info
    const string publicCode = "66adda7e8f40bb1108550d98";   //Key to download
    const string webURL = "http://dreamlo.com/lb/"; //  Website the keys are for

    public PlayerScore[] scoreList;
    DisplayHighscores myDisplay;

    static HighScores instance; //Required for STATIC usability
    void Awake()
    {
        instance = this; //Sets Static Instance
        myDisplay = GetComponent<DisplayHighscores>();
    }
    
    public static void UploadScore(string username, int score)  //CALLED when Uploading new Score to WEBSITE
    {//STATIC to call from other scripts easily
        instance.StartCoroutine(instance.DatabaseUpload(username,score)); //Calls Instance
    }

    IEnumerator DatabaseUpload(string userame, int score) //Called when sending new score to Website
    {
        // Refactoring
        using(UnityWebRequest request= UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(userame) + "/" + score)) {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.LogError(request.error);
            } else {
                print("Upload Successful");
                DownloadScores();
            }
        }
    }

    public void DownloadScores()
    {
        StartCoroutine("DatabaseDownload");
    }
    IEnumerator DatabaseDownload()
    {
        using(UnityWebRequest request= UnityWebRequest.Get(webURL + publicCode + "/pipe")) {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.LogError(request.error);
            } else {
                OrganizeInfo(request.downloadHandler.text);
                myDisplay.SetScoresToMenu(scoreList);
            }
        }

        // Refactoring
        using(UnityWebRequest request= UnityWebRequest.Get(webURL + publicCode + "/pipe-get/try2")) {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.ConnectionError) {
                Debug.LogError(request.error);
            } else {
                OrganizeInfo(request.downloadHandler.text);
            }
        }
    }

    void OrganizeInfo(string rawData) //Divides Scoreboard info by new lines
    {
        string[] entries = rawData.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        scoreList = new PlayerScore[entries.Length];
        for (int i = 0; i < entries.Length; i ++) //For each entry in the string array
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            scoreList[i] = new PlayerScore(username,score);
            print(scoreList[i].username + ": " + scoreList[i].score);
        }
    }
}

public struct PlayerScore //Creates place to store the variables for the name and score of each player
{
    public string username;
    public int score;

    public PlayerScore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}