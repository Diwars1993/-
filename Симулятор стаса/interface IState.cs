using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_стаса
{
    public interface IState
    {
        /// <summary>
        /// Пополнить счет.
        /// </summary>
        /// <param name="card"> Пополняемый счет. </param>
        /// <param name="money"> Сумма пополнения. </param>
        void Deposit(Card card, decimal money);

        /// <summary>
        /// Расходование со счета.
        /// </summary>
        /// <param name="card"> Счет списания. </param>
        /// <param name="price"> Стоимость покупки. </param>
        /// <returns> Успешность выполнения операции. </returns>
        bool Spend(Card card, decimal price);
    }
}
