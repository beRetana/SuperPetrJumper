using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationMenu : MonoBehaviour
{
    //Set the information menu invisible at start.
    private void Start()
    {
        gameObject.SetActive(false);
    }

    //Set the information menu visible.
    private void OpenWindow()
    {
        gameObject.SetActive(true);
    }

    //Set the information menu invisible.
    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
