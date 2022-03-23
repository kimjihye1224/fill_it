using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    public AudioSource aud;
    public AudioClip clickS;

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound()
    {
        this.aud.PlayOneShot(this.clickS);
    }
}
