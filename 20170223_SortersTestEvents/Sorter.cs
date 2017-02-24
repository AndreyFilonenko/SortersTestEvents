using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20170223_SortersTestEvents
{
    /// <summary>
    /// Класс события сортировки.
    /// </summary>
    public class SortEventArgs : EventArgs
    {
        /// <summary>
        /// Конструктор события сортировки.
        /// </summary>
        /// <param name="type">Тип события.</param>
        public SortEventArgs(EventType type)
        {
            Type = type;
        }
        /// <summary>
        /// Свойство "Тип события".
        /// </summary>
        public EventType Type { get; private set; }
    }

    /// <summary>
    /// Делегат обработчика события.
    /// </summary>
    /// <param name="sender">Объект - генератор события.</param>
    /// <param name="args">Параметр события.</param>
    public delegate void SortEvent(object sender, SortEventArgs args);

    /// <summary>
    /// Класс сортировщика.
    /// </summary>
    public abstract class Sorter
    {        
        /// <summary>
        /// Конструктор сортировщика.
        /// </summary>
        /// <param name="adNumbers"></param>
        public Sorter(double[] adNumbers)
        {
            _adNumbers = (double[])adNumbers.Clone();
        }
        /// <summary>
        /// Событие сортировщика.
        /// </summary>
        public event SortEvent SortEvent
        {
            add
            {
                _se += value;
            }
            remove
            {
                _se -= value;
            }
        }        
        /// <summary>
        /// Обеспечивает проверку на отсортированость массива.
        /// </summary>
        /// <returns></returns>
        public bool IsSorted()
        {
            bool bIsSorted = true;
            for (int i = 0; i < _adNumbers.Length - 1; ++i)
            {
                if (_adNumbers[i] > _adNumbers[i + 1])
                {
                    bIsSorted = false;
                }
            }
            return bIsSorted;
        }        
        /// <summary>
        /// Обеспечивает работу сортировщика с генерацией событий старт/стоп.
        /// </summary>
        public void Run()
        {
            if (_se != null)
            {
                _se(this, new SortEventArgs(EventType.SortStart));
            }
            this.Sort();
            if (_se != null)
            {
                _se(this, new SortEventArgs(EventType.SortStop));
            }
        }
        /// <summary>
        /// Обеспечивает сортировку.
        /// </summary>
        public abstract void Sort();
        /// <summary>
        ////Обеспечивает сравнение двух элементов.
        /// </summary>
        /// <param name="dA">Элемент А.</param>
        /// <param name="dB">Элемент B.</param>
        /// <returns></returns>
        protected bool IsLargerThan(double dA, double dB)
        {
            if (_se != null)
            {
                _se(this, new SortEventArgs(EventType.Comparison));
            }
            return dA > dB;
        }
        /// <summary>
        /// Обеспечивает обмен двух элементов.
        /// </summary>
        /// <param name="dA">Элемент А.</param>
        /// <param name="dB">Элемент B.</param>
        protected void Swap(ref double dA, ref double dB)
        {
            if (_se != null)
            {
                _se(this, new SortEventArgs(EventType.Swap));
            }
            double dC = dB;
            dB = dA;
            dA = dC;
        }
        /// <summary>
        /// Реализует процедуру слияния двух массивов в один.
        /// </summary>
        /// <param name="adItems">Итоговый массив.</param>
        /// <param name="adLeft">Левый слияемый массив.</param>
        /// <param name="adRight">Правый слияемый массив.</param>
        protected void Merge(double[] adItems, double[] adLeft, double[] adRight)
        {
            if (_se != null)
            {
                _se(this, new SortEventArgs(EventType.Merge));
            }
            int iLeftIndex = 0;
            int iRightIndex = 0;
            int iTargetIndex = 0;
            int iRemaining = adLeft.Length + adRight.Length;
            while (iRemaining > 0)
            {
                if (iLeftIndex >= adLeft.Length)
                {
                    adItems[iTargetIndex] = adRight[iRightIndex++];
                }
                else if (iRightIndex >= adRight.Length)
                {
                    adItems[iTargetIndex] = adLeft[iLeftIndex++];
                }
                else if (IsLargerThan(adRight[iRightIndex], adLeft[iLeftIndex]))
                {
                    adItems[iTargetIndex] = adLeft[iLeftIndex++];
                }
                else
                {
                    adItems[iTargetIndex] = adRight[iRightIndex++];
                }

                ++iTargetIndex;
                --iRemaining;
            }
        }
        /// <summary>
        /// Свойство "Имя сортировки".
        /// </summary>
        public abstract string SortName { get; }
        /// <summary>
        /// Поля сортировщика.
        /// </summary>
        protected double[] _adNumbers = null;   // Сортируемый массив.
        protected SortEvent _se = null;           // Ссылка на делегат-обработчик.
    }
}