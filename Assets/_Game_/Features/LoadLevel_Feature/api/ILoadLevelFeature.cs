using System;
using WKosArch.Domain.Features;

namespace WKosArch.Features.LoadLevelFeature
{
	public interface ILoadLevelFeature : IFeature, IDisposable
    {
		void LoadGameLevelEnviroment();
        void PlayStartLevelAnimation();
        void SceneReadyToStart();
    } 
}