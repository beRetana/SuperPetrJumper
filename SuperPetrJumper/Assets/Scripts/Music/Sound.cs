using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Creates an object that makes audio assets easy to indetify and obtain  information
 about it such as the name and the audio asset.*/

[System.Serializable]
public class Sound
{
    [SerializeField] private string name;
    [SerializeField] private AudioClip clip;
    public string Name { get { return name; } }
    public AudioClip Clip { get { return clip; } }
}
