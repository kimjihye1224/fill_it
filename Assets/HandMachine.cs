using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMachine : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = moveSpeed;

        if (Input.GetMouseButtonDown(1))
        {
            print("ÆÝÄ¡");
            animator.SetBool("IsPunching", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("IsPunching", false);
        }
    }
}
