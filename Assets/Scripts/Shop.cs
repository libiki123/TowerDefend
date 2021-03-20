using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprints standardTurret;
    public TurretBlueprints missileLauncher;
    public TurretBlueprints lazerBeam;

    public void SelectStandardTurret()
    {
        BuildManager.share.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        BuildManager.share.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLazerBeam()
    {
        BuildManager.share.SelectTurretToBuild(lazerBeam);
    }
}
