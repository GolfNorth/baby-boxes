using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Presentation.Infractructure
{
    /// <summary>
    /// Пул для создания коробок
    /// </summary>
    public class BoxObjectPool : MonoBehaviour, IObjectPool<BoxView>
    {
        [SerializeField]
        private BoxView boxPrefab;

        private ObjectPool<BoxView> _objectPool;

        public int CountInactive => _objectPool.CountInactive;

        private void Awake()
        {
            BoxView.ObjectPool = this;

            _objectPool = new ObjectPool<BoxView>(
                CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject
            );
        }

        private BoxView CreatePooledItem()
        {
            return Instantiate(boxPrefab);
        }

        private void OnTakeFromPool(BoxView view)
        {
            view.gameObject.SetActive(true);
        }

        private void OnReturnedToPool(BoxView view)
        {
            view.gameObject.SetActive(false);
        }

        private void OnDestroyPoolObject(BoxView view)
        {
            Destroy(view.gameObject);
        }

        #region IObjectPool

        public BoxView Get()
        {
            return _objectPool.Get();
        }

        public PooledObject<BoxView> Get(out BoxView v)
        {
            return _objectPool.Get(out v);
        }

        public void Release(BoxView element)
        {
            _objectPool.Release(element);
        }

        public void Clear()
        {
            _objectPool.Clear();
        }

        #endregion
    }
}