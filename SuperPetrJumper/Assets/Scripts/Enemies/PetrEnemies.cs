using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public abstract class PetrEnemies : MonoBehaviour
{
    public abstract void Attack(GameObject target);

    public abstract void Move();
}
