using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchCont : MonoBehaviour
{
    //ÆÝÄ¡ ¹öÆ° ´­·ÈÀ» ¶§

    public static bool punchBt = false;
    public bool bclick = false;
    public GameObject punchMachine;
    private Animator animator;
    public float punchSpeed = 1.0f;
    public AudioClip punchS;
    public AudioSource aud;
    Rigidbody rb;
    private float force = 70f;
    // Start is called before the first frame update
    void Start()
    {
        animator = punchMachine.GetComponent<Animator>();
        this.aud = punchMachine.GetComponent<AudioSource>();
        rb = punchMachine.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = punchSpeed;
    }

    public void PointEnter()
    {

        animator.SetBool("IsPunching", true);
        rb.AddForce(Vector3.left * force, ForceMode.Impulse);
        sidePunchController.punchLock = true;
        this.aud.PlayOneShot(this.punchS);


    }

    public void PointExit()
    {
        animator.SetBool("IsPunching", false);
        rb.velocity = Vector3.zero;
        sidePunchController.punchLock = false;
    }


}
