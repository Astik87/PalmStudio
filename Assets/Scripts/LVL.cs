using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LVL : MonoBehaviour
{

    public Button LVL2;
    public Button LVL3;
    public Button LVL4;
    public Button LVL5;
    public Button LVL6;
    public Button LVL7;
    public Button LVL8;
    public Button LVL9;
    public Button LVL10;
    public Button LVL11;
    public Button LVL12;
    public Button LVL13;
    public Button LVL14;
    public Button LVL15;
    public Button LVL16;
    public Button LVL17;
    public Button LVL18;
    public Button LVL19;
    public Button LVL20;
    int LVLComplete;



    void Start()
    {



        LVLComplete = PlayerPrefs.GetInt("LVLComplete");
        LVL2 = GetComponent<Button>();
        LVL2.interactable = false;
        LVL3.interactable = false;
        LVL4.interactable = false;
        LVL5.interactable = false;
        LVL6.interactable = false;
        LVL7.interactable = false;
        LVL8.interactable = false;
        LVL9.interactable = false;
        LVL10.interactable = false;
        LVL11.interactable = false;
        LVL12.interactable = false;
        LVL13.interactable = false;
        LVL14.interactable = false;
        LVL15.interactable = false;
        LVL16.interactable = false;
        LVL17.interactable = false;
        LVL18.interactable = false;
        LVL19.interactable = false;
        LVL20.interactable = false;


        switch (LVLComplete)
        {
            case 1:
                LVL2.interactable = true;
                break;
            case 2:
                LVL2.interactable = true;
                LVL3.interactable = true;
                break;
            case 3:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                break;
            case 4:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;

                break;
            case 5:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                break;
            case 6:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                break;
            case 7:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                break;
            case 8:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                break;
            case 9:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                break;
            case 10:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                break;
            case 11:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                break;
            case 12:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                break;
            case 13:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                break;
            case 14:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                LVL15.interactable = true;
                break;
            case 15:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                LVL15.interactable = true;
                LVL16.interactable = true;
                break;
            case 16:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                LVL15.interactable = true;
                LVL16.interactable = true;
                LVL17.interactable = true;
                break;
            case 17:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                LVL15.interactable = true;
                LVL16.interactable = true;
                LVL17.interactable = true;
                LVL18.interactable = true;
                break;
            case 18:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                LVL15.interactable = true;
                LVL16.interactable = true;
                LVL17.interactable = true;
                LVL18.interactable = true;
                LVL19.interactable = true;
                break;
            case 19:
                LVL2.interactable = true;
                LVL3.interactable = true;
                LVL4.interactable = true;
                LVL5.interactable = true;
                LVL6.interactable = true;
                LVL7.interactable = true;
                LVL8.interactable = true;
                LVL9.interactable = true;
                LVL10.interactable = true;
                LVL11.interactable = true;
                LVL12.interactable = true;
                LVL13.interactable = true;
                LVL14.interactable = true;
                LVL15.interactable = true;
                LVL16.interactable = true;
                LVL17.interactable = true;
                LVL18.interactable = true;
                LVL19.interactable = true;
                LVL20.interactable = true;
                break;

        }

    }

    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

}