using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] float _speed;

    private RawImage _image;
    private float _imagePosX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    
    private void Update()
    {
        
        _imagePosX += _speed * Time.deltaTime;
        if (_imagePosX > 1)
        {
            _imagePosX = 0;
        }
        _image.uvRect = new Rect(_imagePosX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
