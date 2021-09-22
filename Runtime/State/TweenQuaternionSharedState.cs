/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    public class TweenQuaternionSharedState : TweenSharedState<Quaternion>
    {
        public new Vector3 FromValue;
        public new Vector3 ToValue;
        public TweenQuaternionSharedState(Vector3 fromValue, Vector3 toValue, float duration) : base(Quaternion.Euler(fromValue), Quaternion.Euler(toValue), duration)
        {
            FromValue = fromValue;
            ToValue = toValue;
        }

        public override void Swap()
        {
            var tmp = FromValue;
            FromValue = ToValue;
            ToValue = tmp;
        }
    }
}