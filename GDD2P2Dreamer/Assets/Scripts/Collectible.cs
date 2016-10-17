using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public int itemsCollected = 0;
    public int coinCollected = 0;
    //GameObject coinObj;

    //adding sound
    public AudioClip getCoin;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            source.PlayOneShot(getCoin, 1);

            print("Tick");  // debug
            Destroy(col.gameObject);
            itemsCollected++;
        }
        if(col.gameObject.tag =="Coin")
        {
            source.PlayOneShot(getCoin, 1);

            Destroy(col.gameObject);
            GameObject.Find("CoinText").GetComponent<Coin>().addCoin();
            coinCollected++;
        }
    }
}
