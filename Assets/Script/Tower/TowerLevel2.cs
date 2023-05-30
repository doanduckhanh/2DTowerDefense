using Assets.Script.Tower;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLevel2 : Tower
{
    [SerializeField] private string towerName = "TowerLevel2";
    public string TowerName { get => towerName; set => towerName = value; }
    public string Price { get; set; }
    public string Range { get; set; }
    public string ShottingSpeed { get; set; }
    public void Initialize()
    {
        gameObject.name = towerName;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
