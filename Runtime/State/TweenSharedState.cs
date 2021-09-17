/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

namespace VadimskyiLab.UiExtension
{
    public sealed class TweenSharedState<T> : ITweenSharedState
    {
        public T FromValue;
        public T ToValue;
        public float Duration;
        public int CycleCount;

        public TweenSharedState()
        {
            CycleCount = 0;
        }

        public void SetDuration(float val)
        {
            Duration = val;
        }

        public float GetDuration() => Duration;

        public int GetCycleCount() => CycleCount;

        public void IncrementCycleCount()
        {
            CycleCount++;
        }

        public void Swap()
        {
            var tmp = FromValue;
            FromValue = ToValue;
            ToValue = tmp;
        }
    }
}