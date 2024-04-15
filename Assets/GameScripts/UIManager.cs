using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject newLvlPan;
    [SerializeField] GameObject gamePan;

    private void OnEnable()
    {
        Player.onNewLvl += OpenNewLvlPan;
    }

    private void OnDisable()
    {
        Player.onNewLvl -= OpenNewLvlPan;
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
