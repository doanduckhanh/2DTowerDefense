using Assets.Script.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Tower : MonoBehaviour, ITower
{
    public string TowerName { get; set; }
    public int Price { get; set; }
    public decimal Range { get; set; }
    public decimal ShottingSpeed { get; set; }
    public int TowerLevel { get; set; }

    public void Initialize()
    {
    }
    void Update()
    {
    }
    void OnMouseDown()
    {
    }
}

