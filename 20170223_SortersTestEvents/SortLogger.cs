using System.Diagnostics;

namespace _20170223_SortersTestEvents
{
    /// <summary>
    /// Класс логгера сортировки.
    /// </summary>
    public class SortLogger
    {
        /// <summary>
        /// Конструктор логгера.
        /// </summary>
        /// <param name="s">Логгируемый сортировщик.</param>
        public SortLogger(Sorter s)
        {            
            _s = s;
            _s.SortEvent += SortEventHandler;
            _sw = new Stopwatch();
        }
        /// <summary>
        /// Возвращает строковое представление логгера.
        /// </summary>
        /// <returns>Строковое представление логгера.</returns>
        public override string ToString()
        {
            string strOut = "";
            if (_uiMergeCount == 0)
            {
                strOut = string.Format("Тип сортировки: {0}, сравнений: {1}, перестановок: {2}. Затраченное время: {3} мс.",
                 _s.SortName, _uiCompareCount, _uiSwapCount, _sw.ElapsedMilliseconds.ToString());
            }
            else
            {
                strOut = string.Format("Тип сортировки: {0}, сравнений: {1}, слияний: {2}. Затраченное время: {3} мс.",
                 _s.SortName, _uiCompareCount, _uiMergeCount, _sw.ElapsedMilliseconds.ToString());
            }
            return strOut; 
        }
        /// <summary>
        /// Обработчик события сортировки.
        /// </summary>
        /// <param name="sender">Объект-инициатор события.</param>
        /// <param name="args">Параметр события.</param>
        private void SortEventHandler(object sender, SortEventArgs args)
        {
            switch (args.Type)
            {
                case EventType.SortStart:
                    _sw.Start();
                    break;
                case EventType.Comparison:
                    ++_uiCompareCount;
                    break;
                case EventType.Swap:
                    ++_uiSwapCount;
                    break;
                case EventType.Merge:
                    ++_uiMergeCount;
                    break;
                case EventType.SortStop:
                    _sw.Stop();
                    break;
                default:
                    break;
            }
        }       
        /// <summary>
        /// Поля логгера.
        /// </summary>
        private Sorter _s = null;           // Ссылка на логгируемый сортировщик.
        private Stopwatch _sw = null;       // Внутренний таймер.
        private uint _uiCompareCount = 0;   // Счетчик сравнений.
        private uint _uiSwapCount = 0;      // Счетчик обменов.
        private uint _uiMergeCount = 0;     // Счетчик слияний.
    }
}