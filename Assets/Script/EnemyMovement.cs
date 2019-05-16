using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waveIndex = 0;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Ways.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWay();
        }

        enemy.speed = enemy.startSpeed;
    }

    // Jalan ke titik berikutnya
    void GetNextWay()
    {
        if (waveIndex >= Ways.points.Length - 1)
        {
            EndPath();
            return;
        }
        waveIndex++;
        target = Ways.points[waveIndex];
    }

    // Dititik akhir hapus enemy
    void EndPath()
    {
        StatsPlayer.Lives--;
        SpawnWave.enemyisAlive--;
        Destroy(gameObject);
    }

}
