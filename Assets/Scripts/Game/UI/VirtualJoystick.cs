using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField]
    Ship _ship;
    [SerializeField]
    private Image _imageBackground;
    [SerializeField]
    private Image _imageJoystick;
    [SerializeField]
    private float _visualDistance;

    private Vector3 _inputVector = Vector3.zero;
    public Vector3 InputVector
    {
        get
        {
            return _inputVector;
        }
    }


    public void OnPointerDown(PointerEventData e)
    {
        OnDrag(e);
    }

    public void OnDrag(PointerEventData e)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_imageBackground.rectTransform,
                                                                    e.position,
                                                                    e.pressEventCamera,
                                                                    out pos))
        {

            pos.x = (pos.x / _imageBackground.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _imageBackground.rectTransform.sizeDelta.y);
            Vector2 refPivot = new Vector2(0.5f, 0.5f);
            Vector2 p = _imageBackground.rectTransform.pivot;
            pos.x += p.x - 0.5f;
            pos.y += p.y - 0.5f;
            //_inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _imageJoystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * _visualDistance, _inputVector.y * _visualDistance);
        }
        _ship.MoveInput(_inputVector);
    }

    public void OnPointerUp(PointerEventData e)
    {
        _inputVector = Vector3.zero;
        _imageJoystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
