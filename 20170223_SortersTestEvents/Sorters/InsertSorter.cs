using System;

namespace _20170223_SortersTestEvents
{
    class InsertSorter : Sorter
    {
        /// <summary>
        ////Конструктор Сортировки вставкой.
        /// </summary>
        /// <param name="_adNumbers">Сортируемый массив.</param>
        public InsertSorter(double[] _adNumbers)
            : base(_adNumbers)
        {
        }
        /// <summary>
        /// Свойство "Имя сортировки".
        /// </summary>
        public override string SortName
        {
            get
            {
                return "Insert";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            int iSortedRangeEndIndex = 1;

            while (iSortedRangeEndIndex < _adNumbers.Length)
            {
                if (IsLargerThan(_adNumbers[iSortedRangeEndIndex - 1], _adNumbers[iSortedRangeEndIndex]))
                {
                    int iInsertIndex = FindInsertionIndex(_adNumbers, _adNumbers[iSortedRangeEndIndex]);
                    Insert(_adNumbers, iInsertIndex, iSortedRangeEndIndex);
                }
                ++iSortedRangeEndIndex;
            }
        }
        /// <summary>
        /// Обеспечивает поиск индекса вставки.
        /// </summary>
        /// <param name="items">Сортируемый массив.</param>
        /// <param name="dValueToInsert">Вставляемое значение.</param>
        /// <returns>Индекс вставки.</returns>
        private int FindInsertionIndex(double[] items, double dValueToInsert)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if (IsLargerThan(_adNumbers[i], dValueToInsert))
                {
                    return i;
                }
            }
            throw new InvalidOperationException("The insertion index was not found");
        }
        /// <summary>
        /// Реализует вставку элемента в массив.
        /// </summary>
        /// <param name="adItemArray">Сортируемый массив.</param>
        /// <param name="iIndexInsertingAt">Индекс вставки элемента.</param>
        /// <param name="iIndexInsertingFrom">Индекс исходного элемента.</param>
        private void Insert(double[] adItemArray, int iIndexInsertingAt, int iIndexInsertingFrom)
        {
            // Поскольку вставка равноценна обмену то генерим событие.
            if (_se != null)
            {
                _se(this, new SortEventArgs(EventType.Swap));
            }
            double dTemp = adItemArray[iIndexInsertingAt];
            adItemArray[iIndexInsertingAt] = adItemArray[iIndexInsertingFrom];
            for (int i = iIndexInsertingFrom; i > iIndexInsertingAt; --i)
            {
                adItemArray[i] = adItemArray[i - 1];
            }
            adItemArray[iIndexInsertingAt + 1] = dTemp;
        }
    }
}