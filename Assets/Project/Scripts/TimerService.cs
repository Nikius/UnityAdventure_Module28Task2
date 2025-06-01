using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class TimerService : MonoBehaviour
    {
        protected CustomTimer CustomTimer;
        
        [SerializeField] private float _timerDuration;

        private void Start()
        {
            CustomTimer = new CustomTimer(_timerDuration);
            
            CustomTimer.OnTimerStarted += OnTimerStarted;
            CustomTimer.OnTimerPaused += OnTimerPaused;
            CustomTimer.OnTimerContinued += OnTimerContinued;
            CustomTimer.OnTimerEnded += OnTimerEnded;
            CustomTimer.OnTimerReset += OnTimerReset;

            Initialize();
        }

        private void OnDestroy()
        {
            CustomTimer.OnTimerStarted -= OnTimerStarted;
            CustomTimer.OnTimerPaused -= OnTimerPaused;
            CustomTimer.OnTimerContinued -= OnTimerContinued;
            CustomTimer.OnTimerEnded -= OnTimerEnded;
            CustomTimer.OnTimerReset -= OnTimerReset;
        }

        private void Update()
        {
            if (CustomTimer.IsRunning == false)
                return;
            
            CustomTimer.Update();

            UpdateView();
        }

        public void StartTimer() => CustomTimer.Start();
        public void PauseTimer() => CustomTimer.Pause();
        public void ContinueTimer() => CustomTimer.Continue();
        public void ResetTimer() => CustomTimer.Reset();
        public bool IsTimerRunning() => CustomTimer.IsRunning;
        public bool IsTimerPaused() => CustomTimer.IsRunning == false 
                                       && CustomTimer.ElapsedTime > 0 
                                       && CustomTimer.ElapsedTime < _timerDuration;

        protected virtual void Initialize()
        {
            //
        }

        protected virtual void UpdateView()
        {
            Debug.Log("Elapsed Time: " + CustomTimer.ElapsedTime);
        }

        protected virtual void OnTimerStarted()
        {
            Debug.Log("Timer Started");
        }

        protected virtual void OnTimerPaused()
        {
            Debug.Log("Timer Paused");
        }
        
        protected virtual void OnTimerContinued()
        {
            Debug.Log("Timer continued");
        }

        protected virtual void OnTimerEnded()
        {
            Debug.Log("Timer Ended");
        }
        
        protected virtual void OnTimerReset()
        {
            Debug.Log("Timer Reset");
        }
    }
}
