using System;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace InterceptDemo.Intercept
{
	public class InterceptProperty : IContextProperty, IContributeObjectSink
	{
		public InterceptProperty()
		{
			Console.WriteLine(" 调用 'InterceptProperty' - '构造器'  ");
		}
		public string Name
		{
			get
			{
				return "Intercept";
			}
		}
		public void Freeze(Context newContext)
		{

		}
		public bool IsNewContextOK(Context newCtx)
		{
			var result = newCtx.GetProperty("Intercept");
			return result != null;
		}

		public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
		{
			InterceptSink interceptSink = new InterceptSink(nextSink);
			return interceptSink;
		}
	}
}
