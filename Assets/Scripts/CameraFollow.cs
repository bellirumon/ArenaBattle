using UnityEngine;

public class CameraFollow : MonoBehaviour 
{

    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float damping;

    Vector3 currentVelocity = Vector3.zero;

    float camWidth, camHeight; 

    float minX, minY, maxX, maxY;


    void Start()
    {
        //get the camera width and height
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        //define the min and max bounds for the camera
        Bounds arenaBounds = GlobalData.ArenaBounds;

        minX = arenaBounds.min.x + camWidth;
        maxX = -minX;

        minY = arenaBounds.min.y + camHeight;
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


