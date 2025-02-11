using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] int maxHp;
    [SerializeField] int hp;
    public int Hp 
    { 
        get => hp;
        private set
        {
            hp = value;
            UIManager.Instance.UpdatePlayerHpBar(hp);
        }
    }

    [SerializeField] int moveSpeed;
    public int MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField] CircleCollider2D playerBody;

    Vector2 inputDir = Vector2.zero;
    Vector3 moveDir = Vector3.zero;

    float minX, maxX, minY, maxY;


    void Start()
    {
        //set the hp to maxHp
        Hp = maxHp;
        UIManager.Instance.SetPlayerHpBarToMax(maxHp);

        //compute the bounds for the player
        Bounds arenaBounds = GlobalData.ArenaBounds;

        float playerRadius = playerBody.radius * playerBody.transform.lossyScale.x;

        minX = arenaBounds.min.x + playerRadius;
        maxX = -minX;

        minY = arenaBounds.min.y + playerRadius;
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


    public void TakeDamage(int dmg)
    {
        Hp -= dmg;

        if (Hp <= 0)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }


    public void Heal(int heal)
    {
        if (Hp < maxHp)
        {
            Hp += heal;
        }
    }

    
    public void SpeedUp(int speedIncrement)
    {
        MoveSpeed += speedIncrement;
    }

}