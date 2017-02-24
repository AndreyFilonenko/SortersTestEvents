namespace _20170223_SortersTestEvents
{
    class CombSorter : Sorter
    {
        /// <summary>
        /// Конструктор сортировки расческой.
        /// </summary>
        /// <param name="adNumbers">Сортируемый массив.</param>
        public CombSorter(double[] adNumbers)
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
                return "Comb";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            double gap = _adNumbers.Length;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < _adNumbers.Length)
                {
                    int igap = i + (int)gap;
                    if (IsLargerThan(_adNumbers[i], _adNumbers[igap]))
                    {                        
                        Swap(ref _adNumbers[i], ref _adNumbers[igap]);
                        swaps = true;
                    }
                    i++;
                }
            }
        }
    }
}