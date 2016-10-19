using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    public int coinNum = 0;
    UnityEngine.UI.Text coin;
    //public GUIText coinText;
	// Use this for initialization
	void Start () {
        coin = GetComponent<Text>();
        coin.text = "Coin:" + coinNum;
	}
	
	// Update is called once per frame
	void Update () {
        coin.text = "Coin:" + coinNum;
    }
    public void addCoin()
    {
        coinNum++;
    }
    public void useCoin(int num)
    {
        coinNum = coinNum - num;
    }
}
