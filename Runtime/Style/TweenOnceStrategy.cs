/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

namespace VadimskyiLab.UiExtension
{
    internal sealed class TweenOnceStrategy : ITweenPlayStyleStrategy
    {
        private TweenerPlayStyle _style;
        private ITweenSharedState _state;

        public TweenOnceStrategy(ITweenSharedState sharedState)
        {
            _style = TweenerPlayStyle.Once;
            _state = sharedState;
        }

        public void InitializeState()
        {

        }

        public void UpdateCycle()
        {
            
        }

        public bool CanComplete()
        {
            return _state.GetCycleCount() > 0;
        }

        public TweenerPlayStyle GetPlayStyle()
        {
            return _style;
        }

        public void Update(float deltaTime)
        {

        }

        public void Dispose()
        {
        }
    }
}