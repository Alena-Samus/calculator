using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сalculator
{
    public partial class Form1 : Form
    {//Глобальные переменные
        //numbFirst - вводимое число
        long numbFirst = 0, numbSecond = 0;


        //Признаки оператора или числа
        char lastOp = 'z';

        //Запоминает какой конкретно оператор был выбран
        char Op = 'z';
        public Form1()
        {
            InitializeComponent();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Полная очистка поля Text screenLabel и обнуление переменной numbFirst
            screenLabel.Text = "0";
            numbFirst = 0;
            lastOp = Op = 'z';//Сбрасываем операторы
        }

        private void oneBtn_Click(object sender, EventArgs e)
        {//Передаем событие от нажатой в данный момент кнопки
            Button number = sender as Button;

            /*Избавляемся от ведущего 0:
            если при запуске в поле Text только 0, то заменяем его за значение поля Text
            нажатой кнопки. В противном случае дописываем цифры справа
            
             lastOp != '5' - означает, что ввели не цифру, а оператор. Это позволяет обнулять значение
            поля Text и начать вводить новую цифру*/
            if (screenLabel.Text == "0" || lastOp != '5')            
                screenLabel.Text = number.Text;              
            
            else
                screenLabel.Text = screenLabel.Text + number.Text;

            //Если после равно набираем число, то последнюю операцию надо сбросить

            if (lastOp == '=')
                Op = 'z';
            //Запоминаем, что нажалась именно цифра
            lastOp = '5';
        }

        private void button18_Click(object sender, EventArgs e)
        {

            //Удаление одного символа
            //Если длина поля Text только один символ, то мы заменяем его на 0
            if (lastOp == '5')
            if (screenLabel.Text.Length == 1)
                screenLabel.Text = "0";
            //Substring - удаляет подстроку из строки Substring (откуда начинаем, длина удаляемой подстроки)
            else
                screenLabel.Text = screenLabel.Text.Substring(0, screenLabel.Text.Length - 1);
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            if (lastOp == 'z')//Если последняя операция была сброс, то мы ничего не делаем
                return;

            if (lastOp == '5')//Если последняя операция цифра, то мы берем число
            {
                numbSecond = Convert.ToInt64(screenLabel.Text);
                lastOp = '=';//Говорим, что последняя операция была не цифра
            }
               
            //Оператор не изменился, повторяем его выбор
            switch (Op)
            {
                case '+':
                    numbFirst = numbFirst + numbSecond; //складываем числа
                    screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                    break;

                case '-':
                    numbFirst = numbFirst - numbSecond; //отнимаем числа
                    screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                    break;

                case '*':
                    numbFirst = numbFirst * numbSecond; //умножаем числа
                    screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                    break;

                case '/':
                    if (numbSecond == 0)
                        MessageBox.Show("Попытка деления на 0!");
                    else
                    {
                        numbFirst = numbFirst / numbSecond; //делим числа
                        screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                    }
                    break;

                default:
                    numbFirst = numbSecond;
                    break;
            }
        }

        private void plusBtn_Click(object sender, EventArgs e)
        {

            //Передаем событие от нажатой в данный момент кнопки
            Button number = sender as Button;

            if (lastOp != '=')//Блок выполняется в том случае, если последняя операция не была '='
            {

                numbSecond = Convert.ToInt64(screenLabel.Text);

                //Запоминает, что какой-то оператор был выбран
                switch (Op)
                {
                    case '+':
                        numbFirst = numbFirst + numbSecond; //складываем числа
                        screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                        break;

                    case '-':
                        numbFirst = numbFirst - numbSecond; //отнимаем числа
                        screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                        break;

                    case '*':
                        numbFirst = numbFirst * numbSecond; //умножаем числа
                        screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                        break;

                    case '/':
                        numbFirst = numbFirst / numbSecond; //делим числа
                        screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                        break;

                    case 'z':
                        numbFirst = numbSecond;
                        screenLabel.Text = Convert.ToString(numbFirst);//выводим результат на экран
                        break;
                }
            }
            lastOp = '+';//Пометка, что нажат оператор

            //Смотрим, что нажато, определяем, какой оператор был выбран и запоминаем его в переменной Op
            switch (number.Text)
            {
                case "+": 
                    Op = '+';break;
                case "-": 
                    Op = '-'; break;
                case "✕": 
                    Op = '*'; break;
                case "÷": 
                    Op = '/'; break;

            }
        }
    }
}
