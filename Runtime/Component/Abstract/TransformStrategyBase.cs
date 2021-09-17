/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    public abstract class TransformStrategyBase<T> : ITweenComponentStrategy
    {
        protected Transform _target;
        protected TweenRemoteControl _remote;
        protected TweenComponentState _state;
        protected IValueModifier<T> _mod;
        protected ITweenPlayStyleStrategy _style;
        protected ITweenSharedState _sharedState;

        protected TransformStrategyBase(
            Transform target, 
            ITweenSharedState sharedSharedState, 
            IValueModifier<T> modHandler, 
            ITweenPlayStyleStrategy style)
        {
            _target = target;
            _mod = modHandler;
            _style = style;
            _sharedState = sharedSharedState;
            _state = TweenComponentState.None;
            _remote = new TweenRemoteControl(this);
            _style.InitializeState();
            SubscribeToRemote();
        }

        public void UpdateComponent(float deltaTime)
        {
            if (CanComplete())
            {
                _sharedState.IncrementCycleCount();
                if (_style.CanComplete())
                {
                    TweenCompleted();
                    return;
                }
                _style.InitializeState();
                _mod.Reset();
            }
            OnValueUpdated(_mod.ModifyValue(deltaTime));
            _state = TweenComponentState.Processing;
        }

        public abstract void OnValueUpdated(T value);

        public object GetComponent() => _target;

        public ITweenPlayStyleStrategy GetPlayStyle() => _style;

        public bool CanComplete() => _mod.TimeElapsed() >= _sharedState.GetDuration();

        public abstract void ResetValueToDefault();

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