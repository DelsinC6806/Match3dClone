using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingScript : MonoBehaviour
{
    GameObject first;
    GameObject second;
    public Transform point1;
    public Transform point2;
    Vector3 offset = new Vector3(0, 1f, 0);

    void Update()
    {
        if (DragNDrop.target != null)
        {
            if (Vector3.Distance(DragNDrop.target.transform.position, this.transform.position) <= 4)
            {
                if (first == null)
                {
                    first = DragNDrop.target;
                    first.transform.position = point1.position+offset;
                    first.GetComponent<Rigidbody>().isKinematic = true;
                    first.transform.rotation = Quaternion.Slerp(first.transform.rotation, Quaternion.EulerAngles(Vector3.zero),1f);
                    DragNDrop.target = null;
                }
                else if (first != null && second == null)
                {
                    second = DragNDrop.target;
                    second.GetComponent<Rigidbody>().isKinematic = true;
                    second.transform.position = point2.position+offset;
                }
                else
                {
                    if (first.GetComponent<MeshFilter>().name == second.GetComponent<MeshFilter>().name)
                    {
                        Destroy(first);
                        Destroy(second);
                        first = null;
                        second = null;
                        ScoreScript.instance.addScore();
                    }
                    else
                    {
                        second.GetComponent<Rigidbody>().isKinematic = false;
                        second.GetComponent<Rigidbody>().AddForce(2000f * transform.forward);
                        second = null;
                        DragNDrop.target = null;
                    }
                }
            }
            else if (Vector3.Distance(point1.position,first.transform.position) >= 2 && first != null)
            {
                first.GetComponent<Rigidbody>().isKinematic = false;
                first = null;
               
            }
            else if (Vector3.Distance(point2.position, second.transform.position) >= 2 && second != null)
            {
                second.GetComponent<Rigidbody>().isKinematic = false;
                second = null;
            }
        }
    }
}
