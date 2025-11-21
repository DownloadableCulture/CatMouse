using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    [SerializeField] float speed = 3f;

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
        if (t.position.y <= -10)
        {
            t.position = new Vector3(t.position.x, 10, t.position.z);
        }
    }
}