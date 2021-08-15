/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;
using System.Collections.Generic;

namespace VadimskyiLab.UiExtension
{
    public static class TweenHelper
    {
        public static void WhenAll(this IReadOnlyList<ITweenRemoteControl> tweeners, Action callback)
        {
            HashSet<long> hs = new HashSet<long>();
            bool completed = false;
            foreach (var tweener in tweeners)
            {
                hs.Add(tweener.Id);
                tweener.OnComplete(() => CheckCompletion(tweener));
                tweener.OnKill(() => CheckCompletion(tweener));
            }

            void CheckCompletion(ITweenRemoteControl remote)
            {
                if(completed) return;
                hs.Remove(remote.Id);
                if(hs.Count > 0) return;
                completed = true;
                callback?.Invoke();
            }
        }
    }

    public enum ScrollOrientation
    {
        None,
        Vertical,
        Horizontal
    }
}