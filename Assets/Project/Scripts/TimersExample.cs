using System;
using UnityEngine;

namespace Project.Scripts
{
    public class TimersExample : MonoBehaviour
    {
        [SerializeField] private SliderTimerService _sliderTimerService;
        [SerializeField] private HeartsTimerService _heartsTimerService;
        
        private TimerService _currentTimerService;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _currentTimerService = _sliderTimerService;
                Debug.Log("Slider Timer Selected");
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentTimerService = _heartsTimerService;
                Debug.Log("Hearts Timer Selected");
            }
            
            if (_currentTimerService == null)
                return;
            
            if (Input.GetKeyDown(KeyCode.S) && _currentTimerService.IsTimerRunning() == false)
                _currentTimerService.StartTimer();
            
            if (Input.GetKeyDown(KeyCode.P) && _currentTimerService.IsTimerRunning())
                _currentTimerService.PauseTimer();
            
            if (Input.GetKeyDown(KeyCode.C) && _currentTimerService.IsTimerPaused())
                _currentTimerService.ContinueTimer();
            
            if (Input.GetKeyDown(KeyCode.R))
                _currentTimerService.ResetTimer();
                
        }
    }
}
