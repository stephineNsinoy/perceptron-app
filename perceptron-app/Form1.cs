using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace perceptron_app
{
    public partial class Form1 : Form
    {
        int N = 35;
        int[] inputLetter, actualOutput, targetOutput, a, b, c, d, E, f, g, h, I, j, k, l, m, n, o, p, q, u, r, s, t, e, v, w, x, y, z;
        List<int[]> letters;
        List<PictureBox> inputPattern;
        List<Label> outputWeights;
        double learningRate, bias;
        double[] weight;
        int epoch;
        bool isTrained;

        public Form1()
        {
            InitializeComponent();

            /*******************************************************************************************
                Capital letter patterns with its given 7x5 binary numbers and the vowel/consonant indicator
                Last index is the indicatior/desired output -- VOWEL = 1  CONSONANT = -1 
            ********************************************************************************************/
            a = new int[36] { -1, -1, 1, -1, -1, -1, 1, -1, 1, -1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1,        1 };      //A
            b = new int[36] { 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1,           -1 };      //B
            c = new int[36] { -1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1,    -1 };      //C
            d = new int[36] { 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1,         -1 };      //D 
            E = new int[36] { 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, 1, 1, 1, 1,           1 };      //E
            f = new int[36] { 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1,      -1 };      //F 
            g = new int[36] { -1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, 1, 1, 1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1,       -1 };      //G  
            h = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1,        -1 };      //H 
            I = new int[36] { 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, 1, 1, 1, 1, 1,       1 };      //I
            j = new int[36] { 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, 1, -1, 1, -1, -1, 1, -1, 1, -1, -1, -1, 1, -1, -1, -1,    -1 };      //J
            k = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, 1, -1, 1, -1, 1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1, -1, 1, -1, -1, -1, 1,     -1 };      //K 
            l = new int[36] { 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, 1, 1, 1, 1,  -1 };      //L
            m = new int[36] { 1, -1, -1, -1, 1, 1, 1, -1, 1, 1, 1, -1, 1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1,        -1 };      //M
            n = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, -1, -1, 1, 1, -1, 1, -1, 1, 1, -1, -1, 1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1,        -1 };      //N 
            o = new int[36] { -1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1,        1 };      //O
            p = new int[36] { 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1,      -1 };      //P
            q = new int[36] { -1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1, -1, -1, 1, -1, -1, -1, -1, -1, 1, 1,      -1 };      //Q
            r = new int[36] { 1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, 1, 1, 1, -1, 1, -1, 1, -1, -1, 1, -1, -1, 1, -1, 1, -1, -1, -1, 1,         -1 };      //R
            s = new int[36] { -1, 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, -1, -1, 1, 1, 1, -1, -1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1,      -1 };      //S
            t = new int[36] { 1, 1, 1, 1, 1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1,  -1 };      //T
            u = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, 1, 1, -1,       1 };      //U
            v = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, -1, 1, -1, -1, -1, 1, -1, -1,    -1 };      //V
            w = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, 1, -1, 1, -1, 1, 1, 1, -1, 1, 1, 1, -1, -1, -1, 1,        -1 };      //W
            x = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, -1, 1, -1, -1, -1, 1, -1, -1, -1, 1, -1, 1, -1, 1, -1, -1, -1, 1, 1, -1, -1, -1, 1,    -1 };      //X
            y = new int[36] { 1, -1, -1, -1, 1, 1, -1, -1, -1, 1, -1, 1, -1, 1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1, -1, 1, -1, -1, -1 };      //Y
            z = new int[36] { 1, 1, 1, 1, 1, -1, -1, -1, -1, 1, -1, -1, -1, 1, -1, -1, -1, 1, -1, -1, -1, 1, -1, -1, -1, 1, -1, -1, -1, -1, 1, 1, 1, 1, 1,      -1 };      //Z

            /********** Initial values for weights and bias **********/
            weight = new double[35] { 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5};
            bias = -0.5200000000000006;

            learningRate = 0.01;

            /**********************************************************
             Target output and Actual output last index of every letter 
                            VOWEL/CONSONANT indicator 
            ***********************************************************/
            targetOutput = new int[26] { a[35], b[35], c[35], d[35], E[35], f[35], g[35], h[35], I[35], j[35], k[35], l[35], m[35], n[35], o[35], p[35], q[35], r[35], s[35], t[35], u[35], v[35], w[35], x[35], y[35], z[35] };
            actualOutput = new int[26];
           

            /**************************************************************
            This will store all the letters with equivalent binary patterns
                    This will be iterated to train the model
             **************************************************************/
            letters = new List<int[]> { a, b, c, d, E, f, g, h, I, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z };


            /****** The inputted letter with its equivalent pattern ******/
            inputLetter = new int[35];
            inputPattern = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5,
                                                   pictureBox10, pictureBox9, pictureBox8, pictureBox7, pictureBox6,
                                                   pictureBox15, pictureBox14, pictureBox13, pictureBox12, pictureBox11,
                                                   pictureBox20, pictureBox19, pictureBox18, pictureBox17, pictureBox16,
                                                   pictureBox25, pictureBox24, pictureBox23, pictureBox22, pictureBox21,
                                                   pictureBox30, pictureBox29, pictureBox28, pictureBox27, pictureBox26,
                                                   pictureBox35, pictureBox34, pictureBox33, pictureBox32, pictureBox31
                                                };

            /****** This will display the final weights ******/
            outputWeights = new List<Label> { w1, w2, w3, w4, w5,
                                                w6, w7, w8, w9, w10,
                                                w11, w12, w13, w14, w15,
                                                w16, w17, w18, w19, w20,
                                                w21, w22, w23, w24, w25,
                                                w26, w27, w28, w29, w30,
                                                w31, w32, w33, w34, w35
                                            };

            epoch = 0;
            isTrained = false;
        }

        /// <summary>
        /// Trains the model through the perceptron algorithm
        /// </summary>
        private void buttonTrain_Click(object sender, EventArgs e)
        {
            while (!actualOutput.SequenceEqual(targetOutput) && epoch <= 80)
            {
                epoch++;
                trainTextBox.AppendText("Epoch: " + epoch.ToString() + Environment.NewLine + Environment.NewLine);
                int actualOutputIndex = 0; 

                foreach (int[] letter in letters)
                {
                    // y = weight * input + bias
                    double output = Enumerable.Range(0, letter.Length-1).Sum(j => letter[j] * weight[j]) + bias;
                    
                    // Used hard-limitting function to get actual output
                    actualOutput[actualOutputIndex] = Activation(output);

                    double error = letter[35] - actualOutput[actualOutputIndex];
                    UpdateValues(letter, error);

                    actualOutputIndex++;
                }
            }

            SetLabelWeights();
            trainTextBox.AppendText("Total epochs: " + epoch.ToString());
            isTrained = true;
        }

        /// <summary>
        /// Updates the weights and bias
        /// </summary>
        /// <param name="currentLetter">Pattern of a lettern to be used for updating values</param>
        /// <param name="error">Error produced where error = targetOutput - actualOutput of a letter</param>
        private void UpdateValues(int[] currentLetter, double error)
        {
            for (int i = 0; i < N; i++)
            {
                weight[i] = weight[i] + learningRate * error * currentLetter[i];
                bias = bias + learningRate * error;

                trainTextBox.AppendText("Weight" + i.ToString() + ": " + weight[i].ToString() + Environment.NewLine +
                                            "bias: " + bias.ToString() + Environment.NewLine + Environment.NewLine);
            }
        }

        /// <summary>
        /// The Hard-limitting function
        /// </summary>
        /// <param name="x">the result from y = weight * input + bias</param>
        /// <returns>1 if x > 0, -1 if not</returns>
        private int Activation(double x)
        {
            return x > 0 ? 1 : -1;
        }

        /// <summary>
        /// Determines if a letter is a vowel or a consonant through using the trained model
        /// </summary>
        private void determineBtn_Click(object sender, EventArgs e)
        {
            if (isTrained)
            {
                if (letterTextBox.Text != "")
                {
                    if (SetIsLetter(letterTextBox.Text[0]))
                    {
                        SetInputPattern();

                        // y = weight * input + bias
                        double output = Activation(Enumerable.Range(0, inputLetter.Length).Sum(j => inputLetter[j] * weight[j]) + bias);
                        outputTextBox.Text = output == 1 ? $"Letter {letterTextBox.Text[0]} is a vowel" :
                                                           $"Letter {letterTextBox.Text[0]} is a consonant";
                    }
                    else
                    {
                        outputTextBox.Text = "Your input is not a letter";
                    }
                }
                else
                {
                    outputTextBox.Text = "Input a letter";
                }
            }
            else
            {
                outputTextBox.Text = "Train the model first";
            }
        }
   
        /// <summary>
        /// Resets everything, must do everything again
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 26; i++)
            {
                actualOutput[i] = 0;
            }

            for (int i = 0; i < N; i++)
            {
                weight[i] = 0.5;
                inputPattern[i].BackColor = Color.White;
                outputWeights[i].Text = "";
            }

            epoch = 0;
            bias = 0;
            letterTextBox.Clear();
            trainTextBox.Clear();
            outputTextBox.Clear();
        }

        /// <summary>
        /// Sets the weight labels the final weight values
        /// </summary>
        private void SetLabelWeights()
        {
            for(int i = 0; i < N; i++)
            {
                outputWeights[i].Text = weight[i].ToString();
            }
        }

        /// <summary>
        /// Sets the pattern of the inputted letter
        /// </summary>
        /// <param name="let">Character letter input</param>
        /// <returns>True if input is a letter otherwise fales</returns>
        public bool SetIsLetter(char let)
        {
            if (let == 'A' || let == 'a')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = a[i];
                }
                return true;
            }
            else if (let == 'B' || let == 'b')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = b[i];
                }
                return true;
            }
            else if (let == 'C' || let == 'c')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = c[i];
                }
                return true;
            }
            else if (let == 'D' || let == 'd')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = d[i];
                }
                return true;
            }
            else if (let == 'E' || let == 'e')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = E[i];
                }
                return true;
            }
            else if (let == 'F' || let == 'f')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = f[i];
                }
                return true;
            }
            else if (let == 'G' || let == 'g')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = g[i];
                }
                return true;
            }
            else if (let == 'H' || let == 'h')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = h[i];
                }
                return true;
            }
            else if (let == 'I' || let == 'i')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = I[i];
                }
                return true;
            }
            else if (let == 'J' || let == 'j')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = j[i];
                }
                return true;
            }
            else if (let == 'K' || let == 'k')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = k[i];
                }
                return true;
            }
            else if (let == 'L' || let == 'l')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = l[i];
                }
                return true;
            }
            else if (let == 'M' || let == 'm')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = m[i];
                }
                return true;
            }
            else if (let == 'N' || let == 'n')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = n[i];
                }
                return true;
            }
            else if (let == 'O' || let == 'o')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = o[i];
                }
                return true;
            }
            else if (let == 'P' || let == 'p')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = p[i];
                }
                return true;
            }
            else if (let == 'Q' || let == 'q')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = q[i];
                }
                return true;
            }
            else if (let == 'R' || let == 'r')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = r[i];
                }
                    return true;
            }
            else if (let == 'S' || let == 's')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = s[i];
                }
                return true;
            }
            else if (let == 'T' || let == 't')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = t[i];
                }
                return true;
            }
            else if (let == 'U' || let == 'u')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = u[i];
                }
                return true;
            }
            else if (let == 'V' || let == 'v')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = v[i];
                }
                return true;
            }
            else if (let == 'W' || let == 'w')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = w[i];
                }
                return true;
            }
            else if (let == 'X' || let == 'x')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = x[i];
                }
                return true;
            }
            else if (let == 'Y' || let == 'y')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = y[i];
                }
                return true;
            }
            else if (let == 'Z' || let == 'z')
            {
                for (int i = 0; i < N; i++)
                {
                    inputLetter[i] = z[i];
                }
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Sets the picture boxes with the equivalent pattern of the inputted letter
        /// </summary>
        public void SetInputPattern()
        {       
            for (int i = 0; i < N; i++)
            {
                if (inputLetter[i] == 1)
                {
                    inputPattern[i].BackColor = Color.LightGreen;
                }
                else
                {
                    inputPattern[i].BackColor = Color.White;
                }
            }
        }
    }
}
