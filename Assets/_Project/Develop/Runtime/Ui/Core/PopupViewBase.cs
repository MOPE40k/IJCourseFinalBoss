using System;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using IJCourseFinalBoss.Assets._Project.Develop.Runtime.Ui.Core;

namespace Runtime.Ui.Core
{
    public class PopupViewBase : MonoBehaviour, IShowableView
    {
        // Delegates
        public event Action CloseRequest = null;

        [Header("References:")]
        [SerializeField] private CanvasGroup _mainGroup = null;
        [SerializeField] private Image _anticlicker = null;
        [SerializeField] private CanvasGroup _body = null;
        [SerializeField] private PopupAnimationTypes _animationType = PopupAnimationTypes.None;

        // Runtime
        private float _anticlickerDefaultAlpha = 0f;
        private Tween _currentTween = null;

        private void Awake()
        {
            _anticlickerDefaultAlpha = _anticlicker.color.a;

            _mainGroup.alpha = 0f;
        }

        public void OnCloseButtonClicked()
            => CloseRequest?.Invoke();

        public Tween Show()
        {
            KillCurrentTween();

            OnPreShow();

            _mainGroup.alpha = 1f;

            Sequence animation = PopupAnimationFactory
                .CreateShowAnimation(_body, _anticlicker, _animationType, _anticlickerDefaultAlpha)
                .OnComplete(OnPostShow);

            ModifyShowAnimation(animation);

            _currentTween = animation;

            return _currentTween.SetUpdate(true).Play();
        }

        public Tween Hide()
        {
            KillCurrentTween();

            OnPreHide();

            Sequence animation = PopupAnimationFactory
                .CreateHideAnimation(_body, _anticlicker, _animationType, _anticlickerDefaultAlpha)
                .OnComplete(OnPostHide);

            ModifyHideAnimation(animation);

            _currentTween = animation;

            return _currentTween.SetUpdate(true).Play();
        }

        protected virtual void ModifyShowAnimation(Sequence tweenSequence)
        { }

        protected virtual void ModifyHideAnimation(Sequence tweenSequence)
        { }

        protected virtual void OnPostShow()
        { }

        protected virtual void OnPreShow()
        { }

        protected virtual void OnPreHide()
        { }

        protected virtual void OnPostHide()
        { }

        private void OnDestroy()
            => KillCurrentTween();

        private void KillCurrentTween()
            => _currentTween?.Kill();
    }
}