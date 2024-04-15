using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject newLvlPan;
    [SerializeField] GameObject gamePan;
    [SerializeField] GameObject deadPan;
    private void OnEnable()
    {
        Player.onNewLvl += OpenNewLvlPan;
        Player.onDead += OpenDeadPan;
    }

    private void OnDisable()
    {
        Player.onNewLvl -= OpenNewLvlPan;
        Player.onDead -= OpenDeadPan;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OpenDeadPan()
    {
        deadPan.SetActive(true);
        Time.timeScale = 0;
    }

    void OpenNewLvlPan()
    {
        Time.timeScale = 0;
        newLvlPan.SetActive(true);
        gamePan.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        newLvlPan.SetActive(false);
        gamePan.SetActive(true);
    }
}
