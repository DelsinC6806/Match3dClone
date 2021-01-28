using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampItemScript : MonoBehaviour
{
    private Vector3 screenBounds;
    private Vector3 screenOrigin;
    private float objectWidth;
    private float objectHeight;
    Vector3 offset = Vector3.one;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane / 2));
        screenOrigin = Camera.main.ScreenToWorldPoint(new Vector3(0,0, Camera.main.farClipPlane / 2));
    }

    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(objectPosition.x, screenOrigin.x*0.75f, screenBounds.x*1.10f);
        objectPosition.z = Mathf.Clamp(objectPosition.z, screenOrigin.z*0.65f, screenBounds.z*1.05f);
        objectPosition.y = Mathf.Clamp(objectPosition.y,-5, 15);
        transform.position = objectPosition;

        if(transform.position.y >= 15)
        {
            var newVelocity = GetComponent<Rigidbody>().velocity;
            newVelocity.y = 0;
            GetComponent<Rigidbody>().velocity = newVelocity;
        }
    }
}
