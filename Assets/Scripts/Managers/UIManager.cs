using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Static Singleton 

    public static UIManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Another instance of UIManager exists! Destroying this Instance");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion



    [SerializeField] Slider playerHpBar;


    public void SetPlayerHpBarToMax(int maxHp)
    {
        playerHpBar.maxValue = maxHp;
        playerHpBar.value = maxHp;
    }

    public void UpdatePlayerHpBar(int hp)
    {
        playerHpBar.value = hp;
    }




}
