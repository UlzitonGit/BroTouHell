using System.Collections;
using System.Threading;
using UnityEngine;

public class TimeDilation : MonoBehaviour
{
    [SerializeField] private float _timeDilationDuration;
    [SerializeField] private float _timeScaleDefault;
    [SerializeField] private float _timeScaleDuringDuration;
    private bool _isActive = false;
    private float _currentTimer = 0;

    private void Start()
    {
        Application.targetFrameRate = 120;
        Time.timeScale = _timeScaleDefault;
    }
    private void Update()
    {
        if (_isActive)
        {
            Delay();
        }
    }

    public void StartDilation()
    {
        _isActive = true;
    }
    public void Delay()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _timeDilationDuration)
        {
            Time.timeScale = _timeScaleDefault;
            _currentTimer = 0;
            _isActive = false;
        }
        else
        {
            Time.timeScale = _timeScaleDuringDuration;
        }
    }
}
