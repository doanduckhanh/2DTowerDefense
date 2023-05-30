using UnityEngine;

namespace Assets.Script.Common
{
    public class Common : MonoBehaviour
    {
        public static void showInterface(string interfaceName, GameObject parent, Transform position)
        {
            if (GameObject.Find("Interface"))
            {
                DisableOtherInterface();
            }
            Resources.Load("Interface/" + interfaceName);
            GameObject interface_ = Instantiate(Resources.Load("Interface/" + interfaceName), GameObject.Find("Out").transform.position, Quaternion.identity) as GameObject;
            interface_.name = "Interface";
            interface_.transform.SetParent(parent.transform);
            interface_.transform.position = new Vector3(position.transform.position.x, position.transform.position.y, position.transform.position.y - 3f); 
        }
        public static void DisableOtherInterface()
        {
            GameObject.Find("Interface").transform.parent.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            Destroy(GameObject.Find("Interface"));
        }
    }
}
