using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private float jumpForce;
    private PetrControllers playerControls;

    private void Awake()
    {
        playerControls = new PetrControllers();
        playerControls.Petr.Enable();
        playerControls.Petr.Jump.performed += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            rbPlayer.AddForce(Vector2.up * jumpForce);
        }
    }
}
