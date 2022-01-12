/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    /// <summary>
    /// All functionality is described in abstract class MonoStrategyBase.
    /// MonoStrategyBase generic argument type is the type of the field we want to change (in this example, Quaternion is the type of Transform.localRotation field)
    /// </summary>
    public class TweenRotationStrategy : MonoStrategyBase<Quaternion>
    {
        private Transform _target;
        private Quaternion _defaultValue;

        /// <param name="target">Target object for tweening</param>
        /// <param name="sharedState">Twinning value data (from, to, duration)</param>
        /// <param name="modHandler">Value modifier handler. Handle value change over time.</param>
        /// <param name="style">Tween style strategy</param>
        public TweenRotationStrategy(
            Transform target,
            ITweenSharedState sharedState,
            IValueModifier<Quaternion> modHandler,
            ITweenPlayStyleStrategy style) : base(target, sharedState, modHandler, style)
        {
            _target = target;
            _defaultValue = _target.localRotation;
        }

        /// <summary>
        /// Every time value updated this method is being called.
        /// We need to assign updated value to the target property.
        /// </summary>
        /// <param name="value">updated value</param>
        public override void OnValueUpdated(Quaternion value)
        {
            if (!IsTargetValid()) return;
            _target.localRotation = value;
        }

        public override void ResetValueToDefault()
        {
            if (!IsTargetValid()) return;
            _target.localRotation = _defaultValue;
        }
    }
}