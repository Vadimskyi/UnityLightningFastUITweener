/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine.UI;

namespace VadimskyiLab.UiExtension
{
    public static class ScrollRectPositionTweener
    {
        public static ITweenRemoteControl TweenHorizontalScroll(this ScrollRect s, float toValue, float duration, TweenerPlayStyle style)
        {
            var tween = TweenHandlerStaticFactory.CreateScroll(s, ScrollOrientation.Horizontal,  toValue, duration, style);
            TweenUpdaterMono.Instance.Subscribe(tween);
            return tween.GetRemote();
        }
    }
}