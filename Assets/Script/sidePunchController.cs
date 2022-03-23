using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidePunchController : MonoBehaviour
{
    public static bool punchLock = false;
    public GameObject punchFX; //HJ
    Rigidbody rb; //HJ
    float force = 35f; //HJ
/*    public AudioClip punchS;
    public AudioSource aud;*/


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); //HJ
       /* this.aud = GetComponent<AudioSource>();*/

    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        //rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        //rb.AddForce(Vector3.up * force, ForceMode.Impulse);

        if (punchLock)
        {
            /*rb.AddForce(Vector3.left * force, ForceMode.Impulse);*/
            //this.aud.PlayOneShot(this.punchS);
        }
        /*  rb.AddForce(Vector3.right * power);*/

    }


    private void OnCollisionEnter(Collision other)
    {
        if (punchLock)
        {
            if (other.gameObject.CompareTag("bear") || other.gameObject.CompareTag("bug"))
            {
/*                print("ÆÝÄ¡¶û ºÎµúÇûÀ½");*/
    /*            print(other.gameObject.name);*/
                punchFX.GetComponent<ParticleSystem>().Play(); //HJ
                
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (this.gameObject.CompareTag("bear") || this.gameObject.CompareTag("bug"))
        {
            punchFX.GetComponent<ParticleSystem>().Stop(); //HJ
        }
    }
}
