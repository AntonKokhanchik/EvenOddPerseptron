using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvenOddPerseptron
{

	// TODO: мониторинг обучения, вид словаря
	public partial class FormMain : Form
	{
		private Dictionary<int, string> dictionary;
		Neuron neuron;

		public FormMain()
		{
			InitializeComponent();
			FillDictionary();
			neuron = new Neuron();
			Hebb();
		}

		private void FillDictionary()
		{
			dictionary = new Dictionary<int, string>();
			dictionary.Add(0, "111101101111");
			dictionary.Add(1, "010010010010");
			dictionary.Add(2, "111101011111");
			dictionary.Add(3, "111011011111");
			dictionary.Add(4, "101101111001");
			dictionary.Add(5, "111111101111");
			dictionary.Add(6, "111100111111");
			dictionary.Add(7, "111001010010");
			dictionary.Add(8, "111101111111");
			dictionary.Add(9, "111111001111");
		}

		private void button0_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[0];
		}

		private void button1_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[1];
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[2];
		}

		private void button3_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[3];
		}

		private void button4_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[4];
		}

		private void button5_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[5];
		}

		private void button6_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[6];
		}

		private void button7_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[7];
		}

		private void button8_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[8];
		}

		private void button9_Click(object sender, EventArgs e)
		{
			textBoxPicture.Text = dictionary[9];
		}

		private void Answer(int n)
		{
			if (neuron.React(dictionary[n]) == 1)
				labelAnswer.Text = "Нечётное";
			else
				labelAnswer.Text = "Чётное";
		}

		private void Hebb()
		{
			bool flag = false;
			while (!flag)
			{
				flag = true;
				for (int i = 0; i < 10; i++)
				{
					while (true)
					{
						int answer = neuron.React(dictionary[i]);
						if (answer == i % 2)
							break;
						else if (answer < i % 2)
							neuron.Learn(1, dictionary[i]);
						else
							neuron.Learn(-1, dictionary[i]);
						flag = false;
					}
				}
			}
			labelGenerations.Text = neuron.Generation.ToString();
		}

		private void buttonReact_Click(object sender, EventArgs e)
		{
			string s = textBoxPicture.Text;
			string picture = "";
			for(int i=0; i<s.Length; i++)
			{
				if (s[i] == '0')
					picture += '0';
				else if (Char.IsDigit(s[i]))
					picture += '1';
			}

			if (neuron.React(picture) == 1)
				labelAnswer.Text = "Нечётное";
			else
				labelAnswer.Text = "Чётное";

		}
	}
}
