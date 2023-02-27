using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //�������� ��� ����������
{
    public static GameManager instance; //����, ���� ���� ������ ����� ���� ������������ � ����� �������, ������ �������� GameManager.instance

    public int materialIndex; //������ ��������� ��������
    public int subObjectIndex; //������ ����� �������
    public int foodsIndex; //������ ��� �������
    private void Awake()
    {
        if (instance != null) //����, ���� ������ GameManager �� ��������� 100 ��� ��� ���������� ��������� �� ����� � �����
        {
            Destroy(gameObject); //������� ������ ���������
            return; //������������ � ������ ���, ��� �� ���������
        }
        instance = this; //���������, ��� ��� ���������� = ��������� ����� �������
        DontDestroyOnLoad(gameObject); //����������, ��� ���� ��������� ������� ������, � �������� ��������� ���� ������, ��� �������� �� ����� � �����
        LoadIndex();
    }

    [System.Serializable] //����������� ������ (���������� �� �������� � ����)
    class SaveData //�������� ��� �����������
    {
        public int materialIndex; //������ ��������� ��������
        public int subObjectIndex; //������ ����� �������
        public int foodsIndex; //������ ��� �������
    }
    public void SaveIndex() //���������� ������
    {
        SaveData data = new SaveData(); //������� ��������� �������������� ������, ������ ��� � ���������� data
        data.materialIndex = materialIndex; //���������, ��� ��, ��� ��� ����� ��������� (���������� �� ������ SaveData) = ��, ��� ����� ����� � ���� (���������� �� ������ GameManager)
        data.subObjectIndex = subObjectIndex; //���������, ��� ��, ��� ��� ����� ��������� = ��, ��� ����� ����� � ���� (���������� �� ������ GameManager)
        data.foodsIndex = foodsIndex; //���������, ��� ��, ��� ��� ����� ��������� = ��, ��� ����� ����� � ���� (���������� �� ������ GameManager)

        string json = JsonUtility.ToJson(data); //����������� (��������� ����� ��������) ������, ������� ���� � data (� ��� � data.materialIndex, � data.subObjectIndex, � data.foodsIndex). ���������� ������������ � ���������� � ������ json

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); //�� ������ �������� ��������� using System.IO; ����� File �������.
        //��� �������� ������ ������������ (���������� ������ ����� ��������): Application.persistentDataPath + "/savefile.json" - ��� ���������� ������ ����� � ������ json �� ����������� ����. ������ �������� � ������� json - ��� �����������, ��� ������ �����������.
    }

    public void LoadIndex() //�������� ������
    {
        string path = Application.persistentDataPath + "/savefile.json"; //������ ����������, �� ������� ����� ��������� ������
        if (File.Exists(path)) //���� ���������� ������ � ���������� path, �����:
        {
            string json = File.ReadAllText(path); //��������� ����� = ������� ������. � ����� ������ ������� ������ �� ���������� path
            SaveData data = JsonUtility.FromJson<SaveData>(json); //������� ������ �� ���������� json

            materialIndex = data.materialIndex; //������������� ������ (�������, ��� ������ � ���������� �� ������ GameManager ����� ���������� ������ �� ���������� � json)
            subObjectIndex = data.subObjectIndex; //��. ���������� �������
            foodsIndex = data.foodsIndex; //��. ���������� �������
        }
    }

}

