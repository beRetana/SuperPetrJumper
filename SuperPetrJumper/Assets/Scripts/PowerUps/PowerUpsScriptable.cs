using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Wanted to learn how to use scriptable objects even though I think
  that using an abstract class would have been more efficient*/

public abstract class PowerUpsScriptable : ScriptableObject
{
    //Empty class to be enherited 
    public abstract void ChangeSkins(GameObject target, Sprite skin);

    //Empty class to be enherited
    public abstract void ActivatePower(GameObject target, string powerUp);
} 
