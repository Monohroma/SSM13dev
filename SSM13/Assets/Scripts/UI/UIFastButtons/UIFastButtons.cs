using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIFastButtons : MonoBehaviour
    {
        public GameObject buttons;
        public Engineering eng;
        public Kitchen kitchen;
        public Botanics botanics;
        public Cargo cargo;
        public Bridge bridge;

        public void PressButton(int i)
        {
            switch(i)
            {
                case 0:
                    eng.OpenMenu();
                    break;
                case 1:
                    kitchen.OpenMenu();
                    break;
                case 2:
                    botanics.ShowMenu();
                    break;
                case 3:
                    cargo.ShowMenu();
                    break;
                case 4:
                    bridge.OpenMenu();
                    break;
            }
        }

        public void ShowHide()
        {
            buttons.SetActive(!buttons.activeSelf);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                PressButton(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PressButton(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PressButton(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                PressButton(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                PressButton(4);
            }
        }
    }
}
