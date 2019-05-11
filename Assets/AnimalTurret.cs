using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTurret : MonoBehaviour
{
    public Transform target;

    public string enemyTag = "Enemy";

    public float area = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void targetUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float jarakTerpendek = Mathf.Infinity;
        GameObject enemyTerdekat = null;
        foreach(GameObject enemy in enemies)
        {
            float jarakEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(jarakEnemy < jarakTerpendek)
            {
                jarakTerpendek = jarakEnemy;
                enemyTerdekat = enemy;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, area);
    }
}
