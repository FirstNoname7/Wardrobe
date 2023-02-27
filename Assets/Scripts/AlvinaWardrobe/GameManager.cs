using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour //работает как интерактор
{
    public static GameManager instance; //надо, чтоб этот скрипт можно было использовать в любом скрипте, просто прописав GameManager.instance

    public int materialIndex; //индекс материала текущего
    public int subObjectIndex; //индекс маски текущей
    public int foodsIndex; //индекс еды текущей
    private void Awake()
    {
        if (instance != null) //надо, чтоб скрипт GameManager не спаунился 100 раз при нескольких переходах от сцены к сцене
        {
            Destroy(gameObject); //удоляем лишний экземпляр
            return; //возвращаемся и делаем вид, что всё нормально
        }
        instance = this; //указываем, что эта переменная = экземпляр всего скрипта
        DontDestroyOnLoad(gameObject); //показываем, что надо сохранять игровой объект, к которому прикреплён этот скрипт, при переходе от сцены к сцене
        LoadIndex();
    }

    [System.Serializable] //сериализуем данные (превращаем из объектов в биты)
    class SaveData //работает как репозиторий
    {
        public int materialIndex; //индекс материала текущего
        public int subObjectIndex; //индекс маски текущей
        public int foodsIndex; //индекс еды текущей
    }
    public void SaveIndex() //сохранение данных
    {
        SaveData data = new SaveData(); //создаем экземпляр сериализуемого класса, пихаем его в переменную data
        data.materialIndex = materialIndex; //указываем, что то, что тут будет сохранено (переменная из класса SaveData) = то, что будет видно в игре (переменная из класса GameManager)
        data.subObjectIndex = subObjectIndex; //указываем, что то, что тут будет сохранено = то, что будет видно в игре (переменная из класса GameManager)
        data.foodsIndex = foodsIndex; //указываем, что то, что тут будет сохранено = то, что будет видно в игре (переменная из класса GameManager)

        string json = JsonUtility.ToJson(data); //сериализуем (сохраняем между сессиями) данные, которые есть в data (а это и data.materialIndex, и data.subObjectIndex, и data.foodsIndex). Записываем сериализацию в переменную с именем json

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json); //не забудь добавить директиву using System.IO; чтобы File работал.
        //тут ключевой момент сериализации (сохранения данных между сессиями): Application.persistentDataPath + "/savefile.json" - тут происходит запись файла в формат json по конкретному пути. Второй аргумент в скобках json - тут указывается, что именно сохраняется.
    }

    public void LoadIndex() //загрузка данных
    {
        string path = Application.persistentDataPath + "/savefile.json"; //создаём переменную, из которой будем загружать данные
        if (File.Exists(path)) //если существуют данные в переменной path, тогда:
        {
            string json = File.ReadAllText(path); //прочитать текст = вывести данные. В нашем случае выводим данные из переменной path
            SaveData data = JsonUtility.FromJson<SaveData>(json); //выводим данные из переменной json

            materialIndex = data.materialIndex; //десериализуем данные (говорим, что теперь в переменной из класса GameManager будут находиться данные из сохраняшки в json)
            subObjectIndex = data.subObjectIndex; //см. предыдущую строчку
            foodsIndex = data.foodsIndex; //см. предыдущую строчку
        }
    }

}

