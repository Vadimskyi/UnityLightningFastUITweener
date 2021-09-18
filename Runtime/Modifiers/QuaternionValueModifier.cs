/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    public sealed class QuaternionValueModifier : IValueModifier<Quaternion>
    {
        private float _timeFromStart;
        private TweenSharedState<Quaternion> _sharedState;

        public QuaternionValueModifier(TweenSharedState<Quaternion> sharedState)
        {
            _timeFromStart = 0;
            _sharedState = sharedState;
        }

        public float TimeElapsed()
        {
            return _timeFromStart;
        }

        public TweenSharedState<Quaternion> GetOptions() => _sharedState;

        public Quaternion GetStartingValue()
        {
            return _sharedState.FromValue;
        }

        public Quaternion GetDestinationValue()
        {
            return _sharedState.ToValue;
        }

        public Quaternion ModifyValue(float deltaTime)
        {
            _timeFromStart += deltaTime;
            return Mathf.Approximately(_sharedState.Duration, 0) ? _sharedState.ToValue : Quaternion.Lerp(_sharedState.FromValue, _sharedState.ToValue, _timeFromStart / _sharedState.Duration);
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
