using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//���� ������ �������� �� ��, ����� ��������� ����� �� ���������� DisplayName � ������� SelectMaterial
public class Title : MonoBehaviour //�� ������ ���������� ��� � ������ ����� Add Component
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
        _text.SetText(_customizable.CurrentCustomization?.DisplayName); //�������� ������� ������� (��������� � ����� �� ������)
    }
}
