using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CottonMachine : MonoBehaviour
{
    //Transform tr;
    private Animator animator;
    public float moveSpeed = 1.0f;

    public enum MachineState { idle, down, pushing, up };
    public MachineState machineState = MachineState.idle;

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform>();
        animator = this.gameObject.GetComponent<Animator>();

        StartCoroutine(this.CheckMachineState());
        StartCoroutine(this.MachineAction());
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = moveSpeed;

        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Button on");
            animator.SetBool("IsUp", false);
            animator.SetBool("IsDown", true);
            animator.SetBool("IsDown", false);
            animator.SetBool("IsPushing", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Button up");
            animator.SetBool("IsPushing", false);
            animator.SetBool("IsUp", true);
            //animator.SetBool("IsDown", false);
        }
    }

    public void ClickOnBlue()
    { 
    }

    IEnumerator CheckMachineState()
    {
        yield return new WaitForSeconds(0.1f);

        //if (r == 1) machineState = MachineState.Rolling;
        //else machineState = MachineState.idle;
    }

    IEnumerator MachineAction()
    {

        switch (machineState)
            {
                case MachineState.idle:
                    animator.SetBool("IsRolling", false);
                    break;
                case MachineState.down:
                    animator.SetBool("IsRolling", true);
                    break;
            }
            yield return null;
    }

    private void OnMouseDown()
    {
        
    }
}
