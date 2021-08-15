/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using System;

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenRemoteControl : ITweenRemoteControl
    {
        private long _id;
        private Action _onComplete;
        private Action _onKill;

        public long Id => _id;
        public bool Completed { get; private set; }

        public TweenRemoteControl()
        {
            _id = GenerateId();
        }

        public void OnComplete(Action callback)
        {
            _onComplete += callback;
        }

        public void OnKill(Action callback)
        {
            _onKill += callback;
        }

        public void Kill()
        {
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