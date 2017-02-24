namespace _20170223_SortersTestEvents
{
    class CocktailSorter : Sorter
    {
        /// <summary>
        ////Конструктор шейкерной сортировки.
        /// </summary>
        /// <param name="adNumbers">Сортируемый массив.</param>
        public CocktailSorter(double[] adNumbers)
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
                return "Cocktail";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            int iLeft = 0;
            int iRight = _adNumbers.Length - 1;

            while (iLeft <= iRight)
            {
                for (int i = iLeft; i < iRight; ++i)
                {
                    if (IsLargerThan(_adNumbers[i], _adNumbers[i + 1]))
                        Swap(ref _adNumbers[i], ref _adNumbers[i + 1]);
                }
                --iRight;

                for (int i = iRight; i > iLeft; --i)
                {
                    if (IsLargerThan(_adNumbers[i - 1], _adNumbers[i]))
                        Swap(ref _adNumbers[i - 1], ref _adNumbers[i]);
                }
                ++iLeft;
            }
        }
    }
}