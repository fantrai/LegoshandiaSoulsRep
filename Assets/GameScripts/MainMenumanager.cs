using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenumanager : MonoBehaviour
{
    public void Startgame()
    {
        SceneManager.LoadScene("Game");
    }
}
