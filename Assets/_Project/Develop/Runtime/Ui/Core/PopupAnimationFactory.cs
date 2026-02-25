using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;
using System;

namespace IJCourseFinalBoss.Assets._Project.Develop.Runtime.Ui.Core
{
    public class PopupAnimationFactory
    {
        public static Sequence CreateShowAnimation(
            CanvasGroup body,
            Image anticlicker,
            PopupAnimationTypes type,
            float anticlickerMaxAlpha)
        {
            switch (type)
            {
                case PopupAnimationTypes.None:
                    return DOTween.Sequence();

                case PopupAnimationTypes.Expand:
                    return DOTween.Sequence()
                        .Append(anticlicker
                            .DOFade(anticlickerMaxAlpha, 0.2f)
                            .From(0f))
                        .Join(body.transform
                            .DOScale(1.0f, 0.5f)
                            .From(0f)
                            .SetEase(Ease.OutBack));
                default:
                    throw new ArgumentException($"{nameof(type)} unknown type!");
            }
        }

        public static Sequence CreateHideAnimation(
            CanvasGroup body,
            Image anticlicker,
            PopupAnimationTypes type,
            float anticlickerMaxAlpha)
        {
            return DOTween.Sequence();
        }
    }
}