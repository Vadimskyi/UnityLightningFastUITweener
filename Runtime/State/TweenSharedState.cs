/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

namespace VadimskyiLab.UiExtension
{
    public class TweenSharedState<T> : ITweenSharedState
    {
        public T FromValue;
        public T ToValue;
        public T CurrentValue;
        public float Duration;
        public int CycleCount;
        public int MaxLoops;

        public TweenSharedState(T fromValue, T toValue, float duration)
        {
            FromValue = fromValue;
            CurrentValue = fromValue;
            ToValue = toValue;
            Duration = duration;
            CycleCount = 0;
            MaxLoops = 1;
        }

        public void SetDuration(float val)
        {
            Duration = val;
        }

        public void SetLoops(int count)
        {
            MaxLoops = count;
        }

        public float GetDuration() => Duration;

        public int GetCycleCount() => CycleCount;

        public int GetMaxLoops() => MaxLoops;

        public void IncrementCycleCount()
        {
            CycleCount++;
        }

        public virtual void Swap()
        {
            var tmp = FromValue;
            FromValue = ToValue;
            ToValue = tmp;
        }
    }
}