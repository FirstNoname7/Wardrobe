using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOther : MonoBehaviour
{
    public GameObject parent;
    public void DisableChildren()
    {
        for(int i = 0; i < parent.transform.childCount; i++)
        {
            var child = parent.transform.GetChild(i).gameObject;
            if (child != null)
            {
                child.SetActive(false);
            }
        }
    }
}
