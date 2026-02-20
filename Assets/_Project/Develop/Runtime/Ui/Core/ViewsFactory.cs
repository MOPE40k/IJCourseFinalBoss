using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.AssetsManagement;

namespace Runtime.Ui.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader = null;

        private readonly Dictionary<string, string> _viewIdToResourcesPath = new()
        {
            {ViewIds.CurrencyView, "Ui/Wallet/CurrencyView"},
            {ViewIds.MainMenuScreenView, "Ui/MainMenu/MainMenuScreenView"},
            {ViewIds.TestPopup, "Ui/TestPopup"},
        };

        public ViewsFactory(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
        }

        public TView Create<TView>(string viewId, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (_viewIdToResourcesPath.TryGetValue(viewId, out string resourcePath) == false)
                throw new ArgumentException($"You did't set resource path for {typeof(TView)}, searched ID: {viewId}!");

            GameObject prefab = _resourcesAssetsLoader.Load<GameObject>(resourcePath);

            GameObject instance = GameObject.Instantiate(prefab, parent);

            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)} component on view instance");

            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
            => GameObject.Destroy(view.gameObject);
    }
}