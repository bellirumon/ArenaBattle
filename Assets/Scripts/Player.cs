using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] int hp;
    public int Hp { get => hp; private set => hp = value; }

    [SerializeField] int moveSpeed;
    public int MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    Vector2 inputDir = Vector2.zero;
    Vector3 moveDir = Vector3.zero;

    float minX; float maxX;
    float minY; float maxY;

    float playerRadius;


    void Start()
    {
        //compute the bounds for the player
        Bounds arenaBounds = GlobalData.ArenaBounds;

        playerRadius = GetComponent<CircleCollider2D>().radius * transform.lossyScale.x;

        minX = (arenaBounds.center.x - arenaBounds.extents.x) + playerRadius;
        maxX = -minX;

        minY = (arenaBounds.center.y - arenaBounds.extents.y) + playerRadius;
        maxY = -minY;

    }


    void Update() 
    {
        GetPlayerInput();
        MovePlayer();
    }


    void GetPlayerInput() 
    {
        inputDir = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) {
            inputDir.y = 1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputDir.y = -1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputDir.x = 1f;
        }

        inputDir = inputDir.normalized;
    }


    void MovePlayer() 
    {
        moveDir = new(inputDir.x, inputDir.y, 0f);

        //constraint the player within set bounds 
        Vector3 newPosition = transform.position + (moveSpeed * Time.deltaTime * moveDir);

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }




}