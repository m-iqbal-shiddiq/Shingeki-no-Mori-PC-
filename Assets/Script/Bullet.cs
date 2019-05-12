using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public GameObject efekBullet;

    public void Seek(Transform target_)
    {
        target = target_;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float jarakFrame = speed * Time.deltaTime;

        if (direction.magnitude <= jarakFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(direction.normalized * jarakFrame, Space.World);
    }

    void hitTarget()
    {
        GameObject effectGO = (GameObject)Instantiate(efekBullet, transform.position, transform.rotation);
        Destroy(effectGO, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
