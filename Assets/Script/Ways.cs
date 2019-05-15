using UnityEngine;

public class Ways : MonoBehaviour
{
    public static Transform[] points;

    // Update jalan
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
