
using System.Collections;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public static GameObject target;
    public static bool isMouseDragging;
    bool isDragUp = false;
    Vector2 screenMin = new Vector2(28, 5);
    Vector2 screenMax = new Vector2(72, 25);
    Vector3 screenPosition;
    Vector3 offset;

    void Update()
    {
        if(target != null)
        {
            Debug.Log(target.name);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            
            if (ReturnClickedObject(out hitInfo).tag == "draggable")
            {
                target = ReturnClickedObject(out hitInfo);
                isMouseDragging = true;
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
        isMouseDragging = false;
        isDragUp = false;
        }

        if (isMouseDragging)
        {
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
            currentPosition.x = Mathf.Clamp(currentPosition.x,screenMin.x,screenMax.x);
            currentPosition.y = Mathf.Clamp(currentPosition.y, 10, 10);
            currentPosition.z = Mathf.Clamp(currentPosition.z,screenMin.y,screenMax.y);
            target.transform.position = currentPosition;
        }
    }


    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject targetObject = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            targetObject = hit.collider.gameObject;
        }
        return targetObject;
    }
}