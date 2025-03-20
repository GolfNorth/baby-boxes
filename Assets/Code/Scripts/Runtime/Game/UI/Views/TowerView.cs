using UnityEngine;

namespace Game.UI.Views
{
    /// <summary>
    /// Вьюшка башни
    /// </summary>
    public class TowerView : MonoBehaviour
    {
        [SerializeField, Tooltip("Точка отсчета координат")]
        private Transform pivot;
    }
}