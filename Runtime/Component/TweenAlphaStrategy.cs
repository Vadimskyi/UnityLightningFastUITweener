/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine.UI;
using VadimskyiLab.Utils;

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenAlphaStrategy : MonoStrategyBase<float>
    {
        private Graphic _target;
        private float _defaultValue;

        public TweenAlphaStrategy(
            Graphic target, 
            ITweenSharedState sharedState, 
            IValueModifier<float> modHandler, 
            ITweenPlayStyleStrategy style) : base(target, sharedState, modHandler, style)
        {
            _target = target;
            _defaultValue = _target.color.a;
        }

        public override void OnValueUpdated(float value)
        {
            if (!IsTargetValid()) return;
            _target.SetAlpha(value);
        }

        public override void ResetValueToDefault()
        {
            if (!IsTargetValid()) return;
            _target.SetAlpha(_defaultValue);
        }
    }
}