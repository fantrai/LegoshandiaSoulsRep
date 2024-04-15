using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int[] countEnemyPerSecondInWawe;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float[] timerNewWave;
    int wave = 0;
    float gameTime;

    private void Start()
    {
        Enemy.tarfet = player;
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        do
        {
            float radScreen = Camera.main.orthographicSize * Screen.height / Screen.width;

            var random = new System.Random();
            int degree = random.Next(0, 360);

            float x = radScreen * MathF.Cos(degree);
            float y = radScreen * MathF.Sin(degree);

            Vector2 spawnPos = new Vector3(x, y, 0) + player.transform.position;

            Instantiate(enemyPrefab[wave], spawnPos, enemyPrefab[wave].transform.rotation);

            float time = 1f / countEnemyPerSecondInWawe[wave];
            gameTime += time;
            yield return new WaitForSeconds(time);
            if (gameTime >= timerNewWave[wave] && wave < timerNewWave.Length)
            {
                wave++;
            }
        } while (true);
    }
}
