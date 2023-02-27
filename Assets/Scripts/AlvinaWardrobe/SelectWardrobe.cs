using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWardrobe : MonoBehaviour
{
    public string DisplayName; //�������� ������� � ����� ��������� ���������

    public List<Renderer> Renderers; //������� ��� Skinned Mesh Renderer
    public List<Material> Materials; //������ ���� ��������� ����������
    public List<GameObject> SubObjects; //������ ���� ��������� �����
    public List<GameObject> foodsObject; //������ ���� �������


    private void Start()
    {
        if (GameManager.instance != null)
        {
            UpdateAllMaterials(GameManager.instance.materialIndex); //���� �� ��������� ��������� ����� ��� �������� � ����� (����������� � ������� ������ ���� ������ �� ����� ����������� ������, ��� ����� ������� ���� �������� ����� ��������)
            UpdateAllThings(GameManager.instance.subObjectIndex, SubObjects); //���� �� ��������� ��������� ����� ��� ����� � ����� (����������� � ������� ������ ���� ������ �� ����� ������� ������, ��� ����� ������� ���� �������� ����� ��������)
            UpdateAllThings(GameManager.instance.foodsIndex, foodsObject); //���� �� ��������� ��������� ����� ��� ��� � ����� (����������� � ������� ������ ���� ������ �� ����� ��������� ������, ��� ����� ������� ���� �������� ����� ��������)            
        }
    }

    public void CurrentMaterial(int index)
    {
        GameManager.instance.materialIndex = index;
        UpdateAllMaterials(GameManager.instance.materialIndex);
    }

    public void CurrentMask(int index)
    {
        GameManager.instance.subObjectIndex = index;
        UpdateAllThings(GameManager.instance.subObjectIndex, SubObjects);
    }

    public void CurrentFood(int index)
    {
        GameManager.instance.foodsIndex = index;
        UpdateAllThings(GameManager.instance.foodsIndex, foodsObject);
    }

    public void UpdateAllThings(int index, List<GameObject> currentList)
    {
        for (var i = 0; i < currentList.Count; i++)
        {
            if (currentList[i])
            {
                currentList[i].SetActive(i == index);
            }
        }
    }

    public void UpdateAllMaterials(int index)
    {
        foreach (var renderer in Renderers)
        {
            if (renderer)
            {
                renderer.material = Materials[index];
            }
        }        
    }

    public void SaveToJSON()
    {
        GameManager.instance.SaveIndex();
    }
}
