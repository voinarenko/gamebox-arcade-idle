using UnityEngine;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Обработка нажатия мыши.
    /// </summary>
    public class ClickProcessing : MonoBehaviour
    {
        private Game Game => GetComponent<Game>();

        private void Update()
        {
            if (Game.OverUi) return;

            if (!Input.GetMouseButtonDown(0)) return;
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(camRay, out var hitInfo)) return;
            if (hitInfo.transform.CompareTag(Game.GroundTag)) Game.Move(Game.MousePosition);

            if (hitInfo.transform.CompareTag(Game.ShopTag))
            {
                Game.WaitForClick = false;
                Game.MoveToTrade = true;
                Game.MoveToTradePosition = hitInfo.transform.position;
                Game.Move(hitInfo.transform.position);
            }

            if ((hitInfo.transform.CompareTag(Game.TreeTag) && Game.NearRock) || (hitInfo.transform.CompareTag(Game.RockTag) && Game.NearTree))
            {
                Game.MoveToCollect = true;
                Game.MoveToCollectPosition = hitInfo.transform.position;
                Game.Move(hitInfo.transform.position);
            }
            else if ((hitInfo.transform.CompareTag(Game.TreeTag) && Game.NearTree) || (hitInfo.transform.CompareTag(Game.RockTag) && Game.NearRock))
            {
                Game.WaitForClick = false;
                Game.MoveToCollect = true;
                Game.MoveToCollectPosition = hitInfo.transform.position;
                Game.Move(hitInfo.transform.position);
            }
            else if (hitInfo.transform.CompareTag(Game.TreeTag) || hitInfo.transform.CompareTag(Game.RockTag))
            {
                Game.WaitForClick = false;
                Game.MoveToCollect = true;
                Game.MoveToCollectPosition = hitInfo.transform.position;
                Game.Move(hitInfo.transform.position);
            }
        }
    }
}