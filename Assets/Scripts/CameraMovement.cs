using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void Update()
    {
        Vector3 pos = player.position + offset;
        Vector3 lerping = Vector3.Lerp(transform.position, pos, 0.12f);
        transform.position = lerping;
    }
}
