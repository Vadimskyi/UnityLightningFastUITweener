﻿/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
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
        void OnComplete(Action callback);
        void OnKill(Action callback);
        void Kill();
    }
}