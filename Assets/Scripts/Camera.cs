using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    public Vector2 Offset;
    public Vector2 minBound, maxBound;
    private void LateUpdate()
    {
        if(Player.transform.position.x > minBound.x && Player.transform.position.x < maxBound.x /*&&
            Player.transform.position.y > minBound.y && Player.transform.position.y < maxBound.y*/)
        {
            transform.position = new Vector3(Player.position.x + Offset.x, Player.position.y + Offset.y, transform.position.z);
        }
    }
}