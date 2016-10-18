using UnityEngine;
using System.Collections;

public class DiaryControl : MonoBehaviour {

    public bool diary = false;
    private int pageNum = 0;
    public GameObject firstPage;
    public GameObject secondPage;
    public GameObject thirdPage;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.K)&& diary == true)
        {
            Application.LoadLevel("DiaryScene");
            print("Press K");
            diary = false;

        }
    }

   public void diaryPage()
    {
        switch(pageNum)
        {
            case 0:
                firstPage.SetActive(false);
                secondPage.SetActive(true);
                pageNum++;
                break;
            case 1:
                secondPage.SetActive(false);
                thirdPage.SetActive(true);
                pageNum++;
                break;
            case 2:
                Application.LoadLevel("Menu");
                break;
            
        }
    }
}
