using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;
    public AudioSource aud;
    public AudioClip clickS;
    public void Start()
    {
        this.aud = GetComponent<AudioSource>();

    }
    public void Load()//씬 이동시키는 코드
    {
        this.aud.PlayOneShot(this.clickS);



        SceneManager.LoadScene(sceneName);
    }
}