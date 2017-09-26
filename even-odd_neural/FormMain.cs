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

	// TODO: вид словаря
	public partial class FormMain : Form
	{
		private Dictionary<int, string> dictionary;
		private Neuron neuron;
		private string lastPicture;
		private int lastAnswer;

		public FormMain()
		{
			InitializeComponent();

			FillDictionary();
			neuron = new Neuron();
			lastPicture = "000000000000";
			lastAnswer = 0;
			labelAnswer.Text = "";
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
			ClickEvent(0);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ClickEvent(1);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ClickEvent(2);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			ClickEvent(3);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ClickEvent(4);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			ClickEvent(5);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			ClickEvent(6);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			ClickEvent(7);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			ClickEvent(8);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			ClickEvent(9);
		}

		private void ClickEvent(int i)
		{
			textBoxPicture.Text = dictionary[i];
			labelAnswer.Text = "";
			buttonReact.Enabled = true;
			buttonNo.Enabled = false;
		}

		private void buttonReact_Click(object sender, EventArgs e)
		{
			string picture = UnmaskedPicture(textBoxPicture.Text);

			if ((lastAnswer = neuron.React(picture)) == 1)
				labelAnswer.Text = "Нечётное";
			else
				labelAnswer.Text = "Чётное";

			lastPicture = picture;
			buttonNo.Enabled = true;
		}

		private void buttonAutoLearning_Click(object sender, EventArgs e)
		{
			Hebb();
			labelGenerations.Text = neuron.Generation.ToString();
		}

		private void buttonNo_Click(object sender, EventArgs e)
		{
			if (lastAnswer == 0)
				neuron.Learn(1, lastPicture);
			else
				neuron.Learn(-1, lastPicture);

			labelGenerations.Text = neuron.Generation.ToString();
			labelAnswer.Text = "";

			buttonNo.Enabled = false;
		}

		private void textBoxPicture_TextChanged(object sender, EventArgs e)
		{
			labelAnswer.Text = "";

			if (UnmaskedPicture(textBoxPicture.Text).Length == 12)
				buttonReact.Enabled = true;
			else
				buttonReact.Enabled = false;

			buttonNo.Enabled = false;
		}

		private string UnmaskedPicture(string maskedPicture)
		{
			string picture = "";
			for (int i = 0; i < maskedPicture.Length; i++)
			{
				if (maskedPicture[i] == '0')
					picture += '0';
				else if (Char.IsDigit(maskedPicture[i]))
					picture += '1';
			}
			return picture;
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
		}
	}
}
