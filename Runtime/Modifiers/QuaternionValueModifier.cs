/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

using System;
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    public sealed class QuaternionValueModifier : IValueModifier<Quaternion>
    {
        private float _timeFromStart;
        private TweenQuaternionSharedState _sharedState;

        public QuaternionValueModifier(TweenQuaternionSharedState sharedState)
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
            return Quaternion.Euler(_sharedState.FromValue);
        }

        public Quaternion GetDestinationValue()
        {
            return Quaternion.Euler(_sharedState.ToValue);
        }

        public Quaternion ModifyValue(float deltaTime)
        {
            float fromAngle = _sharedState.FromValue.z;
            Vector3 fromAxis;
            var normalizedFromAxis = _sharedState.FromValue.normalized;
            fromAxis = new Vector3(Math.Abs(normalizedFromAxis.x), Math.Abs(normalizedFromAxis.y), Math.Abs(normalizedFromAxis.z));

            float toAngle = _sharedState.ToValue.z; 
            Vector3 toAxis;
            var normalizedToAxis = _sharedState.ToValue.normalized;
            toAxis = new Vector3(Math.Abs(normalizedToAxis.x), Math.Abs(normalizedToAxis.y), Math.Abs(normalizedToAxis.z));

            _timeFromStart += deltaTime;

            var progress = _timeFromStart / _sharedState.Duration;
            float currentAngle = Mathf.Lerp(fromAngle, toAngle, progress);
            Vector3 currentAxis = Vector3.Slerp(fromAxis, toAxis, progress);

            return Mathf.Approximately(_sharedState.Duration, 0) ? Quaternion.Euler(_sharedState.ToValue) : Quaternion.AngleAxis(currentAngle, currentAxis);
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
