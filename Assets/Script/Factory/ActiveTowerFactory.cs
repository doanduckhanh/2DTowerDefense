using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveTowerFactory : TowerFactory
{
    [SerializeField]
    private TowerLevel1 towerLv1Prefab;
    [SerializeField]
    private TowerLevel2 towerLv2Prefab;
    [SerializeField]
    private TowerLevel3 towerLv3Prefab;
    public override ITower CreateTower(int towerLevel, Vector3 position)
    {
        GameObject instance;
        switch (towerLevel)
        {
            case 1:
                instance = Instantiate(towerLv1Prefab.gameObject, position, Quaternion.identity);
                TowerLevel1 newTowerLv1 = instance.GetComponent<TowerLevel1>();
                newTowerLv1.Initialize();
                return newTowerLv1;
            case 2:
                instance = Instantiate(towerLv2Prefab.gameObject, position, Quaternion.identity);
                TowerLevel2 newTowerLv2 = instance.GetComponent<TowerLevel2>();
                newTowerLv2.Initialize();
                return newTowerLv2;
            case 3:
                instance = Instantiate(towerLv3Prefab.gameObject, position, Quaternion.identity);
                TowerLevel3 newTowerLv3 = instance.GetComponent<TowerLevel3>();
                newTowerLv3.Initialize();
                return newTowerLv3;
            default:
                return null;
        }
    }
}
