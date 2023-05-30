using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Tower
{
    public class Tower : MonoBehaviour, ITower
    {
        public string TowerName { get ; set; }
        public string Price { get; set; }
        public string Range { get; set; }
        public string ShottingSpeed { get; set; }

        public void Initialize()
        {
        }
    }
}
