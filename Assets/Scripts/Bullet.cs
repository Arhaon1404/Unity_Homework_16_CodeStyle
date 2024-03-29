using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction,float speed)
    {
        transform.up = direction;
        _rigidbody.velocity = direction * speed;
    }
}
