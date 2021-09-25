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
        private bool _isKilled;
        private Action _onComplete;
        private Action _onKill;
        private ITweenComponentStrategy _strategy;

        public TweenRemoteControl(ITweenComponentStrategy strategy)
        {
            _id = GenerateId();
            _strategy = strategy;
        }

        public ITweenRemoteControl SetLoops(int loops)
        {
            _strategy.GetSharedStateData().SetLoops(loops);
            return this;
        }

        public ITweenRemoteControl OnComplete(Action callback)
        {
            _onComplete += callback;
            return this;
        }

        public ITweenRemoteControl OnKill(Action callback)
        {
            _onKill += callback;
            return this;
        }

        public void Kill(bool resetToDefault = false)
        {
            if (_isKilled) return;
            if (resetToDefault)
                _strategy.ResetValueToDefault();
            _onKill?.Invoke();
            _onKill = null;
            _isKilled = true;
        }

        public void Complete()
        {
            if(_isKilled) return;
            _onComplete?.Invoke();
            Completed = true;
        }

        private static int _cachedId = 0;
        private static int GenerateId() => _cachedId++;
    }
}