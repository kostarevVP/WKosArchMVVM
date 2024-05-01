﻿using UnityEngine;
using Cysharp.Threading.Tasks;
using WKosArch.Domain.Contexts;
using WKosArch.DependencyInjection;

namespace WKosArch.Application
{
    public static class Game
    {
        public static ProjectContext ProjectContext { get; set; }

        private static bool _iSsStarted { get; set; }

        private static bool _gameStarting { get; set; }

        public static async UniTask StartGameAsync(ProjectContext projectContext)
        {
            if (!_iSsStarted && !_gameStarting)
            {
                _gameStarting = true;

                ProjectContext = projectContext;

                DI.AddRootDIContainer(projectContext.Container);
                
                if (projectContext != null)
                {
                    await ProjectContext.InitializeAsync();
                }

                _iSsStarted = true;
                _gameStarting = false;
            }
        }


        //need for not Reload Domain each time
        // ProjectSetting > Editor > Enter Play Mode Setting
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            _gameStarting = false;
            _iSsStarted = false;
        }
    }
}