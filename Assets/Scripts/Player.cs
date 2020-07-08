using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator            playerAnimator;
    CharacterController playerController;

    bool                isStart = false;
    Vector3             speed = Vector3.zero;
    public Vector3 Speed { get { return speed; } set { speed = value; } }

    // Start is called before the first frame update
    void Start()
    {
        if(playerAnimator == null)
        {
            playerAnimator = GetComponent<Animator>();
        }

        if(playerController == null)
        {
            playerController = GetComponent<CharacterController>();
        }

        speed = transform.forward * 0.08f;
        speed.y = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnimator.SetTrigger("StartRiding");
            isStart = true;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            playerAnimator.SetTrigger("DoPivot");
        }

        //if (isStart)
        //{
        //    Vector3 moveValue = transform.forward * 0.01f;
        //    moveValue.y = 0f;
        //    playerController.Move(moveValue);
        //}
    }

    private void FixedUpdate()
    {
        if (isStart)
        {
            //Vector3 moveValue = transform.forward * 0.08f;
            //moveValue.y = 0f;
            playerController.Move(speed);
        }
    }
}
