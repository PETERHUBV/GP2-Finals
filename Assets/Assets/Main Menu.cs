using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;             
    public GameObject pauseMenu;           
    public GameObject[] characterModels;    
    private bool isGamePaused = false;      

    void Start()
    {
        ShowMainMenu();  
    }

    
    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        foreach (var character in characterModels)
        {
            character.SetActive(false);  
        }
    }

   
    public void StartGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        ShowCharacterModel(0);           
        Time.timeScale = 1f;             
    }

    
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit(); 
    }

    
    public void PauseGame()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);  
        Time.timeScale = 0f;         
    }

   
    public void ResumeGame()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false); 
        Time.timeScale = 1f;         
    }

   
    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;        
        ShowMainMenu(); 
    }

   
    public void ShowCharacterModel(int index)
    {
        
        foreach (var character in characterModels)
        {
            character.SetActive(false);
        }

        
        if (index >= 0 && index < characterModels.Length)
        {
            characterModels[index].SetActive(true); 
        }
    }

   
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();  
            }
            else
            {
                PauseGame();   
            }
        }
    }
}