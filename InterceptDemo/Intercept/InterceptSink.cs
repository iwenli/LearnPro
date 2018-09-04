using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace InterceptDemo.Intercept
{
	public class InterceptSink : IMessageSink
	{
		private IMessageSink nextSink = null;
		public IMessageSink NextSink
		{
			get { return nextSink; }
		}
		public InterceptSink(IMessageSink nextSink)
		{
			Console.WriteLine(" 调用 'InterceptSink' - '构造器'  ");
			this.nextSink = nextSink;
		}

		public IMessage SyncProcessMessage(IMessage msg)
		{
			Console.WriteLine(" 方法名称: " + msg.Properties["__MethodName"].ToString());
			IMessage returnMsg = nextSink.SyncProcessMessage(msg);
			return returnMsg;
		}
		public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
		{
			return null;
		}
	}
}
