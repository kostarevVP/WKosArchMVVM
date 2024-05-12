using Input_Feature;
using System;
using System.Reactive.Subjects;
using UnityEngine;
using WKosArch;
using WKosArch.Reactive;

public class InputTextHudModel : HudViewModel
{
    public IObservable<string> ObservableVectorText => _subjectVectorText;
    public IObservable<string> SomeReactivePropertyText => _reactivePropertyVectorText;


    private readonly Subject<string> _subjectVectorText = new();
    private readonly ReactiveProperty<string> _reactivePropertyVectorText = new();

    private IInputFeature _inputFeature;

    public InputTextHudModel()
    {
        _subjectVectorText.OnNext($"{Vector2.zero}");
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
        _subjectVectorText.OnNext($"{vector}");
        _reactivePropertyVectorText.Value = vector.ToString();
    }
}
