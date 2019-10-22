using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private StartMenuManager startMenuManager;
    private KeyController keyController;

    private DataList dataList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // run when scence loaded
    private void OnSceneLoaded(Scene scence, LoadSceneMode mod)
    {
        if (scence.name == "StartMenuScene")
        {
            startMenuManager = GetComponent<StartMenuManager>();
            keyController = GetComponent<KeyController>();

            InitGame();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void InitGame()
    {
        Cursor.visible = false;
        startMenuManager.InitMenu(GetUserData());
    }

    private DataList GetUserData()
    {

        dataList = new DataList();

        if (PlayerPrefs.HasKey("DataList"))
        {
            dataList = JsonUtility.FromJson<DataList>(PlayerPrefs.GetString("DataList"));
            dataList.isNew = false;
        } else
        {
            dataList.data1 = "testData";
            dataList.data2 = "";
            dataList.data3 = "";
            dataList.isNew = true;
            PlayerPrefs.SetString("DataList", JsonUtility.ToJson(dataList));
        }

        return dataList;
    }

}

public class DataList
{
    public string data1;
    public string data2;
    public string data3;
    public bool isNew;
}