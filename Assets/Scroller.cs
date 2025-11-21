using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    [Range(0f, 20f)]
    [SerializeField] float speed = 3f;

    public float startPosition = 10f;
    public float endPosition = -10f;
    public float yTop = 5f;
    public float yBottom = -5f;

    public bool randomizeXOnReset = true;
    public float xRandomMin = -2f;
    public float xRandomMax = 2f;

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
            ResetChild(child, index);

        ApplyLinearXScaling(child, index);
    }

    void ResetChild(Transform child, int index)
    {
        if (randomizeXOnReset)
            RandomizeX(child, index);
        else
            child.position = new Vector3(originalX[index], startPosition, child.position.z);
    }

    void RandomizeX(Transform child, int index)
    {
        float randomX = Random.Range(xRandomMin, xRandomMax);
        child.position = new Vector3(randomX, startPosition, child.position.z);
        originalX[index] = randomX;
    }

    void ApplyLinearXScaling(Transform child, int index)
    {
        if (child.position.y <= yTop && child.position.y >= yBottom)
        {
            float t = (child.position.y - yTop) / (yBottom - yTop);
            float factor = 1f + t;
            float newX = originalX[index] * factor;
            child.position = new Vector3(newX, child.position.y, child.position.z);
        }
    }
}
