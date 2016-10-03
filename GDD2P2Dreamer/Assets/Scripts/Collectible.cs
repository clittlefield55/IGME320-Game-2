using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

    public int itemsCollected = 0;

    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            print("Tick");  // debug
            Destroy(col.gameObject);
            itemsCollected++;
        }
    }
}
