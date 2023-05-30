using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public event Action onCPTriggerSelected;
    public void CPTriggerSelected()
    {
        if (onCPTriggerSelected != null)
        {
            onCPTriggerSelected();
        }
    }
}
