using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class HeartsTimerView : MonoBehaviour
    {
        private const float DisabledOpacity = 0.3f;
        
        [SerializeField] private Image _heartPrefab;
        [SerializeField] private GameObject _heartContainer;

        private CustomTimer _customTimer;
        
        private readonly List<Image> _hearts = new();
        private int _maxHeartsCount;

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
            
            _maxHeartsCount = Mathf.FloorToInt(_customTimer.Duration);
            Reset();
        }

        private void UpdateView()
        {
            Debug.Log("HeartsTimer Elapsed Time: " + _customTimer.ElapsedTime);
            UpdateView(_customTimer.ElapsedTime);
        }
        
        private void OnTimerUpdated()
        {
            UpdateView();
        }
        
        private void OnTimerStarted()
        {
            Debug.Log("HeartsTimer Started");
            Enable();
        }

        private void OnTimerPaused()
        {
            Debug.Log("HeartsTimer Paused");
            Disable();
        }

        private void OnTimerContinued()
        {
            Debug.Log("HeartsTimer continued");
            Enable();
        }

        private void OnTimerEnded()
        {
            Debug.Log("HeartsTimer Ended");
        }

        private void OnTimerReset()
        {
            Debug.Log("HeartsTimer Reset");
            Reset();
        }

        private void Reset()
        {
            foreach (Image heart in _hearts)
                Destroy(heart.gameObject);
            
            _hearts.Clear();
            
            for (int i = 0; i < _maxHeartsCount; i++)
            {
                Image heart = Instantiate(_heartPrefab, _heartContainer.transform);
                _hearts.Add(heart);
            }
            
            Disable();
        }
        
        private void Enable()
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                Image heart = _hearts[i];
                
                Color color = heart.color;
                color.a = 1f;
                heart.color = color;
            }
        }

        private void Disable()
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                Image heart = _hearts[i];
                
                Color color = heart.color;
                color.a = DisabledOpacity;
                heart.color = color;
            }
        }

        private void UpdateView(float elapsedTime)
        {
            if (_hearts.Count > 0 && elapsedTime - (_maxHeartsCount - _hearts.Count) > 1)
            {
                Image heart = _hearts[^1]; 
                Destroy(heart.gameObject);
                _hearts.Remove(heart);
            }
        }
    }
}
