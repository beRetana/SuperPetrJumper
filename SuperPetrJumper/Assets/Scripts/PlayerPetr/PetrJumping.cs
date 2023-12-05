using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PetrJumping : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private float jumpForce;
    private PetrControllers playerControls;
    [SerializeField] private PetrManager petrManager;
    private int doubleJump;
    [SerializeField] private Animator petrAnimations;

    //Initialize and enable the input system for Player.
    private void Awake()
    {
        playerControls = new PetrControllers();
        playerControls.Petr.Enable();
        playerControls.Petr.Jump.performed += Jump;
    }

    //Gets called when the user inputs data though the input system created.
    private void Jump(InputAction.CallbackContext context)
    {
        //Jump only twice increase by one the times Player jumps.
        if (context.performed && doubleJump < 2 && !petrManager.Death)
        {
            petrAnimations.SetBool("Jumping", true);
            rbPlayer.AddForce(Vector2.up * jumpForce);
            MusicManager.Music.PlaySFX("Jump");
            doubleJump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If Player touches the ground then it resets the number of jumps.
        if (collision.gameObject.CompareTag("Ground"))
        {
            doubleJump = 0;
            petrAnimations.SetBool("Jumping", false);
        }
    }
}
