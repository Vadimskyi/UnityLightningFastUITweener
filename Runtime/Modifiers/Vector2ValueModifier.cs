/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    internal sealed class Vector2ValueModifier : IValueModifier<Vector2>
    {
        private float _timeFromStart;
        private TweenSharedState<Vector2> _sharedState;

        public Vector2ValueModifier(TweenSharedState<Vector2> sharedState)
        {
            _timeFromStart = 0;
            _sharedState = sharedState;
        }

        public float TimeElapsed()
        {
            return _timeFromStart;
        }

        public TweenSharedState<Vector2> GetOptions() => _sharedState;

        public Vector2 GetStartingValue()
        {
            return _sharedState.FromValue;
        }

        public Vector2 GetDestinationValue()
        {
            return _sharedState.ToValue;
        }

        public Vector2 ModifyValue(float deltaTime)
        {
            _timeFromStart += deltaTime;

            return Mathf.Approximately(_sharedState.Duration, 0) ? _sharedState.ToValue : Vector2.Lerp(_sharedState.FromValue, _sharedState.ToValue, _timeFromStart / _sharedState.Duration);
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