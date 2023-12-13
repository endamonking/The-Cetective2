using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
   private Vector3 offset = new Vector3(0f, 5f, -10f);
   private float smoothTime = 0.25f;
   private Vector3 velocity = Vector3.zero;
   [Header("Axis Limitation")]
   public Vector2 xlimit;
   public Vector2 ylimit;

   [SerializeField] private Transform target;


    // Update is called once per frame
    void Update()
    {
       Vector3 targetPosition = target.position + offset;
       targetPosition = new Vector3(Mathf.Clamp(targetPosition.x,xlimit.x,xlimit.y), Mathf.Clamp(targetPosition.y,ylimit.x,ylimit.y), -10);
       transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
