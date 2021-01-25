using System.Collections;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public static GameObject target;
    public static bool isMouseDragging;
    Vector3 screenPosition;
    Vector3 offset;
    float height = 8f;
    float speed = 150f;
    float force = 500;
    public GameObject terrain;
    Ray ray;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            if (ReturnClickedObject(out hitInfo).tag == "draggable")
            {
                target = ReturnClickedObject(out hitInfo);
                isMouseDragging = true;

                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                
            }
            else
            {
                target = null;
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseDragging = false;
            if (target != null)
            {
                Vector3 currentSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPosition.z-10);
                Vector3 currentPos = Camera.main.ScreenToWorldPoint(currentSpace);
                var dir = currentPos - target.transform.position;
                target.GetComponent<Rigidbody>().AddForce(dir * force);
            }
        }


        if (isMouseDragging)
        {
        
            target.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z-10);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace);
            
            target.transform.position = Vector3.MoveTowards(target.transform.position, currentPosition, speed * Time.deltaTime);
        }


        GameObject ReturnClickedObject(out RaycastHit hit)
        {
            GameObject targetObject = null;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
            {
                targetObject = hit.transform.gameObject;
            }
            return targetObject;
        }
    }
}