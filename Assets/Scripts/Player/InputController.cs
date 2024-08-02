using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerMovement movementController;
    private bool doJump = false;
    private bool jumping = false;
    private bool endJump = false;

    void Start()
    {
        movementController = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Keyboard Inputs
        if (Input.GetButtonDown("Jump"))
        {
            doJump = true;
        }

        if (Input.GetButton("Jump"))
        {
            jumping = true;
        }

        if (Input.GetButtonUp("Jump"))
        {
            endJump = true;
        }

        // Touch Screen Inputs
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                doJump = true;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                jumping = true;
            }

            if (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                endJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (movementController != null)
        {
            movementController.Move(doJump, jumping, endJump);
            
            doJump = false;
            jumping = false;
            endJump = false;
        }

    }
}
