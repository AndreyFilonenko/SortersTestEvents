namespace _20170223_SortersTestEvents
{
    class BubbleSorter : Sorter
    {
        /// <summary>
        /// Конструктор пузырькового сортировщика.
        /// </summary>
        /// <param name="adNumbers">Сортируемый массив.</param>
        public BubbleSorter(double[] adNumbers)
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
                return "Bubble";
            }
        }
        /// <summary>
        /// Обеспечивает сортировку массива.
        /// </summary>
        public override void Sort()
        {
            bool exit = false;

            do
            {
                exit = false;
                for (int i = 0; i < _adNumbers.Length - 1; i++)
                {
                    if (IsLargerThan(_adNumbers[i], _adNumbers[i + 1]))
                    {
                        Swap(ref _adNumbers[i], ref _adNumbers[i + 1]);
                        exit = true;
                    }
                }
            } while (exit);
        }
    }
}