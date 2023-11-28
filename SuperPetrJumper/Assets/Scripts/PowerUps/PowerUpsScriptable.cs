using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpsScriptable : ScriptableObject
{
    //Empty class to be enherited 
    public abstract void ChangeSkins(GameObject target, Sprite skin);
    //Empty class to be enherited
    public abstract void ActivatePower(GameObject target, string powerUp);
} 
