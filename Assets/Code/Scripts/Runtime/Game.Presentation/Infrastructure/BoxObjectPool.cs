using Game.Presentation.Views;
using UnityEngine;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;

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

        private IObjectResolver _container;

        public int CountInactive => _objectPool.CountInactive;

        [Inject]
        private void Construct(IObjectResolver container)
        {
            _container = container;

            _objectPool = new ObjectPool<BoxView>(
                CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject
            );
        }

        private BoxView CreatePooledItem()
        {
            var view = Instantiate(boxPrefab);

            _container.InjectGameObject(view.gameObject);

            return view;
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