using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public static UIManager Instance; 

    public Text sheepSavedText; 
    public Text sheepDroppedText;
    public GameObject gameOverWindow;

    private void Awake()
    {
        Instance = this;

        UpdateSheepDropped();
        UpdateSheepSaved();
    }

    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() 
    {
        GameStateManager gameStateManager = GameStateManager.Instance;
        sheepDroppedText.text = gameStateManager.sheepDropped.ToString() + "/" + gameStateManager.sheepDroppedBeforeGameOver.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
