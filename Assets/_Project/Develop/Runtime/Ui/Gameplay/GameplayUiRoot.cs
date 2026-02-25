using UnityEngine;

namespace Runtime.Ui.Gameplay
{
    public class GameplayUiRoot : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private Transform _hudLayer = null;
        [SerializeField] private Transform _popupsLayer = null;
        [SerializeField] private Transform _vfxUnderPopusLayer = null;
        [SerializeField] private Transform _vfxOverPopupsLayer = null;

        // Runtime
        public Transform HudLayer => _hudLayer;
        public Transform PopupsLayer => _popupsLayer;
        public Transform VfxUnderPopupsLayer => _vfxUnderPopusLayer;
        public Transform VfxOverPopupsLayer => _vfxOverPopupsLayer;
    }
}