/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenPingPongStrategy : ITweenPlayStyleStrategy
    {
        private TweenerPlayStyle _style;
        private ITweenSharedState _state;

        public TweenPingPongStrategy(ITweenSharedState sharedState)
        {
            _style = TweenerPlayStyle.PingPong;
            _state = sharedState;
        }

        public void InitializeState()
        {
            _state.SetDuration(_state.GetDuration() / 2);
        }

        public void UpdateCycle()
        {
            if (_state.GetCycleCount() == 0) return;
            SwapInitialParams();
        }

        public bool CanComplete()
        {
            var max = _state.GetMaxLoops();
            return max != -1 && _state.GetCycleCount() >= (max * 2);
        }

        public TweenerPlayStyle GetPlayStyle()
        {
            return _style;
        }

        public void Update(float deltaTime)
        {

        }

        private void SwapInitialParams()
        {
            _state.Swap();
        }

        public void Dispose()
        {
        }
    }
}

