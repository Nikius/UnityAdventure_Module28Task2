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
        
        private readonly List<Image> _hearts = new();
        private int _maxHeartsCount;
        
        public void Initialize(int maxHeartsCount)
        {
            _maxHeartsCount = maxHeartsCount;
            Reset();
        }

        public void Reset()
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
        
        public void Enable()
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                Image heart = _hearts[i];
                
                Color color = heart.color;
                color.a = 1f;
                heart.color = color;
            }
        }

        public void Disable()
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                Image heart = _hearts[i];
                
                Color color = heart.color;
                color.a = DisabledOpacity;
                heart.color = color;
            }
        }

        public void UpdateView(float elapsedTime)
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
