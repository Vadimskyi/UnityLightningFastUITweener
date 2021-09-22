/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;

namespace VadimskyiLab.UiExtension
{
    public interface ITweenPlayStyleStrategy : IDisposable
    {
        void InitializeState();
        void UpdateCycle();
        bool CanComplete();
        TweenerPlayStyle GetPlayStyle();
        void Update(float deltaTime);
    }

    public enum TweenerPlayStyle
    {
        Once,
        Loop,
        PingPong
    }
}