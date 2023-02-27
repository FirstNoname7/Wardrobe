using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public string DisplayName; //название вкладки с типом элементов гардероба

    public List<Renderer> Renderers; //вкладка для Skinned Mesh Renderer
    public List<Material> Materials; //список всех вариантов материалов
    public List<GameObject> SubObjects; //список всех вариантов масок
    int _materialIndex; //индекс материала текущего
    int _subObjectIndex; //индекс маски текущей

    //public void NextThings(var nameIndex, var typeObject, var updateObject) //в локальных переменных пишем название переменной,
    //на которую ссылаемся
    //{
    //    nameIndex++;
    //    if(nameIndex >= typeObject.Count)
    //    {
    //        nameIndex = 0;
    //    }

    //    updateObject();
    //}

    public void NextMaterial()
    {
        _materialIndex++;
        if (_materialIndex >= Materials.Count)
        {
            _materialIndex = 0;
        }

        UpdateRenderers();
    }


    public void NextSubObjects()
    {
        _subObjectIndex++;
        if (_subObjectIndex >= SubObjects.Count)
        {
            _subObjectIndex = 0;
        }

        UpdateSubObjects();
    }

    public void UpdateSubObjects()
    {
        for (var i = 0; i < SubObjects.Count; i++)
        {
            if (SubObjects[i])
            {
                SubObjects[i].SetActive(i == _subObjectIndex);
            }
        }
    }
    public void UpdateRenderers()
    {
        foreach (var renderer in Renderers)
        {
            if (renderer)
            {
                renderer.material = Materials[_materialIndex];
            }
        }
    }
}
