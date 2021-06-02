using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIPlant2Panel : MonoBehaviour
    {
        public UICell Cell1;
        public UICell Cell2;
        private UIBotanics _botanics;

        public void SetupCells(UIBotanics botanics, Cell cell1)
        {
            _botanics = botanics;
            Cell1.gameObject.SetActive(true);
            Cell1.Setup(cell1);
            Cell2.gameObject.SetActive(false);
            Cell2.Clear();
            _botanics.cells.Add(Cell1);
        }

        public void SetupCells(UIBotanics botanics, Cell cell1, Cell cell2)
        {
            _botanics = botanics;
            Cell1.gameObject.SetActive(true);
            Cell1.Setup(cell1);
            Cell2.gameObject.SetActive(true);
            Cell2.Setup(cell2);
            _botanics.cells.Add(Cell1);
            _botanics.cells.Add(Cell2);
        }
    }
}
