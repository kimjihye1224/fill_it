using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text highScoreText;
    int savedScore = 0;

    private string KeyString = "HighScore";

    // Start is called before the first frame update
    void Start()
    {
        savedScore = PlayerPrefs.GetInt(KeyString);
        //PlayerPrefs.Save();
        highScoreText.text = savedScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(KeyString, 0);
        savedScore = PlayerPrefs.GetInt(KeyString);
        highScoreText.text = savedScore.ToString();
        //PlayerPrefs.Save();
    }
}
