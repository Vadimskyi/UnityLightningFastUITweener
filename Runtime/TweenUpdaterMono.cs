/* Copyright (C) 2021 Vadimskyi - All Rights Reserved
 * Github - https://github.com/Vadimskyi
 * Website - https://www.vadimskyi.com/
 * You may use, distribute and modify this code under the
 * terms of the GPL-3.0 License.
 */

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VadimskyiLab.UiExtension
{
    /// <summary>
    /// Simple UI animation updater system
    /// </summary>
    public class TweenUpdaterMono : MonoBehaviour
    {
        private IList<ITweenComponentStrategy> _subscribers;

        private void Awake()
        {
            DontDestroyOnLoad(this);

            _instance = this;
            _subscribers = new List<ITweenComponentStrategy>();
        }

        private void Update()
        {
            if(_subscribers.Count == 0) return;
            RemoveCompleted();
            foreach (var sub in _subscribers.ToArray())
            {
                sub.UpdateComponent(Time.deltaTime);
            }
        }

        public void Subscribe(ITweenComponentStrategy com)
        {
            if (com.CanComplete())
            {
                com.UpdateComponent(Time.deltaTime);
                RemoveCompleted();
                return;
            }

            _subscribers.Add(com);
        }

        private void RemoveCompleted()
        {
            for (int i = 0; i < _subscribers.Count; i++)
            {
                var sub = _subscribers[i];
                if (sub.GetState() != TweenComponentState.Completed && sub.GetState() != TweenComponentState.Killed) continue;

                _subscribers.RemoveAt(i);
                --i;
            }
        }

        public static TweenUpdaterMono Instance => _instance = _instance ?? new GameObject(nameof(TweenUpdaterMono),typeof(TweenUpdaterMono)).GetComponent<TweenUpdaterMono>();
        private static TweenUpdaterMono _instance;
    }
}