using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Nodes target;

    public Text upgraedCost;

    public Button upgradeButton;

    //milih node
    public void SetTarget(Nodes _target)
    {
        target= _target;

        transform.position = target.GetAnimalPosition();

        if (!target.isUpgraded)
        {
            upgraedCost.text = target.animalBlueprint.upgradeCost + "G";
            upgradeButton.interactable = true;
        } else
        {
            upgraedCost.text = "OK";
            upgradeButton.interactable = false;
        }

        ui.SetActive(true);

    }

    //hide panel  
    public void Hide()
    {
        ui.SetActive(false);
    }

    //upgrade animal
    public void Upgrade()
    {
        target.UpgradeAnimal();
        BuildManager.instance.DeselectNode();
    }
}
