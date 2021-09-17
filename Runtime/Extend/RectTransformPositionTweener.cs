﻿/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    public static class RectTransformPositionTweener
    {
        public static ITweenRemoteControl TweenMove2D(this RectTransform t, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            var tween = TweenHandlerStaticFactory.CreatePosition2D(t, toValue, duration, style);
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenMoveAnchored2D(this RectTransform t, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            var tween = TweenHandlerStaticFactory.CreatePositionAnchored2D(t, toValue, duration, style);
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }

        public static ITweenRemoteControl TweenSizeDelta2D(this RectTransform t, Vector2 toValue, float duration, TweenerPlayStyle style)
        {
            var tween = TweenHandlerStaticFactory.CreateSizeDelta2D(t, toValue, duration, style);
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }
    }
}