using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWardrobe : MonoBehaviour
{
    public string DisplayName; //название вкладки с типом элементов гардероба

    public List<Renderer> Renderers; //вкладка для Skinned Mesh Renderer
    public List<Material> Materials; //список всех вариантов материалов
    public List<GameObject> SubObjects; //список всех вариантов масок
    public List<GameObject> foodsObject; //список всех кушаний


    private void Start()
    {
        if (GameManager.instance != null)
        {
            UpdateAllMaterials(GameManager.instance.materialIndex); //тута мы обновляем постоянно какой сча материал у перса (ОБЯЗАТЕЛЬНО У ПРЕФАБА ДОЛЖЕН БЫТЬ СПИСОК СО ВСЕМИ МАТЕРИАЛАМИ ПОЛНЫМ, БЕЗ ЭТОГО СКРИПТУ ТУПО НЕОТКУДА БРАТЬ ПРЕДМЕТЫ)
            UpdateAllThings(GameManager.instance.subObjectIndex, SubObjects); //тута мы обновляем постоянно какая сча маска у перса (ОБЯЗАТЕЛЬНО У ПРЕФАБА ДОЛЖЕН БЫТЬ СПИСОК СО ВСЕМИ МАСКАМИ ПОЛНЫМ, БЕЗ ЭТОГО СКРИПТУ ТУПО НЕОТКУДА БРАТЬ ПРЕДМЕТЫ)
            UpdateAllThings(GameManager.instance.foodsIndex, foodsObject); //тута мы обновляем постоянно какая сча еда у перса (ОБЯЗАТЕЛЬНО У ПРЕФАБА ДОЛЖЕН БЫТЬ СПИСОК СО ВСЕМИ КУШАНИЯМИ ПОЛНЫМ, БЕЗ ЭТОГО СКРИПТУ ТУПО НЕОТКУДА БРАТЬ ПРЕДМЕТЫ)            
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
