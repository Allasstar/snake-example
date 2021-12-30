using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovementSystem : MonoBehaviour
{
    [Tooltip("Time for move to next cell")]
    [SerializeField] private float _timePerCell = 0.1f;

    [SerializeField] private List<SpriteRenderer> _snakeParts;

    private Vector3 _direction;
    private bool _isPlay = true;
    
    private void Awake()
    {
        Signals.GameOverTrigger += GameOverTrigger;
        Signals.FoodPickUpTrigger += AddSnakeSegment;
        
        _direction = Vector3.up;
        
        _snakeParts.AddRange(GetComponentsInChildren<SpriteRenderer>());
        
        if (_snakeParts.Count == 0)
            Debug.LogException(new Exception("Missing snake parts"));

        StartCoroutine(MoveCycle());
    }

    private void OnDestroy()
    {
        Signals.GameOverTrigger -= GameOverTrigger;
        Signals.FoodPickUpTrigger -= AddSnakeSegment;
    }

    private void GameOverTrigger()
    {
        _isPlay = false;
    }

    private void Update()
    {
        var v = GetDirection();
        if (!IsValidDirection(v)) return;
        _direction = v;
    }

    private bool IsValidDirection(Vector3 v)
    {
        return Vector3.Dot(_direction, v) == 0 && !v.Equals(Vector3.zero);
    }

    private static Vector3 GetDirection()
    {
        var v = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            v.x = -1;
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            v.y = 1;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            v.x = 1;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            v.y = -1;
        return v;
    }

    private IEnumerator MoveCycle() 
    {
        while(_isPlay)
        {
            yield return new WaitForSeconds(_timePerCell);
            Move();
        }
    }

    private void Move()
    {
        if (!_isPlay) return;
        for (var i = _snakeParts.Count - 1; i > 0; i--)
        {
            _snakeParts[i].transform.position = _snakeParts[i - 1].transform.position;
        }
        
        _snakeParts[0].transform.position += _direction;
    }
    
    private void AddSnakeSegment()
    {
        var last = _snakeParts[^1];
        SpriteRenderer newSnakeSegment = Instantiate(last, last.transform.position, Quaternion.identity);
        newSnakeSegment.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.60f, 0.70f);
        _snakeParts.Add(newSnakeSegment);
    }
}
