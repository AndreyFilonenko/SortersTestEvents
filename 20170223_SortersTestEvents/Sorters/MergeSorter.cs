using System;

namespace _20170223_SortersTestEvents
{
    class MergeSorter : Sorter
    {
        /// <summary>
        ////Конструктор сортировки слиянием.
        /// </summary>
        /// <param name="numbers">Сортируемый массив.</param>
        public MergeSorter(double[] numbers)
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
                return "Merge";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            MergeSort(_adNumbers);
        }
        /// <summary>
        /// Реализует сортировку слиянием.
        /// </summary>
        /// <param name="adItems">Сортируемый массив.</param>
        private void MergeSort(double[] adItems)
        {
            if (adItems.Length <= 1)
            {
                return;
            }
            int iLeftSize = adItems.Length / 2;
            int iRightSize = adItems.Length - iLeftSize;
            double[] adLeft = new double[iLeftSize];
            double[] adRight = new double[iRightSize];
            Array.Copy(adItems, 0, adLeft, 0, iLeftSize);
            Array.Copy(adItems, iLeftSize, adRight, 0, iRightSize);
            MergeSort(adLeft);
            MergeSort(adRight);
            Merge(adItems, adLeft, adRight);
        }        
    }
}