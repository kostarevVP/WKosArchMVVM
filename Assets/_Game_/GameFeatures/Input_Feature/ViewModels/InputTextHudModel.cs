using Input_Feature;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using UnityEngine;
using WKosArch;
using WKosArch.Reactive;
using WKosArch.Services.Scenes;

public class InputTextHudModel : HudViewModel
{
    public IObservable<string> ObservableVectorText => _observableVectorText;
    public IObservable<string> SomeReactivePropertyText => _someReactivePropertyText;

    public IObservable<Vector2> Vector2FromScreenJoystick => _observableVector2;

    private readonly Subject<string> _observableVectorText = new();
    private readonly ReactiveProperty<string> _someReactivePropertyText = new();
    private readonly ReactiveProperty<Vector2> _someReactiveVector2 = new();
    private readonly IObservable<Vector2> _observableVector2;


    private IInputFeature _inputFeature;

    public InputTextHudModel()
    {
        _observableVectorText.OnNext($"{Vector2.zero}");
        //_observableVectorText.OnNext("Your awesome observableText");
        //_someReactivePropertyText.Value = "Your awesome reactivePropertyText";

    }

    public override void Subscribe()
    {
        _inputFeature = DiContainer.Resolve<IInputFeature>();
        _inputFeature.OnJoystickVectorEvent += ReciveMoveVector;
        ReciveMoveVector(Vector2.zero);
    }

    public override void Unsubscribe()
    {
        _inputFeature.OnJoystickVectorEvent -= ReciveMoveVector;
    }

    private void ReciveMoveVector(Vector2 vector)
    {
        _observableVectorText.OnNext($"{vector}");
    }
}
