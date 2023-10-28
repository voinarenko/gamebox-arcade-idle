using Assets.Scripts.Common;
using Assets.Scripts.UI.Buttons;
using Assets.Scripts.UI.Screens;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    /// <summary>
    ///     Активатор подсказки.
    /// </summary>
    public class TooltipEnabler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private static Tooltip Tooltip => FindAnyObjectByType<Tooltip>(FindObjectsInactive.Include);
        private Inventory Inventory => GetComponent<Item>().Inventory;
        private ActionButton ActionButton => GetComponent<ActionButton>();


        public void OnPointerEnter(PointerEventData eventData)
        {
            Tooltip.gameObject.SetActive(true);
            var item = eventData.pointerEnter.GetComponent<Item>();
            UpdateData(item);
            ActionButton.TooltipEnabler = this;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Tooltip.Name.text = "";
            Tooltip.Info.text = "";
            Tooltip.Data.text = "";
            Tooltip.gameObject.SetActive(false);
        }

        public void UpdateData(Item item)
        {
            Tooltip.Name.text = GetData(item.Resource, item.Id, item.Value)[0];
            Tooltip.Info.text = GetData(item.Resource, item.Id, item.Value)[1];
            Tooltip.Data.text = GetData(item.Resource, item.Id, item.Value)[2];
        }

        /// <summary>
        /// Метод получения данных для отображения в подсказке
        /// </summary>
        /// <param name="resource">ресурс ли объект</param>
        /// <param name="id">индекс</param>
        /// <param name="value">значение</param>
        /// <returns></returns>
        private string[] GetData(bool resource, int id, int value)
        {
            var result = new string[3];
            switch (resource)
            {
                case true:
                    result[0] = id switch
                    {
                        0 => "Дерево",
                        1 => "Камень",
                        _ => result[0]
                    };
                    result[1] = "";
                    result[2] = $"{Inventory.GetResourcePrice(id) * value} золота";
                    break;
                case false:
                    switch (id)
                    {
                        case 0:
                            result[0] = "Топор";
                            result[1] = "для добычи дерева";
                            break;
                        case 1:
                            result[0] = "Кирка";
                            result[1] = "для добычи камня";
                            break;
                    }

                    result[2] = $"{Inventory.GetToolPrice(id)} золота";
                    break;
            }

            return result;
        }
    }
}