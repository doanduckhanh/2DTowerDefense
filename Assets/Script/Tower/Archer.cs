using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Archer : Tower
{
    [SerializeField]
    private string towerName;
    [SerializeField]
    private int price;
    [SerializeField]
    private decimal range;
    [SerializeField]
    private decimal shottingSpeed;
    [SerializeField]
    private int towerLevel;

    public string TowerName { get => towerName; set => towerName = value; }
    public int Price { get => price; set => price = value; }
    public decimal Range { get => range; set=> range = value; }
    public decimal ShottingSpeed { get => shottingSpeed; set=> shottingSpeed = value; }
    public int TowerLevel { get => towerLevel; set=> towerLevel = value; }

    SelectTowerEvent selectEvent = new SelectTowerEvent();
    public void Initialize()
    {
        gameObject.name = towerName;
        transform.Find("SelectCircle").gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectEventManager.AddSelectArcherTowerEventInvoker(this);
    }
    public void AddSelectCPEventListener(UnityAction<GameObject, int> listener)
    {
        selectEvent.AddListener(listener);
    }
    void OnMouseDown()
    {
        if (GameObject.Find("SelectCircle"))
        {
            GameObject.Find("SelectCircle").gameObject.SetActive(false);
        }
        transform.Find("SelectCircle").gameObject.SetActive(true);
        selectEvent.Invoke(this.gameObject, TowerLevel);
    }
}
