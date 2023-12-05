using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private int moveSpeed;

    //Moves the background image to the left.
    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
