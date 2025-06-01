using System;
using UnityEngine;

namespace Project.Scripts
{
    public class CustomTimer
    {
        public event Action OnTimerEnded;
        public event Action OnTimerStarted;
        public event Action OnTimerPaused;
        public event Action OnTimerContinued;
        public event Action OnTimerReset;
        
        public float Duration { get; }
        public float ElapsedTime { get; private set; }
        public bool IsRunning { get; private set; }

        public CustomTimer(float duration)
        {
            Duration = duration;
        }

        public void Reset()
        {
            ElapsedTime = 0;
            IsRunning = false;
            OnTimerReset?.Invoke();
        }

        public void Start()
        {
            IsRunning = true;
            OnTimerStarted?.Invoke();
        }

        public void Pause()
        {
            IsRunning = false;
            OnTimerPaused?.Invoke();
        } 
        
        
        public void Continue()
        {
            IsRunning = true;
            OnTimerContinued?.Invoke();
        }

        public void Update()
        {
            if (IsRunning == false)
                return;
            
            ElapsedTime += Time.deltaTime;

            if (ElapsedTime >= Duration)
            {
                IsRunning = false;
                OnTimerEnded?.Invoke();
            }
        }
    }
}
