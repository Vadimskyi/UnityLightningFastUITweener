/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;

namespace VadimskyiLab.UiExtension
{
    public interface ITweenRemoteControl
    {
        long Id { get; }
        bool Completed { get; }
        ITweenRemoteControl SetLoops(int loops);
        ITweenRemoteControl OnComplete(Action callback);
        ITweenRemoteControl OnKill(Action callback);
        void Kill(bool resetToDefault = false);
    }
}