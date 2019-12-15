using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private Timer()
    {
        m_timerTask = new List<TimerTask>();
    }

    private static Timer m_instance;

    public static Timer Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new Timer();
            }
            return m_instance;
        }
    }

    public delegate void OnTimeStart();

    private List<TimerTask> m_timerTask = null;

    public class TimerTask
    {
        //public int Id;
        public float RealTime;
        public float Time;
        //public bool IsLoop;
        //public int LoopCount;
        public OnTimeStart CallBack;
    }

    public void UpdateTimer()
    {
        for (int i = 0; i < m_timerTask.Count; i++)
        {
            TimerTask t = m_timerTask[i];
            if (t == null)
            {
                continue;
            }

            // using Time.time not realtimeSinceStartup to fix pause cant stop the line
            if (t.RealTime < Time.time)
            {
                if (null != t.CallBack)
                {
                    t.CallBack();
                    m_timerTask.Remove(t);
                }
            }
        }
    }

    public void AddTimerTask(float time, OnTimeStart callback)
    {
        if (null == callback)
        {
            return;
        }
        TimerTask t = new TimerTask();
        t.Time = time;
        t.RealTime = Time.time + time;
        t.CallBack = callback;
        m_timerTask.Add(t);
    }

    public void ClearAllTask()
    {
        m_timerTask = new List<TimerTask>();
    }
}