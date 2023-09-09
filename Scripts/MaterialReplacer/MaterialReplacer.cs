using BaseCustomFactions.Scripts.Logging;
using UnityEngine;

namespace BaseCustomFactions.Scripts.MaterialReplacer
{
    public class MaterialReplacer : MonoBehaviour
    {
        private readonly ILog _logger = LogFactory.GetLogger(typeof(MaterialReplacer), LogLevelsEnum.All);
        
        public bool shouldInUpdate = false;


        public Material swapMaterial;

        private MeshRenderer _meshRenderer;
        
        public void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _logger.Debug($"Swap status is: {Swap()}");
        }

        private void Update()
        {
            if (shouldInUpdate)
            {
                Swap();
            }
        }

        private bool Swap()
        {
            if (_meshRenderer == null){return false;}

            _meshRenderer.material = swapMaterial;
            return true;
        }
    }
}