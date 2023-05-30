using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnClickCPInterface : MonoBehaviour
{
    private bool mouseIsOver = false;
    [SerializeField] TowerFactory[] factories;
    private TowerFactory factory;
    // Start is called before the first frame update
    void Start()
    {
        factory = factories[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseIsOver == true)
        {
            createTowerLevel1();
        }
    }
    void OnMouseOver()
    {
        //if (!GameObject.Find("hand")) { Common.showHand(true); }
        mouseIsOver = true;
    }
    void OnMouseExit()
    {
        //if (GameObject.Find("hand")) { Common.showHand(false); }
        mouseIsOver = false;
    }
    void createTowerLevel1()
    {
        InstantiateTower();
        Invoke("onDestroy", 0);
    }
    private void onDestroy()
    {
        Destroy(this.gameObject.transform.parent.gameObject);
        Destroy(this.gameObject.transform.parent.transform.parent.gameObject);
    }
    void InstantiateTower()
    {
        Debug.Log("Create tower level 1");
        Vector3 cpos = this.gameObject.transform.parent.transform.parent.gameObject.transform.position;
        cpos.y = cpos.y + 0.1f;
        ITower tower = factory.CreateTower(1, cpos);
    }
}
