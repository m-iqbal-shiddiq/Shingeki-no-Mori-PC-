using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWave : MonoBehaviour
{
    public static int enemyisAlive = 0;

    public Wave[] waves;

    public Transform pointSpawn;

    public float selangWave = 5f;
    private float countdown = 2f;

    private int numberWave = 0;

    public Text waveText;

    public GameManager gameManager;
    private void Update()
    {
        if(enemyisAlive > 0)
        {
            return;
        }
        // buat wave kalo satu wave udah kelar
        if(countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = selangWave;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveText.text = string.Format("{0:00.00}", countdown);
    }

    // Increment Spawn Enemy
    IEnumerator Spawn()
    {
        StatsPlayer.Wave++;
        Wave wave = waves[numberWave];

        enemyisAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            EnemySpawn(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        numberWave++;
        if(numberWave == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
    }

    // Memanggil Enemy
    void EnemySpawn(GameObject enemy)
    {
        Instantiate(enemy, pointSpawn.position, pointSpawn.rotation);
    }
}
