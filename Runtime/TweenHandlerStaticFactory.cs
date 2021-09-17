/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;
using UnityEngine;
using UnityEngine.UI;
using VadimskyiLab.Utils;

namespace VadimskyiLab.UiExtension
{
    public static class TweenHandlerStaticFactory
    {
        public static ITweenComponentStrategy CreatePosition2D(RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.localPosition,
                ToValue = toValue,
                Duration = duration
            };
            return new TweenLocalPositionStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
        }

        public static ITweenComponentStrategy CreatePositionAnchored2D(RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.anchoredPosition,
                ToValue = toValue,
                Duration = duration
            };
            return new TweenAnchoredPositionStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
        }

        public static ITweenComponentStrategy CreateScale(Transform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.localScale,
                ToValue = toValue,
                Duration = duration
            };
            return new TweenScaleStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
        }

        public static ITweenComponentStrategy CreateSizeDelta2D(RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.sizeDelta,
                ToValue = toValue,
                Duration = duration
            };
            return new TweenSizeDeltaStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
        }

        public static ITweenComponentStrategy Create(Graphic target, float toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<float> state = new TweenSharedState<float>()
            {
                FromValue = target.GetAlpha(),
                ToValue = toValue,
                Duration = duration
            };
            return new TweenAlphaStrategy(
                target,
                state,
                new FloatValueModifier(state),
                CreatePlayStyle(state, style));
        }

        public static ITweenComponentStrategy CreateScroll(ScrollRect scrollRect, ScrollOrientation orientation, float toValue, float duration, TweenerPlayStyle style)
        {
            var value = orientation == ScrollOrientation.Horizontal
                ? scrollRect.horizontalNormalizedPosition
                : scrollRect.verticalNormalizedPosition;
            TweenSharedState<float> state = new TweenSharedState<float>()
            {
                FromValue = value,
                ToValue = toValue,
                Duration = duration
            };
            return new TweenScrollToStrategy(
                scrollRect,
                state,
                new FloatValueModifier(state),
                CreatePlayStyle(state, style),
                orientation);
        }

        public static ITweenPlayStyleStrategy CreatePlayStyle(ITweenSharedState state, TweenerPlayStyle style)
        {
            switch (style)
            {
                case TweenerPlayStyle.PingPong: return new TweenPingPongStrategy(state);
                case TweenerPlayStyle.Once: return new TweenOnceStrategy(state);
            }

            throw new NotImplementedException($"Tween play-style \"{style}\" is not implemented!");
        }
    }
}