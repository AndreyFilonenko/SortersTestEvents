namespace _20170223_SortersTestEvents
{
    class SelectionSorter : Sorter
    {
        /// <summary>
        ////Конструктор сортировки выбором.
        /// </summary>
        /// <param name="numbers">Сортируемый массив.</param>
        public SelectionSorter(double[] numbers)
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
                return "Selection";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            int iSortedRangeEnd = 0;

            while (iSortedRangeEnd < _adNumbers.Length)
            {
                int iNextIndex = FindIndexOfSmallestFromIndex(_adNumbers, iSortedRangeEnd);
                Swap(ref _adNumbers[iSortedRangeEnd], ref _adNumbers[iNextIndex]);
                ++iSortedRangeEnd;
            }
        }
        /// <summary>
        /// Обеспечивает поиск индекса наименьшего элемента подмассива.
        /// </summary>
        /// <param name="adItems">Сортируемый массива.</param>
        /// <param name="iSortedRangeEnd">Индекс отстортированной области.</param>
        /// <returns>Индекс наименьшего элемента.</returns>
        private int FindIndexOfSmallestFromIndex(double[] adItems, int iSortedRangeEnd)
        {
            double dCurrentSmallest = adItems[iSortedRangeEnd];
            int iCurrentSmallestIndex = iSortedRangeEnd;

            for (int i = iSortedRangeEnd + 1; i < adItems.Length; ++i)
            {
                if (IsLargerThan(dCurrentSmallest, _adNumbers[i]))
                {
                    dCurrentSmallest = adItems[i];
                    iCurrentSmallestIndex = i;
                }
            }
            return iCurrentSmallestIndex;
        }
    }
}