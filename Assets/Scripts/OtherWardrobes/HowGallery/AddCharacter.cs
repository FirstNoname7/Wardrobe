using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCharacter : MonoBehaviour
{
    public Character addCharacter;
    public Transform targetTransform;

    private void Awake()
    {
        Instantiate(addCharacter);
        //addCharacter.transformPosition.SetParent(targetTransform);
        addCharacter.CurrentPosition();
    }
}
