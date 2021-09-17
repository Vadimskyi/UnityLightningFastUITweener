﻿/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenScaleStrategy : TransformStrategyBase<Vector2>
    {
        private Vector2 _defaultValue;

        public TweenScaleStrategy(
            Transform target, 
            ITweenSharedState sharedSharedState,  
            IValueModifier<Vector2> modHandler, 
            ITweenPlayStyleStrategy style) : base(target, sharedSharedState, modHandler, style)
        {
            _defaultValue = target.localScale;
        }

        public override void OnValueUpdated(Vector2 value)
        {
            _target.localScale = new Vector3(value.x, value.y, _target.localScale.z);
        }

        public override void ResetValueToDefault()
        {
            _target.localScale = _defaultValue;
        }
    }
}