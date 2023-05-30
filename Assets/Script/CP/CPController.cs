using Assets.Script.Common;
using System.Collections;
using UnityEngine;

public class CPController : MonoBehaviour
{
    private bool clicked = false;
    private bool mouseIsOver = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.name = "CP";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseIsOver == true)
        {
            Common.showInterface(this.gameObject.name, this.gameObject, this.gameObject.transform);
            GetComponent<CircleCollider2D>().enabled = false;

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
}
