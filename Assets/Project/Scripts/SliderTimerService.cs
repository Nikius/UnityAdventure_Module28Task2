using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class SliderTimerService: TimerService
    {
        [SerializeField] private Slider _slider;

        protected override void Initialize()
        {
            _slider.value = 1;
            _slider.enabled = false;
        }

        protected override void UpdateView()
        {
            _slider.value = 1 - CustomTimer.ElapsedTime / CustomTimer.Duration;
        }
        
        protected override void OnTimerStarted()
        {
            base.OnTimerStarted();
            
            _slider.enabled = true;
        }

        protected override void OnTimerPaused()
        {
            base.OnTimerPaused();
            
            _slider.enabled = false;
        }

        protected override void OnTimerContinued()
        {
            base.OnTimerContinued();
            
            _slider.enabled = true;
        }

        protected override void OnTimerEnded()
        {
            base.OnTimerEnded();
            
            _slider.enabled = false;
        }

        protected override void OnTimerReset()
        {
            base.OnTimerReset();
            
            _slider.enabled = false;
            _slider.value = 1;
        }
    }
}