using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenOddPerseptron
{
	class Neuron
	{
		int[] w;
		int theta;
		public int Generation { get; private set; }

		public Neuron()
		{
			Random r = new Random();

			w = new int[12];
			for (int i = 0; i < 12; i++)
				w[i] = r.Next(-10, 10);

			theta = r.Next(100);
			Generation = 0;
		}

		public int React(string picture)
		{
			int S = 0;

			for (int i = 0; i < 12; i++)
				S += int.Parse(picture[i].ToString()) * w[i];

			if (S >= theta)
				return 1;
			else
				return 0;
		}
		
		public void Learn(int mistake, string picture)
		{
			for (int i = 0; i < 12; i++)
				w[i] += mistake * int.Parse(picture[i].ToString());
			Generation++;
		}
	}
}
