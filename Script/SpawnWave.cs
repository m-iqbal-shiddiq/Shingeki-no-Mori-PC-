using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWave : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform pointSpawn;

    public float selangWave = 5f;
    private float countdown = 2f;

    private int numberWave = 0;

    public Text waveText;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = selangWave;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator Spawn()
    {
        numberWave++;
        for (int i = 0; i < numberWave; i++)
        {
            EnemySpawn();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void EnemySpawn()
    {
        Instantiate(enemyPrefab, pointSpawn.position, pointSpawn.rotation);
    }
}
