using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] float scaleMultiplier = 0.1f;
    [SerializeField] float baseScale = 1f;

    void Update()
    {
        foreach (Transform child in transform)
        {
            float y = child.position.y;
            float scale = baseScale - (y * scaleMultiplier);
            scale = Mathf.Max(0.1f, scale);

            child.localScale = new Vector3(scale, scale, scale);
        }
    }
}
