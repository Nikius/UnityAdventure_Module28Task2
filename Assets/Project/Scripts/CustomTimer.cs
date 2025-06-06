using System;
using System.Collections;
using UnityEngine;

namespace Project.Scripts
{
    public class CustomTimer
    {
        public event Action OnUpdated;
        public event Action OnTimerEnded;
        public event Action OnTimerStarted;
        public event Action OnTimerPaused;
        public event Action OnTimerContinued;
        public event Action OnTimerReset;
        
        private readonly MonoBehaviour _coroutineRunner;
        private Coroutine _currentCoroutine;
        
        public float Duration { get; }
        public float ElapsedTime { get; private set; }
        public bool IsRunning { get; private set; }
        
        public bool IsTimerPaused() => IsRunning == false && _currentCoroutine is not null;

        public CustomTimer(float duration, MonoBehaviour coroutineRunner)
        {
            Duration = duration;
            _coroutineRunner = coroutineRunner;
        }

        public void Reset()
        {
            ElapsedTime = 0;
            IsRunning = false;
            
            if (_currentCoroutine != null)
                _coroutineRunner.StopCoroutine(_currentCoroutine);
            
            OnTimerReset?.Invoke();
            OnUpdated?.Invoke();
        }

        public void Start()
        {
            IsRunning = true;
            _currentCoroutine = _coroutineRunner.StartCoroutine(RunRoutine());
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

        private IEnumerator RunRoutine()
        {
            while (ElapsedTime < Duration)
            {
                if (IsRunning)
                {
                    ElapsedTime += Time.deltaTime;
                    OnUpdated?.Invoke();
                }
                
                yield return null;
            }
            
            IsRunning = false;
            _currentCoroutine = null;
            OnTimerEnded?.Invoke();
        }
    }
}
