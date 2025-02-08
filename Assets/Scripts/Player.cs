using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] int hp;
    public int Hp { get => hp; private set => hp = value; }

    [SerializeField] int moveSpeed;
    public int MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }


    Vector2 inputDir = Vector2.zero;
    Vector3 moveDir = Vector3.zero;


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

        transform.position += moveSpeed * Time.deltaTime * moveDir;
    }




}