using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private PlayerMovement movementController;
    private bool doJump = false;

    void Start()
    {
        movementController = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            doJump = true;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                doJump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (movementController != null)
        {
            movementController.Move(doJump);
            doJump = false;
        }

    }
}
