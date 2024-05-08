using Input_Feature;
using System;
using System.Reactive.Subjects;
using UnityEngine;
using WKosArch;
using WKosArch.Reactive;
using WKosArch.Services.Scenes;

public class InputTextHudModel : HudViewModel
{
    public IObservable<string> ObservableVectorText => _observableVectorText;
    public IObservable<string> SomeReactivePropertyText => _someReactivePropertyText;

    private readonly Subject<string> _observableVectorText = new();
    private readonly ReactiveProperty<string> _someReactivePropertyText = new();

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
