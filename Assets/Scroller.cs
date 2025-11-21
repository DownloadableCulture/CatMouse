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
    
        }
    }

    void Scroll(Transform t)
    {
        float yStart = 5f;
        float xStart = 2f;
        float slope = -0.2f;

        t.position += Vector3.down * speed * Time.deltaTime;

        float x = xStart + (t.position.y - yStart) * slope;
        t.position = new Vector3(x, t.position.y, t.position.z);
    }

    void ResetTrack(Transform t)
    {
        if (t.position.y <= endPosition)
        {
            t.position = new Vector3(t.position.x, startPosition, t.position.z);
        }
    }


}