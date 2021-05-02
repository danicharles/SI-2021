﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{

    public static GameStateManager Instance; 

    [HideInInspector]
    public int sheepSaved; 

    [HideInInspector]
    public int sheepDropped;

    public int sheepDroppedBeforeGameOver;
    public SheepSpawner sheepSpawner;

    private void Awake()
    {
        Instance = this;

        sheepSaved = 0;
        sheepDropped = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep();

        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();

        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            if(sheepSaved > HighScore.highScore)
            {
                HighScore.highScore = sheepSaved;
            }

            GameOver();
        }
    }
}
