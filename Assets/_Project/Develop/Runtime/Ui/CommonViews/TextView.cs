using TMPro;
using UnityEngine;
using Runtime.Ui.Core;

namespace Runtime.Ui.CommonViews
{
    public class TextView : MonoBehaviour, IView
    {
        [Header("References:")]
        [SerializeField] private TMP_Text _text = null;

        public void SetText(string text)
            => _text.SetText(text);


    }
}