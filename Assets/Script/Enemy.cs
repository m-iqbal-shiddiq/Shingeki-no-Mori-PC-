using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waveIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        target = Ways.points[0];
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
            Destroy(gameObject);
            return;
        }
        waveIndex++;
        target = Ways.points[waveIndex];
    }
}
