/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine.UI;

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenScrollToStrategy : MonoStrategyBase<float>
    {
        private ScrollRect _target;
        private float _defaultValue;
        private ScrollOrientation _orientation;

        public TweenScrollToStrategy(
            ScrollRect target, 
            ITweenSharedState sharedState, 
            IValueModifier<float> modHandler, 
            ITweenPlayStyleStrategy style, 
            ScrollOrientation orientation) : base(target, sharedState, modHandler, style)
        {
            _target = target;
            _orientation = orientation;
            _defaultValue = orientation == ScrollOrientation.Horizontal
                ? target.horizontalNormalizedPosition
                : target.verticalNormalizedPosition;
        }
        

        public override void OnValueUpdated(float value)
        {
            if (!IsTargetValid()) return;
            switch (_orientation)
            {
                case ScrollOrientation.Horizontal:
                    _target.horizontalNormalizedPosition = value;
                    break;
                case ScrollOrientation.Vertical:
                    _target.verticalNormalizedPosition = value;
                    break;
            }
        }

        public override void ResetValueToDefault()
        {
            if (!IsTargetValid()) return;
            switch (_orientation)
            {
                case ScrollOrientation.Horizontal:
                    _target.horizontalNormalizedPosition = _defaultValue;
                    break;
                case ScrollOrientation.Vertical:
                    _target.verticalNormalizedPosition = _defaultValue;
                    break;
            }
        }
    }
}