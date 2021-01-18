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
        objectPosition.x = Mathf.Clamp(objectPosition.x, screenOrigin.x*0.7f, screenBounds.x*1.15f);
        objectPosition.z = Mathf.Clamp(objectPosition.z, screenOrigin.z*0.9f, screenBounds.z*1.1f);
        transform.position = objectPosition;
    }

    private void Update()
    {
        if(transform.position.x <= screenOrigin.x || transform.position.x >= screenBounds.x)
        {
        }
    }
}
