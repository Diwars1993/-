using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Симулятор_стаса
{
    public partial class Form1 : Form
    {

        public class Blocked : IState
        {
            /// <summary>
            /// Пополнить счет.
            /// </summary>
            /// <param name="card"> Пополняемый счет. </param>
            /// <param name="money"> Сумма пополнения. </param>
            public void Deposit(Card card, decimal money)
            {
                // Проверяем входные аргументы на корректность.
                if (card == null)
                {
                    throw new ArgumentNullException(nameof(card));
                }

                if (money <= 0)
                {
                    throw new ArgumentException("Вносимая сумма должна быть больше нуля.", nameof(money));
                }

                // Вычисляем сумму сверхлимитной задолженности.
                var overdraft = card.CreditLimit - card.Credit;

                // Вычисляем насколько сумма пополнения перекрывает задолженность.
                var difference = money - overdraft;

                if (difference < 0)
                {
                    // Если сумма пополнения не перекрывает задолженность,
                    // то просто уменьшаем сумму задолженности.
                    card.Credit += money;

                    // Вычисляем процент оставшейся суммы на счете.
                    var limit = card.Credit / card.CreditLimit * 100;
                    if (limit < 10)
                    {
                        
                        // Если после пополнения на счете все еще меньше десяти процентов от лимита,
                        // то просто сообщаем об этом пользователю.
                        Form1 form1 = new Form1();
                        form1.textBox4.Text = "";
                        form1.textBox4.Text =  $"Ваш счет пополнен на сумму {money}. " +
                            $"Сумма на вашем счете все еще составляет менее 10%. Ваш счет остался заблокирован. Пополните счет на большую сумму.  {card.ToString()}";
                    }
                    else if (limit >= 10 && limit < 100)
                    {
                        // Если задолженность перекрыта не полностью, то переводим в состояние расходования кредитных средств.
                        card.State = new UsingCreditFunds();

                        Console.WriteLine($"Ваш счет пополнен на сумму {money}. Задолженность частично погашена. " +
                            $"Погасите задолженность в размере {Math.Abs(difference)} рублей. {card.ToString()}");
                    }
                    else
                    {
                        // Иначе задолженность полностью погашена, переводим в состояние расходования собственных средств.
                        card.State = new UsingOwnFunds();

                        Console.WriteLine($"Ваш счет пополнен на {money} рублей. Задолженность полностью погашена. {card.ToString()}");
                    }
                }
                else
                {
                    // Иначе закрываем задолженность, а оставшиеся средства переводим в собственные средства.
                    card.Credit = card.CreditLimit;
                    card.Debit = difference;

                    // Переводим карту в состояние использования собственных средств.
                    card.State = new UsingOwnFunds();

                    Console.WriteLine($"Ваш счет пополнен на {money} рублей. " +
                        $"Кредитная задолженность погашена. {card.ToString()}");
                }
            }

            /// <summary>
            /// Расходование со счета.
            /// </summary>
            /// <param name="card"> Счет списания. </param>
            /// <param name="price"> Стоимость покупки. </param>
            /// <returns> Успешность выполнения операции.</returns>
            public bool Spend(Card card, decimal price)
            {
                // Отказываем в операции.
                Console.WriteLine($"Ваш счет заблокирован. Пополните счет.  {card.ToString()}");
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "9";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text + ".";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int lenght = textBox8.Text.Length; // Вычисляем сколько символов
            --lenght; // Удаляем один символ потому что индаксы идут с 0 и получаем индакс последнего символа

            string text = textBox8.Text; // Созадем строку со всеми символами введенными
            textBox8.Clear(); // удаляем все из textBox1

            for (int i = 0; i < lenght; i++) // Перебираем строку (string text) до тех пор пока i (ИНДАКС) < lenght 
            {
                textBox8.Text = textBox8.Text + text[i]; // Присваиваем в ходе перебора все символы по индаксу кроме последнего символа индакс которого вычаслили в свмом начале
            }
        }
    }
}
