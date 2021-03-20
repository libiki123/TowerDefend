using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager share;

    private TurretBlueprints turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private void Awake()
    {
        share = this;
    }

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprints turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SelectTargetNode(selectedNode);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprints getTurretToBuild()
    {
        return turretToBuild;
    }
}
