/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;

namespace VadimskyiLab.UiExtension
{
    public sealed class TweenRemoteControl : ITweenRemoteControl
    {
        public long Id => _id;
        public bool Completed { get; private set; }

        private long _id;
        private Action _onComplete;
        private Action _onKill;
        private ITweenComponentStrategy _strategy;

        public TweenRemoteControl(ITweenComponentStrategy strategy)
        {
            _id = GenerateId();
            _strategy = strategy;
        }

        public void OnComplete(Action callback)
        {
            _onComplete += callback;
        }

        public void OnKill(Action callback)
        {
            _onKill += callback;
        }

        public void Kill(bool resetToDefault = false)
        {
            if (resetToDefault)
                _strategy.ResetValueToDefault();
            _onKill?.Invoke();
        }

        public void Complete()
        {
            _onComplete?.Invoke();
            Completed = true;
        }

        private static int _cachedId = 0;
        private static int GenerateId() => _cachedId++;
    }
}