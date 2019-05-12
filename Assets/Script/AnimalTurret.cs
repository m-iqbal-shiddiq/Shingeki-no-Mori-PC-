using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTurret : MonoBehaviour
{
    public Transform target;

    public string enemyTag = "Enemy";

    public float area = 15f;

    public Transform Rotate;

    public float turnSpeed = 10f;

    public float rateFire = 1f;
    private float countdownFire = 0f;

    public GameObject bonePrefab;
    public Transform pointFire;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("targetUpdate", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(Rotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if( countdownFire <= 0f)
        {
            Shooting();
            countdownFire = 1f / rateFire;
        }
        countdownFire -= Time.deltaTime;
    } 

    void Shooting()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bonePrefab, pointFire.position, pointFire.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
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

        if(enemyTerdekat != null && jarakTerpendek <= area)
        {
            target = enemyTerdekat.transform;
        } else
        {
            target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, area);
    }
}
