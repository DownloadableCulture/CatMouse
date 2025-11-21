using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float speed = 3f;
    public float endPosition = -10;
    public float startPosition = 10;

    void Update()
    {
        foreach (Transform child in transform)
        {
            Scroll(child);
            ResetTrack(child);
            AdjustX(child);
        }
    }

    void Scroll(Transform t)
    {
        t.position += Vector3.down * speed * Time.deltaTime;
    }

    void ResetTrack(Transform t)
    {
        if (t.position.y <= endPosition)
        {
            t.position = new Vector3(t.position.x, startPosition, t.position.z);
        }
    }
    void AdjustX(Transform child)
    {
        float yStart = 5f;
        float xStart = 2f;
        float slope = -0.2f;

        float x = xStart + (child.position.y - yStart) * slope;
        child.position = new Vector3(x, child.position.y, child.position.z);
    }

}