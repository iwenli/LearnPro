using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("调用 Main ..");

			InterceptDemo _intercept = new InterceptDemo();
			_intercept.Operate1();

			Console.WriteLine("退出 Main ..");
			Console.Read();

		}
	}
}
