using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] SpriteRenderer track;

    float spriteHeight;

    private void Start()
    {
        spriteHeight = track.bounds.size.y;
    }
    void Update()
    {
        Scroll();
        ResetTrack();
    }

    void ResetTrack()
    {
        if (transform.position.y <= -spriteHeight/3)
        {
            transform.position = new Vector3(transform.position.x, spriteHeight/3, transform.position.z);
        }

    }

    void Scroll()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}