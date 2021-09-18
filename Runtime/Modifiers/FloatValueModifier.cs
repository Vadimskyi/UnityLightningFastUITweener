/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    public sealed class FloatValueModifier : IValueModifier<float>
    {
        private float _timeFromStart;
        private TweenSharedState<float> _sharedState;

        public FloatValueModifier(TweenSharedState<float> sharedState)
        {
            _timeFromStart = 0;
            _sharedState = sharedState;
        }

        public float TimeElapsed()
        {
            return _timeFromStart;
        }

        public TweenSharedState<float> GetOptions() => _sharedState;

        public float GetStartingValue()
        {
            return _sharedState.FromValue;
        }

        public float GetDestinationValue()
        {
            return _sharedState.ToValue;
        }

        public float ModifyValue(float deltaTime)
        {
            _timeFromStart += deltaTime;
            return Mathf.Approximately(_sharedState.Duration, 0)? _sharedState.ToValue : Mathf.Lerp(_sharedState.FromValue, _sharedState.ToValue, _timeFromStart / _sharedState.Duration);
        }

        public void Reset()
        {
            _timeFromStart = 0;
        }

        public void Dispose()
        {
        }
    }
}