using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBorders : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private BoxCollider2D _collider;

    private Bounds _cameraBounds;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _cameraBounds = OrthographicBounds(_camera);
        SetCollider();
    }
    public Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }

    private void SetCollider()
    {
        _collider.transform.position = _cameraBounds.center;
        _collider.size = _cameraBounds.extents * 2;
        _collider.offset = Vector2.zero;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TeleportObject(collision);
    }

    private void TeleportObject(Collider2D collision)
    {
        if (collision.attachedRigidbody.position.x > _collider.bounds.max.x)
        {
            collision.attachedRigidbody.MovePosition(new Vector2(_collider.bounds.min.x, collision.attachedRigidbody.position.y));
        }
        else if (collision.attachedRigidbody.position.y > _collider.bounds.max.y)
        {
            collision.attachedRigidbody.MovePosition(new Vector2(collision.attachedRigidbody.position.x, _collider.bounds.min.y));
        }
        else if (collision.attachedRigidbody.position.x < _collider.bounds.min.x)
        {
            collision.attachedRigidbody.MovePosition(new Vector2(_collider.bounds.max.x, collision.attachedRigidbody.position.y));
        }
        else if (collision.attachedRigidbody.position.y < _collider.bounds.min.y)
        {
            collision.attachedRigidbody.MovePosition(new Vector2(collision.attachedRigidbody.position.x, _collider.bounds.max.y));
        }
        else if (collision.attachedRigidbody.position.y > _collider.bounds.max.y && collision.attachedRigidbody.position.x > _collider.bounds.max.x)
        {
            collision.attachedRigidbody.MovePosition(_collider.bounds.min);
        }
        else if (collision.attachedRigidbody.position.y < _collider.bounds.min.y && collision.attachedRigidbody.position.x < _collider.bounds.min.x)
        {
            collision.attachedRigidbody.MovePosition(_collider.bounds.max);
        }
    }
}
