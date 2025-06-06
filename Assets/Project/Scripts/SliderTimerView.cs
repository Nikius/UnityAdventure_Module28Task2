using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class SliderTimerView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private CustomTimer _customTimer;

        private void OnDestroy()
        {
            _customTimer.OnTimerStarted -= OnTimerStarted;
            _customTimer.OnTimerPaused -= OnTimerPaused;
            _customTimer.OnTimerContinued -= OnTimerContinued;
            _customTimer.OnTimerEnded -= OnTimerEnded;
            _customTimer.OnTimerReset -= OnTimerReset;
            _customTimer.OnUpdated -= OnTimerUpdated;
        }

        public void Initialize(CustomTimer customTimer)
        {
            _customTimer = customTimer;
            
            _customTimer.OnTimerStarted += OnTimerStarted;
            _customTimer.OnTimerPaused += OnTimerPaused;
            _customTimer.OnTimerContinued += OnTimerContinued;
            _customTimer.OnTimerEnded += OnTimerEnded;
            _customTimer.OnTimerReset += OnTimerReset;
            _customTimer.OnUpdated += OnTimerUpdated;
            
            Reset();
        }

        private void UpdateView()
        {
            Debug.Log("SliderTimer Elapsed Time: " + _customTimer.ElapsedTime);
            _slider.value = 1 - _customTimer.ElapsedTime / _customTimer.Duration;
        }

        private void OnTimerUpdated()
        {
            UpdateView();
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
