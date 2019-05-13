﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalTurret : MonoBehaviour
{
    public Transform target;

    public string enemyTag = "Enemy";
    [Header("Setup Fields")]
    public float area = 15f;
    public GameObject bonePrefab;
    public Transform pointFire;

    public Transform Rotate;

    public float turnSpeed = 10f;

    [Header("Common Bullet")]
    public float rateFire = 1f;
    private float countdownFire = 0f;

    [Header("Laser Bullet")]
    public bool useLaser = false;
    public LineRenderer lineRenderer; 
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
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            return;
        }
        //Lock On
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (countdownFire <= 0f)
            {
                Shooting();
                countdownFire = 1f / rateFire;
            }
            countdownFire -= Time.deltaTime;
        }

    } 

    void LockOnTarget()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(Rotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }

    void Laser()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, pointFire.position);
        lineRenderer.SetPosition(1, target.position);
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
