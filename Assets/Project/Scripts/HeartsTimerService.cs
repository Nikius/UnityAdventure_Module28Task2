using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class HeartsTimerService: TimerService
    {
        [SerializeField] private HeartsTimerView _heartsTimerView;

        protected override void Initialize()
        {
            int maxHearts = Mathf.FloorToInt(CustomTimer.Duration);
            _heartsTimerView.Initialize(maxHearts);
        }

        protected override void UpdateView()
        {
            _heartsTimerView.UpdateView(CustomTimer.ElapsedTime);
        }
        
        protected override void OnTimerStarted()
        {
            base.OnTimerStarted();
            
            _heartsTimerView.Enable();
        }

        protected override void OnTimerPaused()
        {
            base.OnTimerPaused();
            
            _heartsTimerView.Disable();
        }

        protected override void OnTimerContinued()
        {
            base.OnTimerContinued();
            
            _heartsTimerView.Enable();
        }

        protected override void OnTimerReset()
        {
            base.OnTimerReset();
            
            _heartsTimerView.Reset();
        }
    }
}