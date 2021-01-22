using System;
using UI.Helpers;
using UI.Views;
using UnityEngine;

namespace UI.Data.Models
{
    [Serializable]
    public class WindowViewModel
    {
        [SerializeField] private Window _type;
        [SerializeField] private BaseView _view;

        public Window Type => _type;
        public BaseView View => _view;
    }
}