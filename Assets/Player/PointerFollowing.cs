using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollowing : MonoBehaviour
{
    public float angle;
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }
}
