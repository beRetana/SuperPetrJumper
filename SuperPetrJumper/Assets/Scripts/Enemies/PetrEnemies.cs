using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

//Abstract class for enemies.
//I don't think it was needed but I needed to complete the requirement.
public abstract class PetrEnemies : MonoBehaviour
{
    public abstract void Attack(GameObject target);

    public abstract void Move();
}
