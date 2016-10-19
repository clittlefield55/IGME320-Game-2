using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpGrade : MonoBehaviour {

    GameObject cabinetCanvas;
    GameObject UpGradeUI;
    GameObject monsterControl;
    bool UIActive = false;
    int locator = 0; // start from health 
    bool onPress = false; // when press on a button


    // Use this for initialization
    void Start () {
        cabinetCanvas = GameObject.Find("UpGradeCanvas"); // hope this work
        cabinetCanvas.SetActive(false);
        UpGradeUI = GameObject.Find("UpGradeUI");
        UpGradeUI.SetActive(false);
        monsterControl = GameObject.Find("MonsterManager");


    }

    // Update is called once per frame
    void Update () {



        int coinNum = GameObject.Find("CoinText").GetComponent<Coin>().coinNum;

        if (monsterControl.GetComponent<RoundManager>().CheckAllDead()==true)
        {
            // activate upgrade system
            cabinetCanvas.SetActive(true);

        }
        if(UIActive == true)
        {

            ColorBlock cb = ColorBlock.defaultColorBlock;
            // set bool
            bool healthBool = false;
            bool attackBool = false; // if coin is enough

            cb.normalColor = Color.black;
            GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;
            GameObject.Find("HPButton").GetComponent<Button>().colors = cb;

            if (coinNum >= 5)
            {
                healthBool = true;
                cb.normalColor = Color.grey;
                //print("Health set true");
                GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
            }
            if (coinNum >= 6)
            {
                cb.normalColor = Color.grey;
                GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;

                attackBool = true;
            }
            if(healthBool == true && attackBool== false)
            {
                cb.normalColor = Color.white;
                //print("Health set true");
                GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
            }


            // Control Button using Arrow
            if (locator == 0 && attackBool == true) // change to attact button if activate
            {
                //cb.normalColor = new Color(240, 240, 240);
                //GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
                cb.normalColor = new Color(255, 255, 255);
                GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
                cb.normalColor = Color.grey;
                GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;
                if (Input.GetKey(KeyCode.DownArrow) )
                {
                    print("ATTACK Button");
                    locator = 1;
                    //onPress = true;
                    //cb.normalColor = new Color(255,255,255);
                    //GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;
                    //cb.normalColor = Color.grey;
                    //GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
                }

                if (Input.GetKeyDown(KeyCode.U)&& coinNum>=5)
                {      
                    print("Use Coin");
                    GameObject.Find("CoinText").GetComponent<Coin>().useCoin(5);
                    GameObject.Find("PlayerCollider").GetComponent<PlayerController>().hpUpgrade();
                }
            }
            if(locator == 1 && healthBool == true)// change to health button
            {
                //cb.normalColor = new Color(240, 240, 240);
                //GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;
                cb.normalColor = new Color(255, 255, 255);
                GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;
                cb.normalColor = Color.grey;
                GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    print("Health Button");
                    locator = 0;
                    //cb.normalColor = new Color(255, 255, 255);
                    //GameObject.Find("HPButton").GetComponent<Button>().colors = cb;
                    //cb.normalColor = Color.grey;
                    //GameObject.Find("AtkButton").GetComponent<Button>().colors = cb;
                }
                if (Input.GetKeyDown(KeyCode.U)&& coinNum>=6)
                {
                    GameObject.Find("CoinText").GetComponent<Coin>().useCoin(6);
                    GameObject.Find("PlayerCollider").GetComponent<PlayerController>().atkUpgrade();

                }
            }

            


        }
	}
    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (monsterControl.GetComponent<RoundManager>().CheckAllDead() == true)
        {
            if (col.gameObject.tag == "Player")
            {
                UpGradeUI.SetActive(true);
                UIActive = true;
            }
        }
    }

    public void upgrade(string button)
    {
        int coinNum = GameObject.Find("CoinText").GetComponent<Coin>().coinNum;

        if (button == "Health")
        {
            if(coinNum >=5)
            {
                GameObject.Find("CoinText").GetComponent<Coin>().useCoin(5);

            }
        }
        if(button =="Attack")
        {
            if(coinNum >= 7)
            {
                GameObject.Find("CoinText").GetComponent<Coin>().useCoin(7);
            }
        }
    }
}
