using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C103Script : MonoBehaviour
{
    private void Update()
    {
        Timer.Instance.UpdateTimer();
    }
    public void InitScene()
    {
        LoadLine1();
    }

    private void LoadLine1()
    {
        ShowLine.ShowTheBlackLine("");
        Timer.Instance.AddTimerTask(4, () => { ShowLine.ClearTheBlackLine(); });
    }
}
