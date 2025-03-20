using Game.Controllers;
using Game.Models;
using Game.Systems.Interfaces;
using Game.UI.Views;
using UnityEngine;

namespace Game.Infrastructure
{
    public class BinRepository : IBinRepository
    {
        private BinInstance _binInstance;

        public BinInstance GetBin()
        {
            if (_binInstance == null)
            {
                var view = Object.FindObjectOfType<BinView>();
                var controller = new BinController(view);

                _binInstance = new BinInstance(view, controller);
            }

            return _binInstance;
        }
    }
}