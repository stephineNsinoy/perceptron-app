using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace perceptron_app
{
    public partial class Form1 : Form
    {
        int N = 35;
        int[] letter, desiredOutput, a, b, c, d, E, f, g, h, I, j, k, l, m, n, o, p, q, u, r, s, t, e, v, w, x, y, z;

        List<Button> randomButtons;
        List<Button> trainedButtons;
        double[] weights;
        int bias;

        public Form1()
        {
            InitializeComponent();
            letter = new int[N];
            desiredOutput = new int[N];
            a = new int[35] { 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };      //A
            b = new int[35] { 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0 };      //B
            c = new int[35] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };      //C
            d = new int[35] { 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0 };      //D 
            E = new int[35] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1 };      //E
            f = new int[35] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 };      //F 
            g = new int[35] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };      //G  
            h = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };      //H 
            I = new int[35] { 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1 };      //I
            j = new int[35] { 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0 };      //J
            k = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1 };      //K 
            l = new int[35] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1 };      //L
            m = new int[35] { 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };      //M
            n = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };      //N 
            o = new int[35] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };      //O
            p = new int[35] { 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0 };      //P
            q = new int[35] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 };      //Q
            r = new int[35] { 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1 };      //R
            s = new int[35] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };      //S
            t = new int[35] { 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 };      //T
            u = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };      //U
            v = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0 };      //V
            w = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1 };      //W
            x = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 1 };      //X
            y = new int[35] { 1, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0 };      //Y
            z = new int[35] { 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1 };      //Z
            weights = new double[N];
            bias = 0;
            randomButtons = new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10,
                                btn11, btn12, btn13, btn14, btn15, btn16, btn17, btn18, btn19, btn20,
                                btn21, btn22, btn23, btn24, btn25, btn26, btn27, btn28, btn29, btn30,
                                btn31, btn32, btn33, btn34, btn35 };

            trainedButtons = new List<Button> { btnr1, btnr2, btnr3, btnr4, btnr5, btnr6, btnr7, btnr8, btnr9, btnr10,
                                btnr11, btnr12, btnr13, btnr14, btnr15, btnr16, btnr17, btnr18, btnr19, btnr20,
                                btnr21, btnr22, btnr23, btnr24, btnr25, btnr26, btnr27, btnr28, btnr29, btnr30,
                                btnr31, btnr32, btnr33, btnr34, btnr35 };
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            if (letterTextBox.Text != "")
            {
                SetTrainedButtonsColor();
            }
        }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            if (letterTextBox.Text != "")
            {
                SetLetter(letterTextBox.Text[0]);

                Random rand = new Random();

                for (int i = 0; i < N; i++)
                {
                    int index = rand.Next(N); // generate a random index between 0 and N-1
                    int temp = letter[i];
                    letter[i] = letter[index];
                    letter[index] = temp;
                }

                SetRandomButtonsColor();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < N; i++)
            {
                letter[i] = 0;
                randomButtons[i].BackColor = SystemColors.ButtonFace;
                randomButtons[i].ForeColor = default;
                randomButtons[i].UseVisualStyleBackColor = true;

                trainedButtons[i].BackColor = SystemColors.ButtonFace;
                trainedButtons[i].ForeColor = default;
                trainedButtons[i].UseVisualStyleBackColor = true;
            }

            letterTextBox.Clear();
            trainTextBox.Clear();
        }

        public void SetLetter(char let)
        {
            //letter will store the inputted letter with its given 7x5 binary numbers and the vowel/consonant indicator
            //LAST BIT INDICATOR -- VOWEL = 1  CONSONANT = -1 
            if (let == 'A' || let == 'a')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = a[i];
                    desiredOutput[i] = a[i];
                }
            }
            else if (let == 'B' || let == 'b')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = b[i];
                    desiredOutput[i] = b[i];
                }
            }
            else if (let == 'C' || let == 'c')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = c[i];
                    desiredOutput[i] = c[i];
                }
            }
            else if (let == 'D' || let == 'd')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = d[i];
                    desiredOutput[i] = d[i];
                }
            }
            else if (let == 'E' || let == 'e')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = E[i];
                    desiredOutput[i] = E[i];
                }
            }
            else if (let == 'F' || let == 'f')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = f[i];
                    desiredOutput[i] = f[i];
                }
            }
            else if (let == 'G' || let == 'g')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = g[i];
                    desiredOutput[i] = g[i];
                }
            }
            else if (let == 'H' || let == 'h')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = h[i];
                    desiredOutput[i] = h[i];
                }
            }
            else if (let == 'I' || let == 'i')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = I[i];
                    desiredOutput[i] = I[i];
                }
            }
            else if (let == 'J' || let == 'j')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = j[i];
                    desiredOutput[i] = j[i];
                }
            }
            else if (let == 'K' || let == 'k')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = k[i];
                    desiredOutput[i] = k[i];
                }
            }
            else if (let == 'L' || let == 'l')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = l[i];
                    desiredOutput[i] = l[i];
                }
            }
            else if (let == 'M' || let == 'm')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = m[i];
                    desiredOutput[i] = m[i];
                }
            }
            else if (let == 'N' || let == 'n')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = n[i];
                    desiredOutput[i] = n[i];
                }
            }
            else if (let == 'O' || let == 'o')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = o[i];
                    desiredOutput[i] = o[i];
                }
            }
            else if (let == 'P' || let == 'p')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = p[i];
                    desiredOutput[i] = p[i];
                }
            }
            else if (let == 'Q' || let == 'q')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = q[i];
                    desiredOutput[i] = q[i];
                }
            }
            else if (let == 'R' || let == 'r')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = r[i];
                    desiredOutput[i] = r[i];
                }
            }
            else if (let == 'S' || let == 's')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = s[i];
                    desiredOutput[i] = s[i];
                }
            }
            else if (let == 'T' || let == 't')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = t[i];
                    desiredOutput[i] = t[i];
                }
            }
            else if (let == 'U' || let == 'u')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = u[i];
                    desiredOutput[i] = u[i];
                }
            }
            else if (let == 'V' || let == 'v')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = v[i];
                    desiredOutput[i] = v[i];
                }
            }
            else if (let == 'W' || let == 'w')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = w[i];
                    desiredOutput[i] = w[i];
                }
            }
            else if (let == 'X' || let == 'x')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = x[i];
                    desiredOutput[i] = x[i];
                }
            }
            else if (let == 'Y' || let == 'y')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = y[i];
                    desiredOutput[i] = y[i];
                }
            }
            else if (let == 'Z' || let == 'z')
            {
                for (int i = 0; i < N; i++)
                {
                    letter[i] = z[i];
                    desiredOutput[i] = z[i];
                }
            }
        }

        public void SetRandomButtonsColor()
        {
            for (int i = 0; i < N; i++)
            {
                if (letter[i] == 1)
                {
                    randomButtons[i].BackColor = Color.LightGreen;
                }
                else
                {
                    randomButtons[i].BackColor = SystemColors.ButtonFace;
                    randomButtons[i].ForeColor = default;
                    randomButtons[i].UseVisualStyleBackColor = true;
                }
            }
        }

        public void SetTrainedButtonsColor()
        {
            for (int i = 0; i < N; i++)
            {
                if (letter[i] == 1)
                {
                    trainedButtons[i].BackColor = Color.LightGreen;
                }
                else
                {
                    trainedButtons[i].BackColor = SystemColors.ButtonFace;
                    trainedButtons[i].ForeColor = default;
                    trainedButtons[i].UseVisualStyleBackColor = true;
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            letter[0] = 1;
            btn1.BackColor = Color.LightGreen;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            letter[1] = 1;
            btn2.BackColor = Color.LightGreen;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            letter[2] = 1;
            btn3.BackColor = Color.LightGreen;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            letter[3] = 1;
            btn4.BackColor = Color.LightGreen;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            letter[4] = 1;
            btn5.BackColor = Color.LightGreen;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            letter[5] = 1;
            btn6.BackColor = Color.LightGreen;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            letter[6] = 1;
            btn7.BackColor = Color.LightGreen;
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            letter[7] = 1;
            btn8.BackColor = Color.LightGreen;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            letter[8] = 1;
            btn9.BackColor = Color.LightGreen;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            letter[9] = 1;
            btn10.BackColor = Color.LightGreen;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            letter[10] = 1;
            btn11.BackColor = Color.LightGreen;
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            letter[11] = 1;
            btn12.BackColor = Color.LightGreen;
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            letter[12] = 1;
            btn13.BackColor = Color.LightGreen;
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            letter[13] = 1;
            btn14.BackColor = Color.LightGreen;

        }

        private void btn15_Click(object sender, EventArgs e)
        {
            letter[14] = 1;
            btn15.BackColor = Color.LightGreen;
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            letter[15] = 1;
            btn16.BackColor = Color.LightGreen;
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            letter[16] = 1;
            btn17.BackColor = Color.LightGreen;
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            letter[17] = 1;
            btn18.BackColor = Color.LightGreen;
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            letter[18] = 1;
            btn18.BackColor = Color.LightGreen;
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            letter[19] = 1;
            btn20.BackColor = Color.LightGreen;
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            letter[20] = 1;
            btn21.BackColor = Color.LightGreen;
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            letter[21] = 1;
            btn22.BackColor = Color.LightGreen;
        }

        private void btn23_Click(object sender, EventArgs e)
        {
            letter[22] = 1;
            btn23.BackColor = Color.LightGreen;
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            letter[23] = 1;
            btn24.BackColor = Color.LightGreen;
        }

        private void btn25_Click(object sender, EventArgs e)
        {
            letter[24] = 1;
            btn25.BackColor = Color.LightGreen;
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            letter[25] = 1;
            btn26.BackColor = Color.LightGreen;
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            letter[26] = 1;
            btn27.BackColor = Color.LightGreen;
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            letter[27] = 1;
            btn28.BackColor = Color.LightGreen;
        }

        private void btn29_Click(object sender, EventArgs e)
        {
            letter[28] = 1;
            btn29.BackColor = Color.LightGreen;
        }

        private void btn30_Click(object sender, EventArgs e)
        {
            letter[29] = 1;
            btn30.BackColor = Color.LightGreen;
        }

        private void btn31_Click(object sender, EventArgs e)
        {
            letter[30] = 1;
            btn31.BackColor = Color.LightGreen;
        }

        private void btn32_Click(object sender, EventArgs e)
        {
            letter[31] = 1;
            btn32.BackColor = Color.LightGreen;
        }

        private void btn33_Click(object sender, EventArgs e)
        {
            letter[32] = 1;
            btn33.BackColor = Color.LightGreen;
        }

        private void btn34_Click(object sender, EventArgs e)
        {
            letter[33] = 1;
            btn34.BackColor = Color.LightGreen;
        }

        private void btn35_Click(object sender, EventArgs e)
        {
            letter[34] = 1;
            btn35.BackColor = Color.LightGreen;
        }

    }
}
