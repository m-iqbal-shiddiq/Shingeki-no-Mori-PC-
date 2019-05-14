using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public int damage = 50;
    public float speed = 70f;
    public float explodeRadius = 0f;
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

        if (explodeRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explodeRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
          
                Damage(collider.transform);
            }     
        }
    }
    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

       
    }
    


}
