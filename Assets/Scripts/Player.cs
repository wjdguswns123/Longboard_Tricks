using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator            playerAnimator;
    CharacterController playerController;

    bool                isStart = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnimator.SetTrigger("StartRiding");
            isStart = true;
        }

        if(isStart)
        {
            Vector3 moveValue = transform.forward * 0.01f;
            moveValue.y = 0f;
            playerController.Move(moveValue);
        }
    }
}
