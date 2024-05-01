using UnityEngine.UI;
using UnityEngine;

public class MovingBackgoundHudViewModel : MonoBehaviour
{

    [Space]
    [SerializeField]
    private RawImage _rawImage;

    [SerializeField, Range(0, 10)]
    private float _scrollSpeed = 0.1f;

    [SerializeField, Range(-1, 1)]
    private float _xDirection = 1f;

    [SerializeField, Range(-1, 1)]
    private float _yDirection = 1f;

    public float ScrollSpeed { get; set; }
    public Vector2 MoveDirection { get; set; }
    public RawImage RawImage { get; set; }

    public bool EnableMove { get; set; }

    private void Awake()
    {
        SetData();
    }

    private void Update()
    {
        if (EnableMove)
        {
            var offset = MoveDirection * ScrollSpeed * Time.deltaTime;

            RawImage.uvRect = new Rect(RawImage.uvRect.position + offset, RawImage.uvRect.size);
        }
    }

    private void SetData()
    {
        RawImage = _rawImage;
        ScrollSpeed = _scrollSpeed;
        MoveDirection = new Vector2(_xDirection, _yDirection);
        EnableMove = true;
    }
}
