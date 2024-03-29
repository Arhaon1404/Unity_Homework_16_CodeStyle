using UnityEngine;

public class PlaceChanger : MonoBehaviour
{
    [SerializeField] private Transform _pointsPlaces;
    [SerializeField] private float _speed;
    private Transform[] _arrayPlaces;

    private int _placeNumber;
    
    private void Start()
    {
        _arrayPlaces = new Transform[_pointsPlaces.childCount];

        for (int i = 0; i < _pointsPlaces.childCount; i++)
            _arrayPlaces[i] = _pointsPlaces.GetChild(i);
    }

    private void Update()
    {
        var arrayPoint = _arrayPlaces[_placeNumber];

        transform.position = Vector3.MoveTowards(transform.position, arrayPoint.position, _speed * Time.deltaTime);

        if (transform.position == arrayPoint.position) 
            NextPlace();
    }

    private void NextPlace()
    {
        _placeNumber++;
        _placeNumber = _placeNumber % _arrayPlaces.Length;

        var pointVector = _arrayPlaces[_placeNumber].transform.position;
        transform.forward = pointVector - transform.position;
    }
}