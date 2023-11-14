using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private float jumpForce;
    private PetrControllers playerControls;
    private int doubleJump;

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
        //If input received and double jumped 
        if (context.performed && doubleJump < 2)
        {
            rbPlayer.AddForce(Vector2.up * jumpForce);
            doubleJump++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If Player touches the ground then it allows for double jump.
        if (collision.gameObject.CompareTag("Ground"))
        {
            doubleJump = 0;
        }
    }
}
