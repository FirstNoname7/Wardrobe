using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLook : MonoBehaviour
{
    public string DisplayName; //�������� ������� � ����� ��������� ���������

    public List<Renderer> Renderers; //������� ��� Skinned Mesh Renderer
    public List<Material> Materials; //������ ���� ��������� ����������
    public List<GameObject> SubObjects; //������ ���� ��������� �����
    int _materialIndex; //������ ��������� ��������
    int _subObjectIndex; //������ ����� �������

    //public void NextThings(var nameIndex, var typeObject, var updateObject) //� ��������� ���������� ����� �������� ����������,
    //�� ������� ���������
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
