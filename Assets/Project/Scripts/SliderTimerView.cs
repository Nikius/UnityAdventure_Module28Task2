using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class SliderTimerView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _timerDuration;
        
        public CustomTimer CustomTimer;
        
        private void Awake()
        {
            CustomTimer = new CustomTimer(_timerDuration, this);
            
            CustomTimer.OnTimerStarted += OnTimerStarted;
            CustomTimer.OnTimerPaused += OnTimerPaused;
            CustomTimer.OnTimerContinued += OnTimerContinued;
            CustomTimer.OnTimerEnded += OnTimerEnded;
            CustomTimer.OnTimerReset += OnTimerReset;
            
            Reset();
        }
        
        private void OnDestroy()
        {
            CustomTimer.OnTimerStarted -= OnTimerStarted;
            CustomTimer.OnTimerPaused -= OnTimerPaused;
            CustomTimer.OnTimerContinued -= OnTimerContinued;
            CustomTimer.OnTimerEnded -= OnTimerEnded;
            CustomTimer.OnTimerReset -= OnTimerReset;
        }
        
        public void UpdateView()
        {
            if (CustomTimer.IsRunning == false)
                return;
            
            Debug.Log("SliderTimer Elapsed Time: " + CustomTimer.ElapsedTime);
            _slider.value = 1 - CustomTimer.ElapsedTime / CustomTimer.Duration;
        }
        
        private void OnTimerStarted()
        {
            Debug.Log("SliderTimer Started");
            Enable();
        }

        private void OnTimerPaused()
        {
            Debug.Log("SliderTimer Paused");
            Disable();
        }

        private void OnTimerContinued()
        {
            Debug.Log("SliderTimer continued");
            Enable();
        }

        private void OnTimerEnded()
        {
            Debug.Log("SliderTimer Ended");
            Disable();
        }

        private void OnTimerReset()
        {
            Debug.Log("SliderTimer Reset");
            Reset();
        }

        private void Enable()
        {
            _slider.enabled = true;
        }

        private void Disable()
        {
            _slider.enabled = false;
        }

        private void Reset()
        {
            _slider.value = 1;
            _slider.enabled = false;
        }
    }
}
