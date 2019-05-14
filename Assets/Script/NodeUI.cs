using System.Collections;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Nodes target;

    //milih node
    public void SetTarget(Nodes _target)
    {
        target= _target;

        transform.position = target.GetAnimalPosition();

        ui.SetActive(true);
    }

    //hide panel  
    public void Hide()
    {
        ui.SetActive(false);
    }
}
