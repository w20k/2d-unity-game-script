
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float bottomY;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;


    void Update(){
       if(transform.position.y < bottomY){
          transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
       }
        if(target == null){
           Vector3 desiredPosition = new Vector3(transform.position.x, 2, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
  }
    void FixedUpdate()
    {   if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
         
    }
}
