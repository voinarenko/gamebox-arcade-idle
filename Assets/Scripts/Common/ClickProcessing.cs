using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Обработка нажатия мыши.
    /// </summary>
    public class ClickProcessing : MonoBehaviour
    {
        private Game _game;

        private void Start() => _game = GetComponent<Game>();

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(camRay, out var hitInfo)) return;
            if (hitInfo.transform.CompareTag(_game.Constants.GroundTag)) _game.Move(_game.MousePosition);

            if (hitInfo.transform.CompareTag(_game.ShopTag))
            {
                _game.WaitForClick = false;
                _game.MoveToTrade = true;
                _game.MoveToTradePosition = hitInfo.transform.position;
                _game.Move(hitInfo.transform.position);
            }

            if ((hitInfo.transform.CompareTag(_game.TreeTag) && _game.NearRock) || (hitInfo.transform.CompareTag(_game.RockTag) && _game.NearTree))
            {
                _game.MoveToCollect = true;
                _game.MoveToCollectPosition = hitInfo.transform.position;
                _game.Move(hitInfo.transform.position);
            }
            else if ((hitInfo.transform.CompareTag(_game.TreeTag) && _game.NearTree) || (hitInfo.transform.CompareTag(_game.RockTag) && _game.NearRock))
            {
                _game.WaitForClick = false;
                _game.MoveToCollect = true;
                _game.MoveToCollectPosition = hitInfo.transform.position;
                _game.Move(hitInfo.transform.position);
            }
            else if (hitInfo.transform.CompareTag(_game.TreeTag) || hitInfo.transform.CompareTag(_game.RockTag))
            {
                _game.WaitForClick = false;
                _game.MoveToCollect = true;
                _game.MoveToCollectPosition = hitInfo.transform.position;
                _game.Move(hitInfo.transform.position);
            }
        }
    }
}