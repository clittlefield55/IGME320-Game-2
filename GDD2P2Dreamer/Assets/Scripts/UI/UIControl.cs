using UnityEngine;
using System.Collections;

public class UIControl : MonoBehaviour {
    GameObject main;
    GameObject page1;
    GameObject page2;
    void Start()
    {
        main = GameObject.Find("Main");
        page1 = GameObject.Find("Page1");
        page2 = GameObject.Find("Page2");
        page1.SetActive(false);
        page2.SetActive(false);

    }
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
        //if (sceneName == "game1")
        //{
        //    Cursor.visible = false;

        //}
        //else
        //{
        //    Cursor.visible = true;

        //}
    }
    public void ChangePage(int id)
    {
        if(id == 0) // change to page 1
        {
            main.SetActive(false);
            page1.SetActive(true);
        }
        else if(id == 1) // change to page 2
        {
            page1.SetActive(false);
            page2.SetActive(true);
        }
    }
}
