using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {//Дана матрица размера M × N. Поменять местами столбец с номером N и первый из столбцов, 
     //содержащих только отрицательные элементы. Если требуемых столбцов нет, 
     //то вывести матрицу без изменений.
        Random R = new Random();
        public Form1()
        {
            InitializeComponent();
            ///Параметры для автоматической смены ширины ячеек
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoResizeColumns();
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            //Параметры для автоматической смены ширины ячеек для второй матрицы
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

        }
        int M, N;
        void OAIP() // метод заполнения первой матрицы
        {
            M = (int)numericM.Value; // присваием переменной M,то что будет на форме нумерика M
            N = (int)numericN.Value; // присваием переменной N,то что будет на форме нумерика N
            dataGrid.ColumnCount = N; // N - столбцы
            dataGrid.RowCount = M; // M - строчки
            dataGridView1.RowCount = M; // M - Строка
            dataGridView1.ColumnCount = N; // N - Столбец
            for (int i = 0; i < M; i++) // цикл для заполнения матрицы
            {
                for (int j = 0; j < N; j++)
                {
                    dataGrid[j, i].Value = R.Next(-9, 9); // задаем диапозон от -9 до 9 для ячеек матрицы
                    dataGridView1[j, i].Value = dataGrid[j, i].Value; // задаем такие же значения,как и у первой матрицы

                }
            }
        }
        private void button1_Click(object sender, EventArgs e) // при нажатии на button1
        {
            
            if (numericM.Value == 0 || numericN.Value == 0) // если значения нумериков равна нулю...
            MessageBox.Show("Введите значения");
            else
            OAIP(); // выполнять метод OAIP

            check();
            if (ourColumn != 98)
            {
                Swap();
            }

        }
        
                
        int[,] masSwap;
        int ourColumn=98;
        void check()
        {
            
            bool check = true;
            for (int j = 0; j < N; j++)
            {
                check = true;
                for ( int i = 0; i < M; i++)
                {
                    if ((int)dataGrid[j, i].Value >= 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check==true)
                {
                    label3.Text = j.ToString();
                    ourColumn = j;
                    MessageBox.Show("");
                    break;
                }
                else label3.Text = "Исходная матрица";
            }
        }
        public void Swap()
        {
             masSwap = new int[M, N];
                       
                for (int i = 0; i < M; i++)
                {
                    masSwap[i, 0] = (int)dataGridView1[N-1, i].Value;                     
                    dataGridView1[N - 1, i].Value = dataGrid[ourColumn, i].Value;
                    dataGridView1[ourColumn, i].Value = masSwap[i, 0];
                }
            
        }
}
}
