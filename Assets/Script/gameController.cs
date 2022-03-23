using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameController : MonoBehaviour
{
    //[SerializeField]
    //string sceneName;
    //옮김. TextMeshPro로 바꿔야 하지 않나....
    public Text scoreText;
    public Text highScoreText;
    public Text newRecordText;
    public static int score = 0;
    public int savedScore = 0;
    public GameObject jackpot;
    private int pastScr;
    public AudioClip newRecS;
    public AudioClip jackpotS;
    public AudioSource aud;
    public GameObject dontDestroy;


    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private int heartCount = 0;
    //public static bool gmoverStatus = false;
    private string KeyString = "HighScore";
    
    // Start is called before the first frame update
    void Start()
    {
        //옮김
        savedScore = PlayerPrefs.GetInt(KeyString);
        PlayerPrefs.Save();
        highScoreText.text = savedScore.ToString();
        pastScr = score;
        this.aud = GetComponent<AudioSource>();
        this.dontDestroy = GameObject.Find("dontDestroy");
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //savedScore = PlayerPrefs.GetInt(KeyString);
        //PlayerPrefs.Save();
        highScoreText.text = savedScore.ToString();
        scoreText.text = score.ToString();

        if (score > savedScore)
        {
            aud.pitch = 1;
            newRecordText.text = "new record";
            savedScore = score;
            PlayerPrefs.SetInt(KeyString, score);
            PlayerPrefs.Save();
            highScoreText.text = savedScore.ToString();
            this.aud.PlayOneShot(this.newRecS);
            //new record 한번만 보여주기 위해
            //newRecordText.gameObject.SetActive(false);
        }
        if (score < savedScore)
        {
            newRecordText.text = "";
        }

        if ((score % 100) == 0 && score != 0)
        {
            if (pastScr < score)
            {
                aud.pitch = 10;
                jackpot.GetComponent<ParticleSystem>().Play();
                pastScr = score;
                this.aud.PlayOneShot(this.jackpotS);

            }
        }
        if ((score % 100) != 0)
        {
            if (jackpot.GetComponent<ParticleSystem>().isPlaying == true)
            {
                jackpot.GetComponent<ParticleSystem>().Stop();
                pastScr = score;
            }
        }

        if (doll.heart)
        {
            if (heartCount == 0)
            {
                heart1.SetActive(false);
            }else if(heartCount == 1)
            {
                heart2.SetActive(false);
            }
            else
            {
                heart3.SetActive(false);
                dontDestroy.GetComponent<myScore>().storeScore(score);
                SceneManager.LoadScene("GameOver");
                
            }

            heartCount++;
            doll.heart = false;
        }



    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt(KeyString, 0);
        PlayerPrefs.Save();
    }
}
