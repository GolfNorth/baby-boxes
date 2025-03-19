using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Game.UI.Components
{
    /// <summary>
    /// Маска для выреза
    /// </summary>
    public class CutoutMask : Image
    {
        public override Material materialForRendering
        {
            get
            {
                var result = new Material(base.materialForRendering);
                result.SetFloat("_StencilComp", (float)CompareFunction.NotEqual);

                return result;
            }
        }
    }
}