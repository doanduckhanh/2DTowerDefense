using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public static PathFinding main;

    public Transform startPoint;
    public Transform[] path;
    private void Awake()
    {
        main = this;
    }
}
