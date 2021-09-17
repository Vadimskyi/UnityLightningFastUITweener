/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenSizeDeltaStrategy : ITweenComponentStrategy
    {
        private RectTransform _target;
        private TweenRemoteControl _remote;
        private TweenComponentState _state;
        private IValueModifier<Vector2> _mod;
        private ITweenPlayStyleStrategy _style;
        private TweenSharedState<Vector2> _sharedState;

        public TweenSizeDeltaStrategy(RectTransform target, ITweenSharedState sharedSharedState, IValueModifier<Vector2> modHandler, ITweenPlayStyleStrategy style)
        {
            _target = target;
            _mod = modHandler;
            _style = style;
            _sharedState = (TweenSharedState<Vector2>)sharedSharedState;
            _state = TweenComponentState.None;
            _remote = new TweenRemoteControl(this);
            _style.InitializeState();
            SubscribeToRemote();
        }

        public void UpdateComponent(float deltaTime)
        {
            _target.sizeDelta = _mod.ModifyValue(deltaTime);
            _state = TweenComponentState.Processing;
            if (CanComplete())
            {
                _sharedState.CycleCount++;
                if (_style.CanComplete())
                {
                    TweenCompleted();
                    return;
                }
                _style.InitializeState();
                _mod.Reset();
            }
        }

        public object GetComponent() => _target;

        public ITweenPlayStyleStrategy GetPlayStyle() => _style;

        public bool CanComplete() => _mod.TimeElapsed() >= _sharedState.Duration;

        public void ResetValueToDefault()
        {
            throw new System.NotImplementedException();
        }

        public TweenComponentState GetState() => _state;

        public ITweenRemoteControl GetRemote() => _remote;

        public void Dispose()
        {
            _mod?.Dispose();
            _style?.Dispose();
        }

        private void Kill()
        {
            _state = TweenComponentState.Killed;
            Dispose();
        }

        private void TweenCompleted()
        {
            _state = TweenComponentState.Completed;
            _remote.Complete();
            Dispose();
        }

        private void SubscribeToRemote()
        {
            _remote.OnKill(Kill);
        }
    }
}