using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    private Node target;

    public Button upgradeButton;
    public Text upgradeCost;

    public Text sellPrice;

    public void SelectTargetNode(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();


        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Max";
            upgradeButton.interactable = false;
        }

        sellPrice.text = "$" + target.turretBlueprint.GetSellAmount().ToString();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.share.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.share.DeselectNode();
    }
}
