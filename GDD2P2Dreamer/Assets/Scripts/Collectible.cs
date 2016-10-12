using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public int itemsCollected = 0;
    public int coinCollected = 0;
    //GameObject coinObj;
    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            print("Tick");  // debug
            Destroy(col.gameObject);
            itemsCollected++;
        }
        if(col.gameObject.tag =="Coin")
        {
            Destroy(col.gameObject);
            GameObject.Find("CoinText").GetComponent<Coin>().addCoin();
            coinCollected++;

        }
    }
}
