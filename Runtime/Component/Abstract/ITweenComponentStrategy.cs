/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;
using Object = UnityEngine.Object;

namespace VadimskyiLab.UiExtension
{
    public interface ITweenComponentStrategy : IDisposable
    {
        Object GetTargetComponent();
        ITweenPlayStyleStrategy GetPlayStyle();
        void UpdateComponent(float deltaTime);
        TweenComponentState GetState();
        ITweenSharedState GetSharedStateData();
        ITweenRemoteControl GetRemote();
        bool CanComplete();
        void ResetValueToDefault();
    }

    public enum TweenComponentState
    {
        None,
        Processing,
        Completed,
        Killed
    }
}