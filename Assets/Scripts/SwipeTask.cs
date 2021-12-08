using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTask : MonoBehaviour
{
    public GameObject self;
    public List<SwipePoint> _swipePoints = new List<SwipePoint>();
    public float _countdownMax = 0.5f;
    public GameObject _greenOn;
    private int _currentSwipePointIndex = 0;
    private float _countdown = 0;

    private void Update()
    {
        _countdown -= Time.deltaTime;

        if (_currentSwipePointIndex != 0 && _countdown <= 0)
        {
            _currentSwipePointIndex = 0;
            StartCoroutine(FinishTask(false));
        }
    }
    private IEnumerator FinishTask(bool wasSuccessful)
    {
        if (wasSuccessful)
        {
            _greenOn.SetActive(true);
        }
        else
        {

        }

        yield return new WaitForSeconds(1.5f);
        Destroy(self);
    }
    public void SwipePointTrigger(SwipePoint swipePoint)
    {
        if (swipePoint == _swipePoints[_currentSwipePointIndex])
        {
            _currentSwipePointIndex++;
            _countdown = _countdownMax;
            print("fial");
        }
        if (_currentSwipePointIndex >= _swipePoints.Count)
        {
            _currentSwipePointIndex = 0;
            StartCoroutine(FinishTask(true));
            print("Complete");
        }
    }
}