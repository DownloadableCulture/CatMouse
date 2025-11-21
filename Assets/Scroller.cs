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
        t.position += Vector3.down * speed * Time.deltaTime;
    }

    void ResetTrack(Transform t)
    {
        if (t.position.y <= endPosition)
        {
            t.position = new Vector3(t.position.x, startPosition, t.position.z);
        }
    }
}