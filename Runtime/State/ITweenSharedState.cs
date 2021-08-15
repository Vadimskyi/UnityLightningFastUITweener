/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

namespace VadimskyiLab.UiExtension
{
    public interface ITweenSharedState
    {
        void SetDuration(float val);
        float GetDuration();
        int GetCycleCount();
        void Swap();
    }
}