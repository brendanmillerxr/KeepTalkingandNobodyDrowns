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

    public GameObject startMenuPanel;
    public GameObject gameplayPanel;
    public GameObject endPanel;

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
        startMenuPanel.SetActive(true);
        gameplayPanel.SetActive(false);
        endPanel.SetActive(false);
    }
    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        gameplayPanel.SetActive(true);
        endPanel.SetActive(false);
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
        gameplayPanel.SetActive(false);
        endPanel.SetActive(true);
    }
}
    