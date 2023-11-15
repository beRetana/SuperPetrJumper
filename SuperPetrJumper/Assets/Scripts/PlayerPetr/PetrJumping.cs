using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PetrJumping : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private float jumpForce;
    private PetrControllers playerControls;
    private int doubleJump;

    private void Awake()
    {
        //Initialize and enable the input system for Player.
        playerControls = new PetrControllers();
        playerControls.Petr.Enable();
        playerControls.Petr.Jump.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //Jump only twice increase by one the times Player jumps.
        if (context.performed && doubleJump < 2)
        {
            rbPlayer.AddForce(Vector2.up * jumpForce);
            doubleJump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If Player touches the ground then it resets the number of jumps.
        if (collision.gameObject.CompareTag("Ground"))
        {
            doubleJump = 0;
        }
    }
}
