using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _instance;
        public static UIManager Instance => _instance;

        private void Awake()
        {
            _instance = this;
        }

        public GameObject DebugInterfaceMenu;
        public UIEngineering EngeneerBayMenu;
        public UIKitchen KitchenBayMenu;
        public UIBotanics BotanicsBayMenu;
        public UICargo CargoBayMenu;
        public UIBridge BridgeBayMenu;

        public static void ShowDebugMenu()
        {
            _instance.DebugInterfaceMenu.SetActive(true);
        }

        public static void HideDebugMenu()
        {
            _instance.DebugInterfaceMenu.SetActive(false);
        }

        public static void ShowEngeneerBayMenu()
        {
            _instance.EngeneerBayMenu.Show();
        }

        public static void HideEngeneerBayMenu()
        {
            _instance.EngeneerBayMenu.Hide();
        }

        public static void ShowKitchenBayMenu(Kitchen kitchen)
        {
            _instance.KitchenBayMenu.Show(kitchen);
        }

        public static void HideKitchenBayMenu()
        {
            _instance.KitchenBayMenu.Hide();
        }

        public static void ShowBotanicsMenu(Botanics botanics)
        {
            _instance.BotanicsBayMenu.Show(botanics);
        }

        public static void HideBotanicsMenu()
        {
            _instance.BotanicsBayMenu.Hide();
        }

        public static void ShowCargoMenu(Cargo cargo)
        {
            _instance.CargoBayMenu.Show(cargo);
        }

        public static void HideCargoMenu()
        {
            _instance.CargoBayMenu.Hide();
        }

        public static void ShowBridgeMenu()
        {
            _instance.BridgeBayMenu.Show();
        }

        public static void HideBridgeMenu()
        {
            _instance.BridgeBayMenu.Hide();
        }
    }
}
