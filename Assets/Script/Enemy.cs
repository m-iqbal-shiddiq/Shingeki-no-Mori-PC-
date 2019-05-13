using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public GameObject deadeff;
    public float health = 100;
    public int valueGain = 50;

    private void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pst)
    {
        speed = startSpeed * (1f - pst);
    }

    void Die()
    {
        StatsPlayer.Gold += valueGain;

        GameObject effect = Instantiate(deadeff, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

}
