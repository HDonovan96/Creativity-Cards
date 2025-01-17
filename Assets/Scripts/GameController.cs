﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float money;
    public int maxHealth;
    public int health;
    public int marrowHealth;
    public int dayNum;
    public int sheepLvl, cowLvl, chickenLvl, chickLvl, pigLvl, gooseLvl;
    public bool sheepLock, cowLock, chickenLock, chickLock, pigLock, gooseLock;

    // String array to store all four of the currently selected attacks
    public string[] selectedAttack = new string[4];

    // Initialisation of variables
    public void Awake()
    {
        // Keeps object persistant across scenes
        DontDestroyOnLoad(this);

        // Sets health to the max
        health = maxHealth;
        marrowHealth = 100;

        //Resets money
        money = 250;

        //Resets Day num
        dayNum = 1;

        //Sets animal starting level
        sheepLvl = 1;
        cowLvl = 1;
        chickenLvl = 1;
        chickLvl = 1;
        pigLvl = 1;
        gooseLvl = 1;

        //set animal locked status;
        sheepLock = true;
        cowLock = true;
        chickenLock = true;
        chickLock = true;
        pigLock = true;
        gooseLock = true;

    }
}
