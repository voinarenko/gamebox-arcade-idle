using UnityEngine;

namespace Assets.Scripts
{
    public class Target : MonoBehaviour
    {
        private Renderer _renderer;

        // Start is called before the first frame update
        private void Start()
        {
            _renderer = GetComponentInChildren<Renderer>();
        }

        private void OnMouseEnter()
        {
            _renderer.material.color = Color.red;
        }

        private void OnMouseExit()
        {
            _renderer.material.color = Color.white;
        }
    }
}