using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float speed = 3f;

    public float startPosition = 10f;
    public float endPosition = -10f;

    float[] originalX;

    void Start()
    {
        int count = transform.childCount;
        originalX = new float[count];

        for (int i = 0; i < count; i++)
            originalX[i] = transform.GetChild(i).position.x;
    }

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ScrollChild(transform.GetChild(i), i);
        }
    }

    void ScrollChild(Transform child, int index)
    {
        child.position += Vector3.down * speed * Time.deltaTime;

        if (child.position.y <= endPosition)
            child.position = new Vector3(originalX[index], startPosition, child.position.z);

        float yTop = 5f;
        float yBottom = -5f;

        if (child.position.y <= yTop && child.position.y >= yBottom)
        {
            float t = (child.position.y - yTop) / (yBottom - yTop);
            float factor = 1f + t; 
            float newX = originalX[index] * factor;
            child.position = new Vector3(newX, child.position.y, child.position.z);
        }
    }
}
