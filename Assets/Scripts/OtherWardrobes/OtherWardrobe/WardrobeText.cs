using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WardrobeText : MonoBehaviour //не забудь прикрепить это к тексту через Add Component
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Wardrobe _customizable;

    void OnValidate()
    {
        _text = GetComponent<TMP_Text>();
        _customizable = FindObjectOfType<Wardrobe>();
    }

    void Update()
    {
        _text.SetText(_customizable.CurrentCustomization?.DisplayName); //название текущей вкладки (выводится в текст на экране)
    }
}
