using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public List<SelectWardrobe> customizations; //список со вс€кими штуками дл€ гардероба (забираем класс Customization,
                                                //т.к. там основна€ логика прописана)
    int _currentCustomizationIndex; //текуща€ вкладка гардероба (маски или цвет) (т.к. в списке за элемент отвечает индекс)

    public SelectWardrobe CurrentCustomization { get; private set; } //переменна€ дл€ того, чтобы забрать из класса Customization
                                                                     //текущий образ перса (берЄм на гет, чтоб низ€ было помен€ть)
    //void Awake() //выполн€етс€ перед стартом
    //{
    //    foreach (var customization in customizations) //цикл дл€ подгрузки актуального состо€ни€ образа
    //    {
    //        customization.UpdateRenderers(); //актуальный материал
    //        customization.UpdateSubObjects(); //актуальна€ маска
    //    }
    //}
}


