using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace InterceptDemo.Intercept
{
	/// <summary>
	/// 某些类如果要拦截，则必须标记此属性。
	/// </summary>
	public class InterceptAttribute : Attribute, IContextAttribute
	{
		public InterceptAttribute()
		{
			Console.WriteLine(" 调用 'InterceptAttribute' - '构造器'  ");
		}
		public void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
		{
			ctorMsg.ContextProperties.Add(new InterceptProperty());
		}
		public bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
		{
			InterceptProperty interceptObject = ctx.GetProperty("Intercept") as InterceptProperty;

			return interceptObject != null;
		}
	}
}
