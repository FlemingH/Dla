using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject canvasShade;
    public GameObject canvasShowLine;
    public GameObject audioManager;

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
        if (CanvasShade.instance == null)
        {
            Instantiate(canvasShade);
        }
        if (ShowLine.instance == null)
        {
            Instantiate(canvasShowLine);
        }
        if (AudioManager.instance == null)
        {
            Instantiate(audioManager);
        }
    }
}
