using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    [SerializeField] Arena arena;

    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float damping;

    Vector3 currentVelocity = Vector3.zero;

    float minX; float minY;
    float maxX; float maxY;


    void Start()
    {
        //define the min and max bounds for the camera
        Bounds arenaBounds = arena.GetArenaBounds();

        Debug.Log(arenaBounds.center);
        Debug.Log(arenaBounds.extents);

    }


    void LateUpdate() 
    {
        //define the target position
        Vector3 targetPos = target.position + offset;

        //smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, damping);
    }


}


