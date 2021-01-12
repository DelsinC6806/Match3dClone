using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampItemScript : MonoBehaviour
{
    Vector2 screenMin = new Vector2(28, 5);
    Vector2 screenMax = new Vector2(72, 25);
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenMin.x, screenMax.x);
        pos.z = Mathf.Clamp(pos.z, screenMin.y, screenMax.y);
        transform.position = pos;
    }
}
