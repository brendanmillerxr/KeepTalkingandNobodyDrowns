using UnityEngine;
using UnityEngine.UI;  // For UI Image references

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Lives")]
    public int maxLives = 3;
    public int currentLives;

    [Header("UI Elements")]
    public Image[] lifeIcons;  // Array to hold references to life icons
    public Sprite fullLifeSprite;
    public Sprite emptyLifeSprite;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        currentLives--;
        currentLives = Mathf.Clamp(currentLives, 0, maxLives);
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    // public void GainLife()
    // {
    //     if (currentLives < maxLives)
    //     {
    //         currentLives++;
    //         UpdateLivesUI();
    //     }
    // }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < currentLives)
                lifeIcons[i].sprite = fullLifeSprite;
            else
                lifeIcons[i].sprite = emptyLifeSprite;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        // Add your game over logic here
        }
}
    