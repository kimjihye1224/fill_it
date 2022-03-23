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
    public void Load()//�� �̵���Ű�� �ڵ�
    {
        this.aud.PlayOneShot(this.clickS);



        SceneManager.LoadScene(sceneName);
    }
}