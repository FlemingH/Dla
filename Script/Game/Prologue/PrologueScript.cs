using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PrologueScript : MonoBehaviour
{

    private GameObject panelAuthor;

    public void ProloguProcedure ()
    {

        InitScene();

        Invoke("ShowPanelAuthor", 3f);
        Invoke("HidePanelAuthor", 7f);
    }

    private void InitScene ()
    {
        panelAuthor = GameObject.Find("PanelAuthor");
        panelAuthor.SetActive(false);
    }

    private void ShowPanelAuthor()
    {
        panelAuthor.SetActive(true);
    }

    private void HidePanelAuthor ()
    {
        panelAuthor.SetActive(false);
    }

}
