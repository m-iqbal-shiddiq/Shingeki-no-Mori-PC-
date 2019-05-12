using UnityEngine.EventSystems;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public GameObject animal;
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

    public Vector3 GetAnimalPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
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

        if (!buildManager.canBuild)
        {
            return;
        }

        if (animal != null)
        {
            return;
        }

        buildManager.SpawnAnimalOn(this);
    }

    private void OnMouseExit()
    {
        Rend.material.color = startColor;
    }
}
