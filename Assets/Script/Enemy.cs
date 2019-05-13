using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waveIndex = 0;

    public GameObject deadeff;
    public int health = 100;
    public int valueGain = 50;
    // Start is called before the first frame update
    void Start()
    {
        target = Ways.points[0];
    }
     
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        StatsPlayer.Gold += valueGain;

        GameObject effect = Instantiate(deadeff, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWay();
        }
    }

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

    void EndPath()
    {
        StatsPlayer.Lives--;
        Destroy(gameObject);
    }


}
