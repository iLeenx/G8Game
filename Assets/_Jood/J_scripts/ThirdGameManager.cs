using UnityEngine;
using TMPro;

public class ThirdGameManager : MonoBehaviour
{
    public static ThirdGameManager Instance;

    [Header("Puzzle Pieces")]
    public int totalPieces = 5;
    public int collectedPieces = 0;

    [Header("UI")]
    public TextMeshProUGUI counterText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateCounter();
    }

    public void CollectPiece()
    {
        collectedPieces++;
        UpdateCounter();
    }

    public bool HasAllPieces()
    {
        return collectedPieces >= totalPieces;
    }

    void UpdateCounter()
    {
        if (counterText != null)
            counterText.text = $"Pieces: {collectedPieces}/{totalPieces}";
    }
}
