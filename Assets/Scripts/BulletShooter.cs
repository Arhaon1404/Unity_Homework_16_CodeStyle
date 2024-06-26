using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Transform ObjectToShoot;
    
    private WaitForSeconds _sleepTime;

    private void Start()
    {
        StartCoroutine(Shoot());
        _sleepTime = new WaitForSeconds(_shootDelay);
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            var direction = (ObjectToShoot.position - transform.position).normalized;
            var bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            bullet.SetDirection(direction,_speed);

            yield return _sleepTime;
        }
    }
}