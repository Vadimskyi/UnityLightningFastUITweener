/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;

namespace VadimskyiLab.UiExtension
{
    public interface IValueModifier<T> : IDisposable
    {
        float TimeElapsed();
        TweenSharedState<T> GetOptions();
        T GetStartingValue();
        T GetDestinationValue();
        T ModifyValue(float deltaTime);
        void Reset();
    }
}