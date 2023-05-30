using UnityEngine;

public abstract class TowerFactory : MonoBehaviour
{
    public abstract ITower CreateTower(int towerLevel, Vector3 position);
}
