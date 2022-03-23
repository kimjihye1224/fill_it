using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueButton : MonoBehaviour
{
    public GameObject machine;
    private Animator animator;
    public float moveSpeed = 1.0f;

    public bool isClick = false;
    public static bool cBtn = false;
    public GameObject cottonMachine; //heejo
    /*public AudioClip cottonS;*/
    public AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        animator = machine.GetComponent<Animator>();
        aud = machine.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = moveSpeed;

        if (isClick)
        {
/*            print("Å¬¸¯Áß");*/
        }
    }


    public void PointerDown()
    {
        cBtn = true;
        isClick = true;
        MoveConveyor.move = false;
        cottonMachine.GetComponent<ParticleSystem>().Play(); //HJ
        animator.SetBool("IsUp", false);
        animator.SetBool("IsDown", true);
        animator.SetBool("IsDown", false);
        animator.SetBool("IsPushing", true);
        aud.Play();
    }

    public void PointerUp()
    {
        isClick = false;
        MoveConveyor.move = true;
        animator.SetBool("IsPushing", false);
        animator.SetBool("IsUp", true);
        cottonMachine.GetComponent<ParticleSystem>().Stop(); //HJ
        aud.Stop();
    }
}
