using System;
using UnityEngine;

namespace Project.Scripts
{
    public class TimersExample : MonoBehaviour
    {
        [SerializeField] private SliderTimerView _sliderTimerView;
        [SerializeField] private HeartsTimerView _heartsTimerView;
        
        private CustomTimer _currentTimer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _currentTimer = _sliderTimerView.CustomTimer;
                Debug.Log("Slider Timer Selected");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentTimer = _heartsTimerView.CustomTimer;
                Debug.Log("Hearts Timer Selected");
            }
            
            if (_currentTimer == null)
                return;
            
            if (Input.GetKeyDown(KeyCode.S) && _currentTimer.IsRunning == false)
                _currentTimer.Start();
            
            if (Input.GetKeyDown(KeyCode.P) && _currentTimer.IsRunning)
                _currentTimer.Pause();
            
            if (Input.GetKeyDown(KeyCode.C) && _currentTimer.IsTimerPaused())
                _currentTimer.Continue();
            
            if (Input.GetKeyDown(KeyCode.R))
                _currentTimer.Reset();
            
            _sliderTimerView.UpdateView();
            _heartsTimerView.UpdateView();
        }
    }
}
