/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenLoopStrategy : ITweenPlayStyleStrategy
    {
        private TweenerPlayStyle _style;
        private ITweenSharedState _state;

        public TweenLoopStrategy(ITweenSharedState sharedState)
        {
            _style = TweenerPlayStyle.Loop;
            _state = sharedState;
        }

        public void InitializeState()
        {
            if (_state.GetCycleCount() == 0)
                _state.SetDuration(_state.GetDuration() / 2);
            else
                SwapInitialParams();
        }

        public void UpdateCycle()
        {
            if (CanComplete()) return;
        }

        public bool CanComplete()
        {
            var max = _state.GetMaxLoops();
            return max != -1 && _state.GetCycleCount() >= max;
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