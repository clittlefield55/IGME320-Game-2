using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        if (col.gameObject.tag == "Diary")
        {
            Destroy(col.gameObject);
            //diaryGameObj.SetActive(true);
            GameObject.Find("DiaryButton").GetComponent<Image>().color = new Color(50, 50, 50);
            GameObject.Find("DiaryButton").GetComponent<DiaryControl>().diary = true;

        }
    }
}
