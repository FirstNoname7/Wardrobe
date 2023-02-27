using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WardrobeTwo : MonoBehaviour
{
    [SerializeField] private GameObject crab;

    private void Start()
    {
        Invoke("Spawn", 0);
    }

    public void Spawn()
    {
        Instantiate(crab, transform.position, transform.rotation);
    }

    public void RecordingChange() //сохранение изменений в гардеробе
    {
        PrefabUtility.SaveAsPrefabAsset(crab, "Assets/Prefabs/CustomizableCrab Two.prefab");

    }
}
