using UnityEngine;

namespace Game.Presentation.Views
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