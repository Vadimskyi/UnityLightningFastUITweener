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
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>(target.localPosition, toValue, duration);

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
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>(target.anchoredPosition, toValue, duration);
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
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>(target.sizeDelta, toValue, duration);
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
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>(target.localScale, toValue, duration);
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
            TweenSharedState<Vector2> state = new TweenSharedState<Vector2>(target.localScale, toValue, duration);
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
            TweenSharedState<float> state = new TweenSharedState<float>(target.GetAlpha(), toValue, duration);
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
            TweenSharedState<float> state = new TweenSharedState<float>(value, toValue, duration);
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
            TweenQuaternionSharedState state = new TweenQuaternionSharedState(
                target.localRotation.eulerAngles, 
                toValue, 
                duration);

            var tween = new TweenRotationStrategy(
                target,
                state,
                new QuaternionValueModifier(state),
                CreatePlayStyle(state, style));

            TweenUpdaterMono.Instance.Subscribe(tween);

            return tween.GetRemote();
        }

        public static ITweenPlayStyleStrategy CreatePlayStyle(ITweenSharedState state, TweenerPlayStyle style)
        {
            switch (style)
            {
                case TweenerPlayStyle.PingPong: return new TweenPingPongStrategy(state);
                case TweenerPlayStyle.Once: return new TweenOnceStrategy(state);
                case TweenerPlayStyle.Loop: return new TweenLoopStrategy(state);
            }

            throw new NotImplementedException($"Tween play-style \"{style}\" is not implemented!");
        }
    }
}