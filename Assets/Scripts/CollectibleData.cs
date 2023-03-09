using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CollectibleData : ScriptableObject
{
    public string collectibleName;
    public int countCollected = 0;
    public int countRequired;

    public void OnEnable()
    {
        countCollected = 0;
    }
}
