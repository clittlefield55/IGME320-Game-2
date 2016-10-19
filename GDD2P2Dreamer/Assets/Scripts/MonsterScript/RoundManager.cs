using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RoundManager : MonoBehaviour {

    List<UnityEngine.Object> enemies;
    List<bool> dead;
    int[] roundCount = { 3, 4, 5, 1 };
    public GameObject enemyPrefab;
    public GameObject diary;
    public int width;
    public int length;
    int bodyCount;
    bool newRound;
    bool diarySpond = false;

	// Use this for initialization
	void Start () {
        enemies = new List<UnityEngine.Object>();
        dead = new List<bool>();

        for(int i = 0; i < 1; i++)
        {
            dead.Add(false);
        }
        newRound = true;
        bodyCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
	    if(newRound)
        {
            SetRound(1);
            newRound = false;
        }

        for(int i = 0; i < 1; i++)
        {
            if (enemies[i] == null)
            {
                dead[i] = true;
            }
        }

        if (CheckAllDead()&& diarySpond==false)
        {
            diarySpond = true;
            Instantiate(diary, new Vector3(0, 0.5f,0), Quaternion.identity);
        }

	}

    public bool CheckAllDead()
    {
        foreach(bool b in dead)
        {
           if(b == false)
           {
               return false;
           }
        }

        return true;
    }

    void SetRound(int num)
    {
        System.Random gen = new System.Random();
        for(int i = 0; i < num; i++)
        {
            int x = gen.Next(-(width/2), (width / 2));
            int z = gen.Next(-(width / 2), (width / 2));
            UnityEngine.Object nme = Instantiate(enemyPrefab, new Vector3(x, 0.278f, z), Quaternion.identity);
            enemies.Add(nme);
        }
    }

}
