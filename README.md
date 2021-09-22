# Unity Lightning Fast UI Tweener
[![openupm](https://img.shields.io/npm/v/com.vadimskyi.lightningfasttweeners?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.vadimskyi.lightningfasttweeners/)

Simple lightweight tweener library for fast, low-gc ui animation.
## Table of Contents

- [Installation](#installation)
    - [Unity Package](#unity-package)
    - [UPM CLI](#upm-cli)
- [Quick Start](#quick-start)
- [Customization](#customization)
- [Author Info](#author-info)

## Installation

This library is distributed via Unity's built-in package manager. Required Unity 2018.3 or later.

### Unity Package
- Open Unity project
- Download and run .unitypackage file from the latest release

### UPM CLI
- You need to have upm-cli installed: https://github.com/openupm/openupm-cli#openupm-cli
- Open Git-Bash, CMD, or PowerShell for Windows console
```console
# go to the unity project folder
$ cd ~/Document/projects/hello-openupm

# add package
$ openupm add com.vadimskyi.lightningfasttweeners
```
- Open Unity for package to be installed

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

Lets add Transform.localRotation tweener. First, create TweenRotationStrategy script:

```csharp
/// <summary>
/// All functionality is described in abstract class MonoStrategyBase.
/// MonoStrategyBase generic argument type is the type of the field we want to change (in this example, Quaternion is the type of Transform.localRotation field)
/// </summary>
public class TweenRotationStrategy : MonoStrategyBase<Quaternion>
{
    private Transform _target;
    private Quaternion _defaultValue;
    
    /// <param name="target">Target object for tweening</param>
    /// <param name="sharedState">Twinning value data (from, to, duration)</param>
    /// <param name="modHandler">Value modifier handler. Handle value change over time.</param>
    /// <param name="style">Tween style strategy</param>
    public TweenRotationStrategy(
        Transform target,
        ITweenSharedState sharedState,
        IValueModifier<Quaternion> modHandler,
        ITweenPlayStyleStrategy style) : base(target, sharedState, modHandler, style)
    {
        _target = target;
        _defaultValue = _target.localRotation;
    }

    /// <summary>
    /// Every time value updated this method is being called.
    /// We need to assign updated value to the target property.
    /// </summary>
    /// <param name="value">updated value</param>
    public override void OnValueUpdated(Quaternion value)
    {
        _target.localRotation = value;
    }

    public override void ResetValueToDefault()
    {
        _target.localRotation = _defaultValue;
    }
}
```

After that, just create extension method for our new tweener:

```csharp
public static class TweenExtend
{
    public static ITweenRemoteControl TweenRotate2D(this Transform target, Vector3 toValue, float duration, TweenerPlayStyle style)
    {
        TweenQuaternionSharedState state = new TweenQuaternionSharedState(
            target.localRotation.eulerAngles, 
            toValue, 
            duration);

        var tween = new TweenRotationStrategy(
            target,
            state,
            new QuaternionValueModifier(state),
            CreatePlayStyle(state, style));

        TweenUpdaterMono.Instance.Subscribe(tween);

        return tween.GetRemote();
    }
}
```
And finally how to use it:

```csharp
private RectTransform _rectTransform;

public void Use()
{
    _rectTransform.TweenRotate2D(_tweenDestination, _tweenDuration, TweenerPlayStyle.PingPong);
}
```

## Author Info

Vadim Zakrzhewskyi (a.k.a. Vadimskyi) a software developer from Ukraine.

~10 years of experience working with Unity3d, mostly freelance/outsource.

* Twitter: [https://twitter.com/vadimskyi](https://twitter.com/vadimskyi) (English/Russian)
