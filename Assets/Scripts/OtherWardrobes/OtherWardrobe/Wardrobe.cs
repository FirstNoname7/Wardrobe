using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField] private GameObject crab;

    public List<Customization> customizations; //������ �� ������� ������� ��� ��������� (�������� ����� Customization,
                                               //�.�. ��� �������� ������ ���������)
    int _currentCustomizationIndex; //������� ������� ��������� (����� ��� ����) (�.�. � ������ �� ������� �������� ������)

    public Customization CurrentCustomization { get; private set; } //���������� ��� ����, ����� ������� �� ������ Customization
                                                                    //������� ����� ����� (���� �� ���, ���� ���� ���� ��������)

    void Awake() //����������� ����� �������
    {
        foreach (var customization in customizations) //���� ��� ��������� ����������� ��������� ������
        {
            customization.UpdateRenderers(); //���������� ��������
            customization.UpdateSubObjects(); //���������� �����
        }
    }
    void Update() 
    {
        SelectCustomizationWithUpDownArrows(); //������ ���� ����� ���������� � ������, ����������� �� ���� �� ���. �������,
                                               //������� ����������� ������� ��������� (� ��� �� 2 = �������� � �����)
    }

    void SelectCustomizationWithUpDownArrows() //����� ������� ���������
    {
        if (_currentCustomizationIndex < 0)
        {
            _currentCustomizationIndex = customizations.Count - 1;
        }
        if (_currentCustomizationIndex >= customizations.Count)
        {
            _currentCustomizationIndex = 0;
        }
        CurrentCustomization = customizations[_currentCustomizationIndex];

    }

    public void NextCustomization()
    {
        _currentCustomizationIndex++;
    }

    public void PreviousCustomization()
    {
        _currentCustomizationIndex--;
    }

    public void NextThing()
    {
        CurrentCustomization.NextMaterial(); //����������� ��������� �������� (���� ������� ������� ����������)
        CurrentCustomization.NextSubObjects(); //����������� ��������� ����� (���� ������� ������� �����)
    }

    public void RecordingChange() //���������� ��������� � ���������
    {
        PrefabUtility.SaveAsPrefabAsset(crab, "Assets/Prefabs/CustomizableCrab.prefab");

    }


}

[Serializable]
public class Customization //��� � ���� ������������ ������ ����������� ���������� ������� � ���������.
                           //�.�. �� ������, �� �� ����������� �� MonoBehaviour
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