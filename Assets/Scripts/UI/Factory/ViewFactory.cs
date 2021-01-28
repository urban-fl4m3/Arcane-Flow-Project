using System.Collections.Generic;
using Modules.Logger;
using Modules.Render.Managers;
using UI.Data;
using UI.Helpers;
using UI.Views;
using UnityEngine;
using ILogger = Modules.Logger.ILogger;

namespace UI.Factory
{
    public class ViewFactory : IViewFactory
    {
        private readonly ICameraManager _cameraManager;
        private readonly ILogger _logger;
        private readonly CanvasContainer _canvasContainer;
        private readonly ViewsContainer _viewsContainer;
        
        private readonly Dictionary<string, Canvas> _canvasInstances = new Dictionary<string, Canvas>();
        
        public ViewFactory(CanvasContainer canvasContainer, ViewsContainer viewsContainer,
            ICameraManager cameraManager, ILoggerManager loggerManager)
        {
            _cameraManager = cameraManager;
            _canvasContainer = canvasContainer;
            _viewsContainer = viewsContainer;
            _logger = loggerManager.GetLogger();
        }

        public BaseView CreateWindow(Window viewType)
        {
            GetMainCanvas();

            var view = _viewsContainer.GetView(viewType);

            if (view == null)
            {
                _logger.Log($"{nameof(_viewsContainer)} doesn't have {viewType} window.");
                return null;
            }

            return Object.Instantiate(view, GetMainCanvas().transform);
        }
        
        private Canvas GetMainCanvas()
        {
            var mainCanvasId = _canvasContainer.MainCanvas.GetInstanceID().ToString();
            if (!_canvasInstances.ContainsKey(mainCanvasId))
            {
                var canvas = Object.Instantiate(_canvasContainer.MainCanvas);
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = _cameraManager.GameCamera.Component;
                canvas.planeDistance = 1.0f;
                _canvasInstances.Add(mainCanvasId, canvas);
            }

            return _canvasInstances[mainCanvasId];
        }
    }
}