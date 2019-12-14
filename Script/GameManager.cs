using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    private StartMenuManager startMenuManager;
    private KeyController keyController;

    private PrologueScript prologueScript;
    private C101Script c101Script;
    private C102Script c102Script;

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
            return;
        }
        if (scence.name == "PrologueScene")
        {
            prologueScript = GetComponent<PrologueScript>();
            prologueScript.InitScene();
            return;
        }
        if (scence.name == "Chapter101")
        {
            RewriteDataList("Chapter101");
            c101Script = GetComponent<C101Script>();
            c101Script.InitScene();
            return;
        }
        if (scence.name == "Chapter102")
        {
            RewriteDataList("Chapter102");
            c102Script = GetComponent<C102Script>();
            c102Script.InitScene();
            return;
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
        // Cursor.visible = false;
        startMenuManager.InitMenu(GetUserData());
    }

    private DataList GetUserData()
    {
        dataList = new DataList();

        if (PlayerPrefs.HasKey("DataList"))
        {
            dataList = JsonUtility.FromJson<DataList>(PlayerPrefs.GetString("DataList"));
            dataList.isNew = false;
            dataList.dataNum = 1;
        } else
        {
            dataList.data1 = "{\"progress\": \"PrologueScene\"}";
            dataList.data2 = "{\"progress\": \"\"}";
            dataList.data3 = "{\"progress\": \"\"}";
            dataList.isNew = true;
            dataList.dataNum = 1;
            PlayerPrefs.SetString("DataList", JsonUtility.ToJson(dataList));
        }

        return dataList;
    }

    private void RewriteDataList(string sceneName)
    {
        DataList curDataList = JsonUtility.FromJson<DataList>(PlayerPrefs.GetString("DataList"));
        UserData curUserData;

        switch (curDataList.dataNum)
        {
            case 1:
                curUserData = JsonUtility.FromJson<UserData>(curDataList.data1);
                curUserData.progress = sceneName;
                curDataList.data1 = JsonUtility.ToJson(curUserData);
                break;
            case 2:
                curUserData = JsonUtility.FromJson<UserData>(curDataList.data2);
                curUserData.progress = sceneName;
                curDataList.data2 = JsonUtility.ToJson(curUserData);
                break;
            case 3:
                curUserData = JsonUtility.FromJson<UserData>(curDataList.data3);
                curUserData.progress = sceneName;
                curDataList.data3 = JsonUtility.ToJson(curUserData);
                break;
        }
        PlayerPrefs.SetString("DataList", JsonUtility.ToJson(curDataList));
    }

}

public class DataList
{
    public string data1;
    public string data2;
    public string data3;
    public bool isNew;
    public int dataNum;
}

public class UserData
{
    public string progress;
}