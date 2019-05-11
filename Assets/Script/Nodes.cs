
using UnityEngine;

public class Nodes : MonoBehaviour
{
    private GameObject animal;
    public Color hoverColor;
    private Renderer Rend;
    private Color startColor;
    public Quaternion rotationOffset;
    public Vector3 positionOffset;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        startColor = Rend.material.color;
    }

    private void OnMouseEnter()
    {
        Rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if (animal != null)
        {
            return;
        }
        GameObject animalToSpawn = BuildManager.instance.GetAnimalToSpawn();
        animal = (GameObject)Instantiate(animalToSpawn, transform.position+positionOffset, rotationOffset);
    }

    private void OnMouseExit()
    {
        Rend.material.color = startColor;
    }
}
