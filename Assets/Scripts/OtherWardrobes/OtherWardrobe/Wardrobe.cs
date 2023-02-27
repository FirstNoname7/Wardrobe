using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Wardrobe : MonoBehaviour
{
    [SerializeField] private GameObject crab;

    public List<Customization> customizations; //список со всякими штуками для гардероба (забираем класс Customization,
                                               //т.к. там основная логика прописана)
    int _currentCustomizationIndex; //текущая вкладка гардероба (маски или цвет) (т.к. в списке за элемент отвечает индекс)

    public Customization CurrentCustomization { get; private set; } //переменная для того, чтобы забрать из класса Customization
                                                                    //текущий образ перса (берём на гет, чтоб низя было поменять)

    void Awake() //выполняется перед стартом
    {
        foreach (var customization in customizations) //цикл для подгрузки актуального состояния образа
        {
            customization.UpdateRenderers(); //актуальный материал
            customization.UpdateSubObjects(); //актуальная маска
        }
    }
    void Update() 
    {
        SelectCustomizationWithUpDownArrows(); //каждый кадр можно обращаемся к методу, отвечающему за клик на опр. клавиши,
                                               //которые переключают вкладки гардероба (у нас их 2 = материал и маски)
    }

    void SelectCustomizationWithUpDownArrows() //выбор вкладок гардероба
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
        CurrentCustomization.NextMaterial(); //подгрузится следующий материал (если открыта вкладка материалов)
        CurrentCustomization.NextSubObjects(); //подгрузится следующая маска (если открыта вкладка масок)
    }

    public void RecordingChange() //сохранение изменений в гардеробе
    {
        PrefabUtility.SaveAsPrefabAsset(crab, "Assets/Prefabs/CustomizableCrab.prefab");

    }


}

[Serializable]
public class Customization //тут в виде расширяемого списка указывается количество вкладок в гардеробе.
                           //Т.к. эт список, то не наследуется от MonoBehaviour
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