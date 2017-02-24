namespace _20170223_SortersTestEvents
{
    class QuickSorter : Sorter
    {
        /// <summary>
        ////Конструктор быстрйо сортировки.
        /// </summary>
        /// <param name="numbers">Сортируемый массив.</param>
        public QuickSorter(double[] numbers)
            : base(numbers)
        {
        }
        /// <summary>
        /// Свойство "Имя сортировки".
        /// </summary>
        public override string SortName
        {
            get
            {
                return "Quick";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку.
        /// </summary>
        public override void Sort()
        {
            Quicksort(_adNumbers, 0, _adNumbers.Length - 1);
        }
        /// <summary>
        /// Обеспечивает реализацию быстрой сортировки.
        /// </summary>
        /// <param name="adItems">Сортируемый массив.</param>
        /// <param name="iLeft">Крайний левый элемент.</param>
        /// <param name="iRight">Крайний правый элемент.</param>
        private void Quicksort(double[] adItems, int iLeft, int iRight)
        {
            if (iLeft < iRight)
            {
                int iPivotIndex = (iLeft + iRight) / 2;
                int iNewPivot = Partition(adItems, iLeft, iRight, iPivotIndex);
                Quicksort(adItems, iLeft, iNewPivot - 1);
                Quicksort(adItems, iNewPivot + 1, iRight);
            }
        }
        /// <summary>
        /// Обеспечивает разделение сортируемого массива.
        /// </summary>
        /// <param name="adItems">Сортируемый массив.</param>
        /// <param name="iLeft">Крайний левый элемент.</param>
        /// <param name="iRight">Крайний правый элемент.</param>
        /// <param name="iPivotIndex">Индекс опорного элемента.</param>
        /// <returns>Индекс разделителя.</returns>
        private int Partition(double[] adItems, int iLeft, int iRight, int iPivotIndex)
        {
            double dPivotValue = adItems[iPivotIndex];
            Swap(ref adItems[iPivotIndex], ref adItems[iRight]);
            int iStoreIndex = iLeft;
            for (int i = iLeft; i < iRight; i++)
            {
                if (IsLargerThan(dPivotValue, adItems[i]))
                {
                    Swap(ref adItems[i], ref adItems[iStoreIndex]);
                    ++iStoreIndex;
                }
            }
            Swap(ref adItems[iStoreIndex], ref adItems[iRight]);
            return iStoreIndex;
        }
    }
}