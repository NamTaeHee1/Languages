using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{
    public GameObject Option, End, BlurPanel;
    public GameObject BackButtonUI, MachingButtonUI; 

    private void Update()
    {
        ShowMachingUI();
    }

    public void InputGameStart()
    {
        Debug.Log("Start");
        BlurPanel.SetActive(false);
        FindObjectOfType<ShowPlayer>().showEnd = true;
        Invoke("PlayerMoveStart", 0.75f);
    }

    public void InputEnd()
    {
        Debug.Log("End");
        Application.Quit();
    }

    public void InputBack()
    {
        FindObjectOfType<ShowPlayer>().showEnd = false;
        FindObjectOfType<ShowPlayer>().Show = false;
    }

    public void InputMaching()
    {
        FindObjectOfType<NetworkManager>().Init();
    }

    void PlayerMoveStart()
    {
        FindObjectOfType<ShowPlayer>().Show = true;
    }

    void ShowMachingUI()
    {
        if (FindObjectOfType<ShowPlayer>().showEnd)
        {
            MachingButtonUI.SetActive(true);
            BackButtonUI.SetActive(true);
        }
        else
        {
            BlurPanel.SetActive(true);
            MachingButtonUI.SetActive(false);
            BackButtonUI.SetActive(false);
        }
    }
}
