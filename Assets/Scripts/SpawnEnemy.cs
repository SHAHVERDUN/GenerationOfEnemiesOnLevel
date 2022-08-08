using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private Transform _spawnPath;

    private List<Transform> _spawnPoints;

    private const bool _loopCycle = true;

    private int _currnetPoint;

    private void Start()
    {
        _spawnPath = GetComponent<Transform>();

        _spawnPoints = new List<Transform>(_spawnPath.childCount);

        foreach (Transform point in _spawnPath)
        {
            _spawnPoints.Add(point);
        }

        _currnetPoint = 0;

        StartCoroutine(CoroutineCreateEnemy());
    }

    private IEnumerator CoroutineCreateEnemy()
    {
        var waitForTwoSeconds = new WaitForSeconds(2);

        while (_loopCycle == true)
        {
            Instantiate(_enemyPrefab, _spawnPoints[_currnetPoint].position, Quaternion.identity);

            if (_currnetPoint < _spawnPoints.Count - 1)
            {
                _currnetPoint++;
            }
            else
            {
                _currnetPoint = 0;
            }


            yield return waitForTwoSeconds;
        }
    }
}