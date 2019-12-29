using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public static string standardPlayData = JsonUtility.ToJson(new UserData("", ""));
    public static string standardPlayDataForStart = JsonUtility.ToJson(new UserData("Chapter102", ""));

    public static string standardPlayChoose = JsonUtility.ToJson(new UserChooseV1());

    private StartMenuManager startMenuManager;
    private KeyController keyController;

    private PrologueScript prologueScript;
    private C101Script c101Script;
    private C102Script c102Script;
    private C103Script c103Script;

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
        Timer.Instance.ClearAllTask();
        ShowLine.ClearTheLine();
        ShowLine.ClearTheBlackLine();
        ShowLine.ClearTheChooseLine();

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
            RewriteDataList("Chapter101", "");
            c101Script = GetComponent<C101Script>();
            c101Script.InitScene();
            return;
        }
        if (scence.name == "Chapter102")
        {
            RewriteDataList("Chapter102", "");
            c102Script = GetComponent<C102Script>();
            c102Script.InitScene();
            return;
        }
        if (scence.name == "Chapter103")
        {
            // get pre data
            UserChooseV1 userChooseV1 = GetCurUserChoosesObj();

            // override data
            if (userChooseV1.c102_1 == -1) userChooseV1.c102_1 = C102Script.chooseC102_1;
            if (userChooseV1.c102_2 == -1) userChooseV1.c102_2 = C102Script.chooseC102_2;

            // save data
            RewriteDataList("Chapter103", JsonUtility.ToJson(userChooseV1));

            c103Script = GetComponent<C103Script>();
            c103Script.InitScene();
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

            if (JsonUtility.FromJson<UserData>(dataList.data1).progress == "")
            {
                // opened game but not play
                dataList.isNew = true;
            } else
            {
                // opened game and have data
                dataList.isNew = false;
            }
            dataList.dataNum = 1;
            dataList.userChooseV1 = standardPlayChoose;
        } else
        {
            dataList.data1 = standardPlayData;
            dataList.data2 = standardPlayData;
            dataList.data3 = standardPlayData;
            dataList.isNew = true;
            dataList.dataNum = 1;
            dataList.userChooseV1 = standardPlayChoose;
            PlayerPrefs.SetString("DataList", JsonUtility.ToJson(dataList));
        }

        return dataList;
    }

    private UserChooseV1 GetCurUserChoosesObj()
    {
        DataList curDataList = JsonUtility.FromJson<DataList>(PlayerPrefs.GetString("DataList"));

        return JsonUtility.FromJson<UserChooseV1>(curDataList.userChooseV1);
    }

    private void RewriteDataList(string sceneName, string chooses)
    {
        DataList curDataList = JsonUtility.FromJson<DataList>(PlayerPrefs.GetString("DataList"));
        UserData curUserData;

        if (chooses != "") { curDataList.userChooseV1 = chooses; }

        switch (curDataList.dataNum)
        {
            case 1:
                curUserData = JsonUtility.FromJson<UserData>(curDataList.data1);
                curUserData.progress = sceneName;
                curUserData.dataTime = GetCurTimeFormat();
                curDataList.data1 = JsonUtility.ToJson(curUserData);
                break;
            case 2:
                curUserData = JsonUtility.FromJson<UserData>(curDataList.data2);
                curUserData.progress = sceneName;
                curUserData.dataTime = GetCurTimeFormat();
                curDataList.data2 = JsonUtility.ToJson(curUserData);
                break;
            case 3:
                curUserData = JsonUtility.FromJson<UserData>(curDataList.data3);
                curUserData.progress = sceneName;
                curUserData.dataTime = GetCurTimeFormat();
                curDataList.data3 = JsonUtility.ToJson(curUserData);
                break;
        }

        PlayerPrefs.SetString("DataList", JsonUtility.ToJson(curDataList));
    }

    private string GetCurTimeFormat ()
    {
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        int day = DateTime.Now.Day;
        int hour = DateTime.Now.Hour;
        int min = DateTime.Now.Minute;
        int sec = DateTime.Now.Second;

        return string.Format("{0:D2}:{1:D2}:{2:D2} " + "{3:D4}-{4:D2}-{5:D2}", 
            hour, min, sec, year, month, day);
    }
}

public class DataList
{
    public string data1;
    public string data2;
    public string data3;
    public bool isNew;
    public int dataNum;
    public string userChooseV1;
}

public class UserData
{
    public string progress;
    public string dataTime;

    public UserData(string p, string time) 
    {
        progress = p;
        dataTime = time;
    }
}

public class ChapterName
{
    public static Dictionary<string, string> nameMap = new Dictionary<string, string>();

    public ChapterName()
    {
        nameMap.Add("PrologueScene", "序章");
        nameMap.Add("Chapter101", "医院，七天前");
        nameMap.Add("Chapter102", "车祸，疑惑");
        nameMap.Add("Chapter103", "消防通道，六天前");
    }

    public static string GetChapterName(string code)
    {
        return nameMap[code];
    }
}

public class UserChooseV1
{
    public int c102_1 = -1;
    public int c102_2 = -1;
}