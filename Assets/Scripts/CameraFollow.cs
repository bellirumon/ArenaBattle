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

        minX = arenaBounds.center.x - arenaBounds.extents.x;
        maxX = -minX;

        minY = arenaBounds.center.y - arenaBounds.extents.y;
        maxY = -minY;

    }


    void LateUpdate() 
    {
        //define the target position
        Vector3 targetPos = target.position + offset;

        //constraint the camera within the arena bounds
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        //smoothly move the camera towards the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, damping);
    }


}


