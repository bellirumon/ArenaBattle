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

    [SerializeField] GameObject attackRegion;
    [SerializeField] float attackDuration;
    [SerializeField] float attackInterval;

    Vector3 attackRegion_MaxScale;


    Vector2 inputDir = Vector2.zero;
    Vector3 moveDir = Vector3.zero;

    float minX, maxX, minY, maxY;

    float playerRadius;


    void Start()
    {
        //set the hp to maxHp
        Hp = maxHp;
        UIManager.Instance.SetPlayerHpBarToMax(maxHp);

        //compute the bounds for the player
        Bounds arenaBounds = GlobalData.ArenaBounds;

        playerRadius = GetComponent<CircleCollider2D>().radius * transform.lossyScale.x;

        minX = arenaBounds.min.x + playerRadius;
        maxX = -minX;

        minY = arenaBounds.min.y + playerRadius;
        maxY = -minY;

        attackRegion_MaxScale = attackRegion.transform.localScale;

        InvokeRepeating(nameof(DoAttack), 1f, attackInterval);
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


    void DoAttack()
    {
        //animate the attack region 
        StartCoroutine(PlayAttackAnim());
    }


    IEnumerator PlayAttackAnim()
    {
        //set attack region scale to 0 before starting anim
        attackRegion.transform.localScale = Vector3.zero;

        //the anim lerps the scale from 0 to max
        float elapsedTime = 0f;

        while (elapsedTime < attackDuration)
        {
            elapsedTime += Time.deltaTime;

            attackRegion.transform.localScale = Vector3.Lerp(Vector3.zero, attackRegion_MaxScale, elapsedTime/attackDuration);

            yield return null;
        }

        //set attack region scale to 0 after anim ends
        attackRegion.transform.localScale = Vector3.zero;

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("DMG");
        }    
    }


}