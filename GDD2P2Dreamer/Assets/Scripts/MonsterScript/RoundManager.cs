using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class RoundManager : MonoBehaviour
{

    private List<GameObject> enemies;
    private List<bool> dead;
    int[] roundCount = { 3, 4, 5 };
    int currentRound;
    public GameObject enemyPrefab;
    public GameObject diary;
    GameObject pickup;
    public int width;
    public int length;
    int bodyCount;
    bool newRound;

    public List<GameObject> Enemies
    {
        get { return enemies; }
    }


    // Use this for initialization
    void Start()
    {
        enemies = new List<GameObject>();
        dead = new List<bool>();


        newRound = true;
        bodyCount = 0;
        currentRound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRound < roundCount.Length)
        {
            if (newRound)
            {
                SetRound(roundCount[currentRound]);
                newRound = false;
            }

            for (int i = 0; i < roundCount[currentRound]; i++)
            {
                if (enemies[i] == null)
                {
                    dead[i] = true;
                }
            }

            if (CheckAllDead())
            {
                currentRound++;
                newRound = true;
            }
        }

        if (currentRound >= roundCount.Length)
        {
            //Do win state
            pickup = (GameObject)Instantiate(diary, new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

    }

    public bool CheckAllDead()
    {
        foreach (bool b in dead)
        {
            if (b == false)
            {
                return false;
            }
        }

        return true;
    }

    void SetRound(int num)
    {
        System.Random gen = new System.Random();
        enemies.Clear();
        for (int i = 0; i < num; i++)
        {
            int x = gen.Next(-(width / 2), (width / 2));
            int z = gen.Next(-(width / 2), (width / 2));
            GameObject nme = (GameObject)Instantiate(enemyPrefab, new Vector3(x, 0.278f, z), Quaternion.identity);
            enemies.Add(nme);
        }

        dead.Clear();
        for (int i = 0; i < num; i++)
        {
            dead.Add(false);
        }
    }



}
