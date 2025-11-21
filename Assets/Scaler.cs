using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] TrackScroller scroller;
    [SerializeField] float minScale = 0.7f;
    [SerializeField] float maxScale = 1.3f;

    Vector3[] originalScales;

    void Awake()
    {
        if( scroller == null)
        {
            scroller = GetComponent<TrackScroller>();
        }
    }

    void Start()
    {
        GetOriginalScale();
    }

    void Update()
    {
        ScaleObject();
    }

    void GetOriginalScale()
    {
        originalScales = new Vector3[transform.childCount];
        int i = 0;

        foreach (Transform child in transform)
            originalScales[i++] = child.localScale;
    }

    void ScaleObject()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            float y = child.position.y;
            float scaleFactor = minScale + ((maxScale - minScale) * (scroller.startPosition - y) / (scroller.startPosition - scroller.endPosition));
            child.localScale = originalScales[i++] * scaleFactor;
        }
    }

}
