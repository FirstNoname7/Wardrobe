using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public List<SelectWardrobe> customizations; //������ �� ������� ������� ��� ��������� (�������� ����� Customization,
                                                //�.�. ��� �������� ������ ���������)
    int _currentCustomizationIndex; //������� ������� ��������� (����� ��� ����) (�.�. � ������ �� ������� �������� ������)

    public SelectWardrobe CurrentCustomization { get; private set; } //���������� ��� ����, ����� ������� �� ������ Customization
                                                                     //������� ����� ����� (���� �� ���, ���� ���� ���� ��������)
    //void Awake() //����������� ����� �������
    //{
    //    foreach (var customization in customizations) //���� ��� ��������� ����������� ��������� ������
    //    {
    //        customization.UpdateRenderers(); //���������� ��������
    //        customization.UpdateSubObjects(); //���������� �����
    //    }
    //}
}


