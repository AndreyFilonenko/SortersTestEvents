namespace _20170223_SortersTestEvents
{
    class ShellSorter : Sorter
    {
        /// <summary>
        ////Конструктор сортировки Шелла.
        /// </summary>
        /// <param name="adNumbers">Соритруемый массив.</param>
        public ShellSorter(double[] adNumbers)
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
                return "Shell";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            int j;
            int iStep = _adNumbers.Length / 2;
            while (iStep > 0)
            {
                for (int i = 0; i < (_adNumbers.Length - iStep); ++i)
                {
                    j = i;
                    while (j >= 0 && IsLargerThan(_adNumbers[j], _adNumbers[j + iStep]))
                    {
                        Swap(ref _adNumbers[j], ref _adNumbers[j + iStep]);
                        j -= iStep;
                    }
                }
                iStep = iStep / 2;
            }
        }
    }
}