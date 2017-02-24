namespace _20170223_SortersTestEvents
{
    class HeapSorter : Sorter
    {
        /// <summary>
        ////Конструктор сортировки кучей.
        /// </summary>
        /// <param name="adNumbers">Сортируемый массив.</param>
        public HeapSorter(double[] adNumbers)
            : base(adNumbers)
        {
        }
        /// <summary>
        /// Свойство "Имя сортировки".
        /// </summary>
        public override string SortName
        {
            get
            {
                return "Heap";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            HeapSort(_adNumbers, _adNumbers.Length);
        }
        /// <summary>
        /// Реализует сортировку двоичной кучей.
        /// </summary>
        /// <param name="adArray">Сортируемый массив.</param>
        /// <param name="iLength">Длинна области сортировки.</param>
        private void HeapSort(double[] adArray, int iLength)
        {
            for (int i = iLength / 2 - 1; i >= 0; --i)
            {
                long lPreviousI = i;
                i = AddToPyramid(adArray, i, iLength);
                if (lPreviousI != i)
                {
                    ++i;
                }
            }
            for (int k = iLength - 1; k > 0; --k)
            {
                Swap(ref adArray[0], ref adArray[k]);
                int i = 0;
                int lPreviousI = -1;
                while (i != lPreviousI)
                {
                    lPreviousI = i;
                    i = AddToPyramid(adArray, i, k);
                }
            }
        }
        /// <summary>
        /// Добавляет элемент в кучу.
        /// </summary>
        /// <param name="adArray">Сортируемый массив.</param>
        /// <param name="i">Добавляемый элемент.</param>
        /// <param name="N">Конец области сортировки.</param>
        /// <returns></returns>
        private int AddToPyramid(double[] adArray, int i, int N)
        {
            int iIMax;
            if ((2 * i + 2) < N)
            {
                if (adArray[2 * i + 1] < adArray[2 * i + 2])
                {
                    iIMax = 2 * i + 2;
                }
                else
                {
                    iIMax = 2 * i + 1;
                }
            }
            else
            {
                iIMax = 2 * i + 1;
            }
            if (iIMax >= N)
            {
                return i;
            }
            if (IsLargerThan(adArray[iIMax], adArray[i]))
            {
                Swap(ref adArray[i], ref adArray[iIMax]);
                if (iIMax < N / 2)
                {
                    i = iIMax;
                }
            }
            return i;
        }
    }
}