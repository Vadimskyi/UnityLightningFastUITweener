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
        public static ITweenRemoteControl TweenMove2D(this RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.localPosition,
                ToValue = toValue,
                Duration = duration
            };

            var tween =  new TweenLocalPositionStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenMoveAnchored2D(this RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.anchoredPosition,
                ToValue = toValue,
                Duration = duration
            };
            var tween = new TweenAnchoredPositionStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenSizeDelta2D(this RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.sizeDelta,
                ToValue = toValue,
                Duration = duration
            };
            var tween = new TweenSizeDeltaStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenScale2D(this RectTransform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.localScale,
                ToValue = toValue,
                Duration = duration
            };
            var tween = new TweenScaleStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenScale2D(this Transform target, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>()
            {
                FromValue = target.localScale,
                ToValue = toValue,
                Duration = duration
            };
            var tween = new TweenScaleStrategy(
                target,
                state,
                new Vector2ValueModifier(state),
                CreatePlayStyle(state, style));
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenAlpha(this Graphic target, float toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<float> state = new TweenSharedState<float>()
            {
                FromValue = target.GetAlpha(),
                ToValue = toValue,
                Duration = duration
            };
            var tween = new TweenAlphaStrategy(
                target,
                state,
                new FloatValueModifier(state),
                CreatePlayStyle(state, style));
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenScroll(this ScrollRect scrollRect, ScrollOrientation direction, float toValue, float duration, TweenerPlayStyle style)
        {
            var value = direction == ScrollOrientation.Horizontal
                ? scrollRect.horizontalNormalizedPosition
                : scrollRect.verticalNormalizedPosition;
            TweenSharedState<float> state = new TweenSharedState<float>()
            {
                FromValue = value,
                ToValue = toValue,
                Duration = duration
            };
            var tween = new TweenScrollToStrategy(
                scrollRect,
                state,
                new FloatValueModifier(state),
                CreatePlayStyle(state, style),
                direction);
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenRotate2D(this Transform target, Vector3 toValue, float duration, TweenerPlayStyle style)
        {
            TweenSharedState<Quaternion> state = new TweenSharedState<Quaternion>()
            {
                FromValue = target.localRotation,
                ToValue = Quaternion.Euler(toValue),
                Duration = duration
            };

            var tween = new TweenRotationStrategy(
                target,
                state,
                new QuaternionValueModifier(state),
                TweenHandlerStaticFactory.CreatePlayStyle(state, style));

            TweenUpdaterMono.Instance.Subscribe(tween);

            return tween.GetRemote();
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