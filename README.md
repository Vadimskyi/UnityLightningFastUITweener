# Unity Lightning Fast UI Tweener
Simple lightweight tweener library for fast, low-gc ui animation.
## Table of Contents

- [Installation](#installation)
- [Quick Start](#quick-start)
- [Customization](#customization)
- [Author Info](#author-info)

## Installation
This library is distributed via Unity's built-in package manager. Required Unity 2018.3 or later.
Sinse Unity's package manager does not support git-url dependencies you should install them manually, if required.

- Open Unity project
- Navigate to Window->Package Manager menu
- Top left dropdown -> "Add package from git Url"
- Paste https://github.com/Vadimskyi/UnityLightningFastUITweener.git

## Quick Start

An example class shows how to set up tween-job on every button click event.

```csharp
public class ButtonMoveTest : MonoBehaviour
{
    [SerializeField] private Vector2 _tweenDestination;
    [SerializeField] private float _tweenDuration;

    private RectTransform _rectTransform;

    /// <summary>
    /// Working tweener remote control. Use this to handle tween lifetime and callbacks
    /// </summary>
    private ITweenRemoteControl _tweenRemote;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    /// <summary>
    /// Called when Button.onClick invoked.
    /// </summary>
    public void OnButtonClick()
    {
        // Kill previous tween job, if existed
        _tweenRemote?.Kill();
        // Start tween job for RectTransform.anchoredPosition property
        _tweenRemote = _rectTransform.TweenMoveAnchored2D(_tweenDestination, _tweenDuration, TweenerPlayStyle.Once);
    }
}
```

Currently, there are 7 types of tweeners implemented:

```csharp
{
  Graphic.TweenAlpha(float toValue, float duration, TweenerPlayStyle style) // for Graphic.color.a field
  RectTransform.TweenMove2D(Vector2 toValue, float duration, TweenerPlayStyle style) // for RectTransform.localPostion property
  RectTransform.TweenMoveAnchored2D(Vector2 toValue, float duration, TweenerPlayStyle style) // for RectTransform.anchoredPosition property
  RectTransform.TweenSizeDelta2D(Vector2 toValue, float duration, TweenerPlayStyle style) // for RectTransform.sizeDelta property
  RectTransform.TweenScale2D(Vector2 toValue, float duration, TweenerPlayStyle style) // for RectTransform.localScale property
  RectTransform.TweenHorizontalScroll(float toValue, float duration, TweenerPlayStyle style) // for ScrollRect.horizontalNormalizedPosition property
  Transform.TweenScale2D(Vector2 toValue, float duration, TweenerPlayStyle style) // for Transform.localScale property
}
```
You can easily cutomize or add your own tweeners. For more details check out [Customization](#customization)

## Customization

Lets add Transform.rotation tweener:

## Author Info

Vadim Zakrzhewskyi (a.k.a. Vadimskyi) a software developer from Ukraine.

~10 years of experience working with Unity3d, mostly freelance/outsource.

* Twitter: [https://twitter.com/vadimskyi](https://twitter.com/vadimskyi) (English/Russian)