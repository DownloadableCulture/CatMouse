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
            float scaleFactor = baseScale - (y * scaleMultiplier);
            scaleFactor = Mathf.Max(0.1f, scaleFactor);
           
            Vector3 baseLocalScale = child.localScale.normalized;
            child.localScale = baseLocalScale * scaleFactor;
        }
    }
}
