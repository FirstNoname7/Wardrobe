using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Character", menuName = "Wardrobe/Character")]
public class Character : ScriptableObject
{
    public GameObject crab;
    public Transform transformPosition;
    public Transform CurrentPosition()
    {
        transformPosition = GameObject.Find("Character").transform;
        return transformPosition;
    }
}
