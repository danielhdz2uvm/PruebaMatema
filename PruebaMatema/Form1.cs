using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaMatema
{
    public partial class Form1 : Form
    {
        // Crea un objeto Random llamado randomizer
        // para generar números aleatorios
        Random randomizer = new Random();

        // Estas variables enteras almacenan los números
        // para el problema de suma
        int addend1;
        int addend2;

        // Estas variables enteras almacenan los números
        // para el problema de resta
        int minuend;
        int subtrahend;

        // Estas variables enteras almacenan los números
        // para el problema de multiplicación
        int multiplicand;
        int multiplier;

        // Estas variables enteras almacenan los números
        // para el problema de división
        int dividend;
        int divisor;

        // Esta variable entera realiza un seguimiento del
        // tiempo restante
        int timeLeft;
        
        ///  <summary>
        ///  Comience la prueba completando todos los problemas
        ///  y poner en marcha el temporizador
        /// </summary>
        public void StartTheQuiz()
        {
            // Completa el problema de suma
            // Genera dos números aleatorios para sumar
            // Almacenar los valores en las variables 'addend1' y 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Convierte los dos números generados aleatoriamente
            // en cadenas para que se puedan mostrar
            // en los controles de etiqueta
            plusLeftLabel.Text = addend1.ToString();
            plusRighLabel.Text = addend2.ToString();

            //'sum' es el nombre del control NumericUpDown
            // Este paso asegura que su valor sea cero antes
            // añadiendo cualquier valor a la misma
            sumar.Value = 0;

            // Completa el problema de resta
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Completa el problema de multiplicación
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Completa el problema de división
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Iniciar el temporizador
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        /// <summary>
        /// Verifique las respuestas para ver si el usuario entendió todo bien
        /// </summary>
        /// <returns>verdadero si la respuesta es correcta, falso en caso contrario</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sumar.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // Si CheckTheAnswer() devuelve verdadero, entonces el usuario
                // obtuve la respuesta correcta, detener el temporizador
                // y moestrar un Mensaje de caja
                timer1.Stop();
                MessageBox.Show("¡ Tienes todas las respuetas correctas!", "  ¡ Felicidades !");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Si CheckTheAnswer() devuelve falso, sigue contando
                // abajo, disminuye el tiempo restante en un segundo y
                // moestrar el nuevo tiempo restante actualizado la
                // etiqueta de tiempo restante
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // Si el usuario se quedó sin tiempo, detener el temporizador, mostrar
                // un cuadro de mensaje y complete las respuestas
                timer1.Stop();
                timeLabel.Text = "Times's up!";
                MessageBox.Show("You didn't finish in time. ", "Sorry!");
                sumar.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Selecciona la respueata completa en el control NumericUpDown
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengtOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengtOfAnswer);
            }
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.Red;
        }
    }
}
