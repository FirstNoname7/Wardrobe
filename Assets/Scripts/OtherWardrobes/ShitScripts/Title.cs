using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//этот скрипт отвечает за то, чтобы выводился текст из переменной DisplayName в скрипте SelectMaterial
public class Title : MonoBehaviour //не забудь прикрепить это к тексту через Add Component
{
    [SerializeField] TMP_Text _text;
    [SerializeField] ChangeColor _customizable;

    void OnValidate()
    {
        _text = GetComponent<TMP_Text>();
        _customizable = FindObjectOfType<ChangeColor>();
    }

    void Update()
    {
        _text.SetText(_customizable.CurrentCustomization?.DisplayName); //название текущей вкладки (выводится в текст на экране)
    }
}
