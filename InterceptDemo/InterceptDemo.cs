using InterceptDemo.Intercept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptDemo
{

	/// <summary>
	/// 如果要在此类上添加拦截池，则该类需要执行以下操作：
	/// 1、继承形式ContextBoundObject。
	/// 2、标记InterceptAttribute。
	/// </summary>
	[Intercept]
	class InterceptDemo : ContextBoundObject
	{
		public InterceptDemo()
		{
			Console.WriteLine(" 调用 'InterceptDemo' - '构造器'  ");
		}
		public void Operate1()
		{
			Console.WriteLine(" 调用 'InterceptDemo' - 'Operate1' ");
		}

	}
}
