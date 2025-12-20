using UnityEngine;

public class PuzzlePieceUV : MonoBehaviour
{
    public int col; 
    public int row; 
    public int gridSize = 3;

    void Start()
    {
        var r = GetComponent<Renderer>();
        r.material = new Material(r.material); // unique material per piece

        float size = 1f / gridSize;

        r.material.mainTextureScale = new Vector2(size, size);

        // Note: texture V goes bottom->top, so flip row if needed
        r.material.mainTextureOffset = new Vector2(col * size, row * size);
    }
}
