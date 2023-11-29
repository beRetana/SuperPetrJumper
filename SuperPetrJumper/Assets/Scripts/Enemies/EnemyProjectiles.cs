using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float gravity, speed, upForce;
    private bool started;
    private Vector3 distance;

    private void Update()
    {
        if (!started)
        {
            distance = Vector2.up * upForce;
            started = true;
        }
        distance.x += speed * Time.deltaTime;
        distance.y += gravity * Time.deltaTime;
        transform.position += distance * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.gameObject;

        if (target.CompareTag("Petr"))
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            target.GetComponent<PetrManager>().Dead();
        }
    }
}
