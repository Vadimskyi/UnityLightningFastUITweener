/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */
using UnityEngine;
using UnityEngine.UI;

namespace VadimskyiLab.Utils
{
    public static class GraphicExtend
    {
        public static void SetAlpha(this Graphic source, float a)
        {
            if (source == null || source.IsDestroyed() || !source) return;
            source.color = new Color(source.color.r, source.color.g, source.color.b, a);
        }

        public static float GetAlpha(this Graphic source)
        {
            if (source == null || source.IsDestroyed() || !source) return 0;
            return source?.color.a ?? 0;
        }
    }
}
