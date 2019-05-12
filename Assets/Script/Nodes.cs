using UnityEngine.EventSystems;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    private GameObject animal;
    public Color hoverColor;
    private Renderer Rend;
    private Color startColor;
    public Quaternion rotationOffset;
    public Vector3 positionOffset;
    BuildManager buildManager;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        startColor = Rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetAnimalToSpawn() == null)
        {
            return;
        }

        Rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetAnimalToSpawn() == null)
        {
            return;
        }

        if (animal != null)
        {
            return;
        }

        GameObject animalToSpawn = buildManager.GetAnimalToSpawn();
        animal = (GameObject)Instantiate(animalToSpawn, transform.position+positionOffset, rotationOffset);
    }

    private void OnMouseExit()
    {
        Rend.material.color = startColor;
    }
}
