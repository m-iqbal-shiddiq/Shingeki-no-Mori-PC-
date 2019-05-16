using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public GameObject deadeff;
    public float starthealth = 100;
    private float health;
    public int valueGain = 50;

    [Header("Unity Stuff")]
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = starthealth;
    }

    // Menerima serangan dari animal
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/starthealth;
        if (health <= 0)
        {
            Die();
        }
    }

    // Memperlambat gara-gara laser
    public void Slow(float pst)
    {
        speed = startSpeed * (1f - pst);
    }

    // Enemy mati
    void Die()
    {
        StatsPlayer.Gold += valueGain;

        GameObject effect = Instantiate(deadeff, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        SpawnWave.enemyisAlive--;

        Destroy(gameObject);
    }
}
