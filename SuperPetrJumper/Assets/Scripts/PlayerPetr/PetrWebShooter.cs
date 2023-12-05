using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PetrWebShooter : MonoBehaviour
{
    private PetrControllers playerControls;
    [SerializeField] private PetrManager petrManager;
    [SerializeField] private float spiderwebSpawn, webDuration;
    [SerializeField] private GameObject spiderWebs;

    //Initialize and enable the input system for Player to shoot.
    private void Awake()
    {
        playerControls = new PetrControllers();
        playerControls.Petr.Enable();
        playerControls.Petr.ShootWebs.performed += ShootWebs;
    }

    private void ShootWebs(InputAction.CallbackContext context)
    {
        /*Only initializes a SpiderWeb projectile when the
        player has the spiderman power-up and its not dead.*/
        if (petrManager.SpiderPowerUp && !petrManager.Death)
        {
            Vector3 distance = Vector3.right * spiderwebSpawn;
            GameObject web = Instantiate(spiderWebs, (transform.position + distance), Quaternion.identity);
            Destroy(web, webDuration);
        }
    }
}
